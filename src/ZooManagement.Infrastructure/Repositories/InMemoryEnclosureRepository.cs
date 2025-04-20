using System;
using System.Collections.Generic;
using System.Linq;
using ZooManagement.Application.Interfaces;
using ZooManagement.Domain.Entities;

namespace ZooManagement.Infrastructure.Repositories
{
    public class InMemoryEnclosureRepository : IEnclosureRepository
    {
        private readonly List<Enclosure> _store = new();
        public void Add(Enclosure enclosure) => _store.Add(enclosure);
        public Enclosure GetById(Guid id) => _store.First(e => e.Id == id);
        public void Remove(Guid id) => _store.RemoveAll(e => e.Id == id);
        public IEnumerable<Enclosure> GetAll() => _store;
    }
}
