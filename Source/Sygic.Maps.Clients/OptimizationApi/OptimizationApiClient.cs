using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Sygic.Maps.Clients.OptimizationApi.Model;
using Sygic.Maps.Clients.OptimizationApi.Model.Input;
using Sygic.Maps.Clients.OptimizationApi.Model.Output;
using Sygic.Maps.Clients.Utils;

namespace Sygic.Maps.Clients.OptimizationApi
{
    public sealed class OptimizationApiClient : IOptimizationApiClient, IDisposable
    {
        private readonly Uri _baseUri;
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public OptimizationApiClient(string baseUri, string apiKey)
        {
            if (baseUri == null) throw new ArgumentNullException(nameof(baseUri));
            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));

            _baseUri = new Uri(baseUri);
            _apiKey = apiKey;
            _httpClient = CreateHttpClient();
        }

        public TimeSpan Timeout
        {
            get { return _httpClient.Timeout; }
            set { _httpClient.Timeout = value; }
        }

        /// <summary>
        /// ignoring null properties, converting enums to strings
        /// </summary>
        private static readonly JsonSerializerSettings JsonSerializerSettings =
            new JsonSerializerSettings
            {
                ContractResolver = new SnakeCaseContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                Converters = {new StringEnumConverter()}
            };

        public Task<OptimizationOutput> OptimizeAsync(OptimizationInput input, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            var inputJson = JsonConvert.SerializeObject(input, JsonSerializerSettings);

            return OptimizeAsync(inputJson, cancellationToken);
        }

        public async Task<OptimizationOutput> OptimizeAsync(string inputJson, CancellationToken cancellationToken)
        {
            if (inputJson == null) throw new ArgumentNullException(nameof(inputJson));

            var content = new StringContent(inputJson, Encoding.UTF8, "application/json");

            try
            {
                var responselink = await _httpClient.PostAsync($"{_baseUri}/v0/api/optimization?key={_apiKey}", content, cancellationToken);

                EnsureSuccessStatusCode(responselink);

                var location = responselink.Headers.Location;

                while (true)
                {
                    using (var response = await _httpClient.GetAsync(location, cancellationToken))
                    {
                        EnsureSuccessStatusCode(response);

                        var responseContent = await response.Content.ReadAsStringAsync();
                        var optimizationOutput = JsonConvert.DeserializeObject<OptimizationOutput>(responseContent, JsonSerializerSettings);

                        switch (optimizationOutput.State)
                        {
                            case OptimizationStateEnum.Finished:
                                return optimizationOutput;

                            case OptimizationStateEnum.Failed:
                                throw new OptimizationApiException($"Optimization state: {optimizationOutput.State}\r\n{optimizationOutput.Error.Message}");
                        }

                        var retryAfter = response.Headers.RetryAfter?.Delta;
                        if (retryAfter.HasValue)
                        {
                            await Task.Delay(retryAfter.Value, cancellationToken);
                        }
                    }
                }
            }
            catch (WebException e)
            {
                throw new OptimizationApiException($"Web exception: {e.Status}", e);
            }
        }

        private static void EnsureSuccessStatusCode(HttpResponseMessage responseMessage)
        {
            if (responseMessage.IsSuccessStatusCode) return;

            throw new OptimizationApiException($"Unexpected status code: {responseMessage.StatusCode} - {responseMessage.ReasonPhrase}");
        }

        private static HttpClient CreateHttpClient()
        {
            var compressionHandler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };

            return new HttpClient(compressionHandler);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
