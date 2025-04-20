using Microsoft.AspNetCore.Mvc;
using ZooManagement.Application.Interfaces;
using ZooManagement.Domain.Entities;
using ZooManagement.Domain.ValueObjects;

namespace ZooManagement.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnclosuresController : ControllerBase
    {
        private readonly IEnclosureRepository _repo;
        public EnclosuresController(IEnclosureRepository repo) => _repo = repo;

        [HttpGet] public IActionResult GetAll() => Ok(_repo.GetAll());
        [HttpGet("{id}")] public IActionResult Get(Guid id) => Ok(_repo.GetById(id));

        [HttpPost]
        public IActionResult Create([FromBody] EnclosureDto dto)
        {
            var enc = new Enclosure(dto.Type, dto.Size, dto.Capacity);
            _repo.Add(enc);
            return CreatedAtAction(nameof(Get), new { id = enc.Id }, enc);
        }

        [HttpDelete("{id}")] public IActionResult Delete(Guid id) { _repo.Remove(id); return NoContent(); }
    }

    public record EnclosureDto(EnclosureType Type, double Size, int Capacity);
}
