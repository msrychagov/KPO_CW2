using System;
using System.Collections.Generic;
using System.Linq;
using ZooManagement.Application.Interfaces;
using ZooManagement.Domain.Entities;

namespace ZooManagement.Infrastructure.Repositories
{
    public class InMemoryAnimalRepository : IAnimalRepository
    {
        private readonly List<Animal> _store = new();
        public void Add(Animal animal) => _store.Add(animal);
        public Animal GetById(Guid id) => _store.First(a => a.Id == id);
        public void Remove(Guid id) => _store.RemoveAll(a => a.Id == id);
        public IEnumerable<Animal> GetAll() => _store;
    }
}
