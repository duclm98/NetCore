using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore.API.QueueService.WorkerService.ProductWorkerService
{
    public class GetProductWorkerService : IWorkerServiceStrategy
    {
        public async ValueTask WorkerService(CancellationToken token)
        {
            var guid = Guid.NewGuid();
            Console.WriteLine($"Queued Background Task {guid} is starting.");

            Console.WriteLine("Da xem danh sach san pham");
            await Task.Delay(TimeSpan.FromMilliseconds(1), token);

            Console.WriteLine($"Queued Background Task {guid} is complete.");
        }
    }
}