using ApiPerformanceDemo.Services;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ApiPerformanceDemo.Benchmarks
{
    public class PerformanceBenchmark
    {
        private readonly PerformanceService _service = new PerformanceService();

        [Benchmark]
        public async Task RunParallelTasksAsync() => await _service.RunParallelTasksAsync();
    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<PerformanceBenchmark>();
        }
    }
}
