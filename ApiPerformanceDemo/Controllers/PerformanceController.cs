using ApiPerformanceDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiPerformanceDemo.Controllers
{
    [ApiController]
    [Route("api/performance")]
    public class PerformanceController : ControllerBase
    {
        private readonly PerformanceService _service;

        public PerformanceController()
        {
            _service = new PerformanceService();
        }

        [HttpGet("parallel-tasks")]
        public async Task<IActionResult> GetParallelTasks()
        {
            var parallelTask = _service.RunParallelTasksAsync();
            var sequentialTask = _service.RunSecuentialTasksAsync();

            await Task.WhenAll(parallelTask, sequentialTask);

            var parallelResult = await parallelTask;
            var sequentialResult = await sequentialTask;

            var combinedResult = new
            {
                ParallelResults = parallelResult,
                SequentialResults = sequentialResult
            };

            return Ok(combinedResult);
        }
    }
}
