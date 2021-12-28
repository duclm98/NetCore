using System.Threading;
using System.Threading.Tasks;

namespace NetCore.API.QueueService.WorkerService
{
    public class Service
    {
        private readonly IWorkerServiceStrategy workerServiceStrategy;

        public Service(IWorkerServiceStrategy workerServiceStrategy)
        {
            this.workerServiceStrategy = workerServiceStrategy;
        }

        public async ValueTask ExecuteWorkerService(CancellationToken token)
        {
            await workerServiceStrategy.WorkerService(token);
        }
    }
}