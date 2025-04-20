using System;
using Xunit;
using ZooManagement.Application.Services;
using ZooManagement.Infrastructure.Repositories;
using ZooManagement.Domain.Entities;
using ZooManagement.Domain.ValueObjects;

namespace ZooManagement.Tests.ApplicationTests
{
    public class AnimalTransferServiceTests
    {
        [Fact]
        public void Transfer_MovesAnimalToNewEnclosure()
        {
            var animalRepo = new InMemoryAnimalRepository();
            var enclosureRepo = new InMemoryEnclosureRepository();
            var enc1 = new Enclosure(EnclosureType.Herbivore,100,2);
            var enc2 = new Enclosure(EnclosureType.Herbivore,100,2);
            enclosureRepo.Add(enc1);
            enclosureRepo.Add(enc2);
            var animal = new Animal("Deer","Bambi",DateTime.Now,Gender.Female,"Grass");
            animalRepo.Add(animal);
            enc1.AddAnimal(animal.Id);

            var svc = new AnimalTransferService(animalRepo,enclosureRepo);
            svc.Transfer(animal.Id, enc2.Id);

            Assert.Contains(animal.Id, enc2.AnimalIds);
            Assert.DoesNotContain(animal.Id, enc1.AnimalIds);
        }
    }
}
