using System.Threading;
using System.Threading.Tasks;
using Sygic.Maps.Clients.OptimizationApi.Model.Input;
using Sygic.Maps.Clients.OptimizationApi.Model.Output;

namespace Sygic.Maps.Clients.OptimizationApi
{
    public interface IOptimizationApiClient
    {
        Task<OptimizationOutput> OptimizeAsync(OptimizationInput input, CancellationToken cancellationToken = default(CancellationToken));
    }
}