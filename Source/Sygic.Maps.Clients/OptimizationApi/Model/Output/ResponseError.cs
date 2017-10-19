using System.Collections.Generic;

namespace Sygic.Maps.Clients.OptimizationApi.Model.Output
{
    public class ResponseError
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Target { get; set; }
        public IEnumerable<ResponseError> Details { get; set; }
    }
}
