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
            var result = await _service.RunParallelTasksAsync();
            return Ok(result);
        }
    }
}
