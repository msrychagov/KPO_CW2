using System.Linq;
using ZooManagement.Application.Interfaces;

namespace ZooManagement.Application.Services
{
    public class ZooStatisticsService
    {
        private readonly IAnimalRepository _animals;
        private readonly IEnclosureRepository _enclosures;

        public ZooStatisticsService(IAnimalRepository animals, IEnclosureRepository enclosures)
        {
            _animals = animals;
            _enclosures = enclosures;
        }

        public int TotalAnimals() => _animals.GetAll().Count();
        public int TotalEnclosures() => _enclosures.GetAll().Count();
        public int FreeSlots() => _enclosures.GetAll().Sum(e => e.Capacity - e.CurrentCount);
    }
}
