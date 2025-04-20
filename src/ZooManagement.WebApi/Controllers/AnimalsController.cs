using Microsoft.AspNetCore.Mvc;
using ZooManagement.Application.Interfaces;
using ZooManagement.Domain.Entities;
using ZooManagement.Domain.ValueObjects;

namespace ZooManagement.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalRepository _repo;
        public AnimalsController(IAnimalRepository repo) => _repo = repo;

        [HttpGet] public IActionResult GetAll() => Ok(_repo.GetAll());
        [HttpGet("{id}")] public IActionResult Get(Guid id) => Ok(_repo.GetById(id));

        [HttpPost]
        public IActionResult Create([FromBody] AnimalDto dto)
        {
            var animal = new Animal(dto.Species, dto.Name, dto.DateOfBirth, dto.Gender, dto.FavoriteFood);
            _repo.Add(animal);
            return CreatedAtAction(nameof(Get), new { id = animal.Id }, animal);
        }

        [HttpDelete("{id}")] public IActionResult Delete(Guid id) { _repo.Remove(id); return NoContent(); }
    }

    public record AnimalDto(string Species, string Name, DateTime DateOfBirth, Gender Gender, string FavoriteFood);
}
