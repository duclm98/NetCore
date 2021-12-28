using System.Threading;
using System.Threading.Tasks;

namespace NetCore.API.QueueService.WorkerService
{
    public interface IWorkerServiceStrategy
    {
        ValueTask WorkerService(CancellationToken token);
    }
}