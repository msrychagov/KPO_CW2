// src/ZooManagement.Application/Services/AnimalTransferService.cs
using System;
using ZooManagement.Application.Interfaces;
using ZooManagement.Domain.Entities;

namespace ZooManagement.Application.Services
{
    public class AnimalTransferService
    {
        private readonly IAnimalRepository _animals;
        private readonly IEnclosureRepository _enclosures;

        public AnimalTransferService(IAnimalRepository animals, IEnclosureRepository enclosures)
        {
            _animals = animals;
            _enclosures = enclosures;
        }

        public void Transfer(Guid animalId, Guid toEnclosureId)
        {
            // 1. Удаляем животное из любых вольеров, где оно может быть
            foreach (var enc in _enclosures.GetAll())
            {
                if (enc.AnimalIds.Contains(animalId))
                    enc.RemoveAnimal(animalId);
            }

            // 2. Кладём в целевой вольер
            var target = _enclosures.GetById(toEnclosureId);
            target.AddAnimal(animalId);

            // 3. Сообщаем доменной модели, что животное переехало
            var animal = _animals.GetById(animalId);
            animal.MoveTo(toEnclosureId);
        }
    }
}