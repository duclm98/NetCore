using Microsoft.Extensions.Hosting;
using NetCore.API.QueueService.WorkerService;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore.API.QueueService
{
    public class MonitorLoop
    {
        private readonly IBackgroundTaskQueue _taskQueue;
        private readonly CancellationToken _cancellationToken;
        private Service workerService;

        public MonitorLoop(
            IBackgroundTaskQueue taskQueue,
            IHostApplicationLifetime applicationLifetime)
        {
            _taskQueue = taskQueue;
            _cancellationToken = applicationLifetime.ApplicationStopping;
        }

        public async ValueTask MonitorAsync(Service workerService)
        {
            if (!_cancellationToken.IsCancellationRequested)
            {
                this.workerService = workerService;
                await _taskQueue.QueueBackgroundWorkItemAsync(BuildWorkItemAsync);
            }
        }

        private async ValueTask BuildWorkItemAsync(CancellationToken token)
        {
            await workerService.ExecuteWorkerService(token);
        }
    }
}