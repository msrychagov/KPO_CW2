using System;
using System.Collections.Generic;
using System.Linq;
using ZooManagement.Application.Interfaces;
using ZooManagement.Domain.Entities;

namespace ZooManagement.Infrastructure.Repositories
{
    public class InMemoryFeedingScheduleRepository : IFeedingScheduleRepository
    {
        private readonly List<FeedingSchedule> _store = new();
        public void Add(FeedingSchedule schedule) => _store.Add(schedule);
        public FeedingSchedule GetById(Guid id) => _store.First(s => s.Id == id);
        public void Remove(Guid id) => _store.RemoveAll(s => s.Id == id);
        public IEnumerable<FeedingSchedule> GetAll() => _store;
    }
}
