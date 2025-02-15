using ApiPerformanceDemo.Services;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ApiPerformanceDemo.Benchmarks
{
    public class PerformanceBenchmark
    {
        private readonly PerformanceService _service = new PerformanceService();

        [Benchmark]
        public Task RunParallelTasksAsync() => _service.RunParallelTasksAsync();

        [Benchmark]
        public Task RunSecuentialTasksAsync() => _service.RunSecuentialTasksAsync();
    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<PerformanceBenchmark>();
        }
    }
}
