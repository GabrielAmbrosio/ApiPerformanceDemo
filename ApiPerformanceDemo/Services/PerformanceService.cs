using System.Diagnostics;

namespace ApiPerformanceDemo.Services
{
    public class PerformanceService
    {
        public async Task<List<string>> RunParallelTasksAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var task1 = SimulateAsyncOperation("Task 1", 2000);
            var task2 = SimulateAsyncOperation("Task 2", 3000);
            var task3 = SimulateAsyncOperation("Task 3", 1000);

            var results = await Task.WhenAll(task1, task2, task3);

            stopwatch.Stop();
            results = results.Append($"Total Time: {stopwatch.ElapsedMilliseconds} ms").ToArray();

            return results.ToList();
        }

        public async Task<List<string>> RunSecuentialTasksAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var result1 = await SimulateAsyncOperation("Task 1", 2000);
            var result2 = await SimulateAsyncOperation("Task 2", 3000);
            var result3 = await SimulateAsyncOperation("Task 3", 1000);

            stopwatch.Stop();

            var results = new List<string> { result1, result2, result3 };

            results.Add($"Total Time: {stopwatch.ElapsedMilliseconds} ms");

            return results;
        }

        private async Task<string> SimulateAsyncOperation(string name, int delay)
        {
            await Task.Delay(delay);
            return $"{name} completed in {delay} ms";
        }
    }
}
