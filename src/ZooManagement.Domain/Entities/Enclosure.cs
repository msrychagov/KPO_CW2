using System;
using System.Collections.Generic;
using ZooManagement.Domain.ValueObjects;

namespace ZooManagement.Domain.Entities
{
    public class Enclosure
    {
        public Guid Id { get; private set; }
        public EnclosureType Type { get; private set; }
        public double Size { get; private set; }
        public int Capacity { get; private set; }
        private readonly List<Guid> _animalIds = new();
        public IReadOnlyCollection<Guid> AnimalIds => _animalIds.AsReadOnly();
        public int CurrentCount => _animalIds.Count;

        public Enclosure(EnclosureType type, double size, int capacity)
        {
            Id = Guid.NewGuid();
            Type = type;
            Size = size;
            Capacity = capacity;
        }

        public void AddAnimal(Guid animalId)
        {
            if (CurrentCount >= Capacity)
                throw new InvalidOperationException("Enclosure is full");
            _animalIds.Add(animalId);
        }

        public void RemoveAnimal(Guid animalId)
        {
            if (!_animalIds.Remove(animalId))
                throw new InvalidOperationException("Animal not found in this enclosure");
        }

        public void Clean() { }
    }
}
