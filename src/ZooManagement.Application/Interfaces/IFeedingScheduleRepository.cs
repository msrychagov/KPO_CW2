using System;
using System.Collections.Generic;
using ZooManagement.Domain.Entities;

namespace ZooManagement.Application.Interfaces
{
    public interface IFeedingScheduleRepository
    {
        FeedingSchedule GetById(Guid id);
        void Add(FeedingSchedule schedule);
        void Remove(Guid id);
        IEnumerable<FeedingSchedule> GetAll();
    }
}
