using Microsoft.AspNetCore.Mvc;
using ZooManagement.Application.Interfaces;
using ZooManagement.Application.Services;

namespace ZooManagement.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedingSchedulesController : ControllerBase
    {
        private readonly IFeedingScheduleRepository _repo;
        private readonly FeedingOrganizationService _service;

        public FeedingSchedulesController(IFeedingScheduleRepository repo, FeedingOrganizationService service)
        {
            _repo = repo;
            _service = service;
        }

        [HttpGet] public IActionResult GetAll() => Ok(_repo.GetAll());

        [HttpPost]
        public IActionResult Create([FromBody] ScheduleDto dto)
        {
            _service.ScheduleFeeding(dto.AnimalId, dto.Time, dto.FoodType);
            return Created("", null);
        }

        [HttpPost("feed/{id}")] public IActionResult FeedNow(Guid id) { _service.FeedNow(id); return Ok(); }
    }

    public record ScheduleDto(Guid AnimalId, DateTime Time, string FoodType);
}
