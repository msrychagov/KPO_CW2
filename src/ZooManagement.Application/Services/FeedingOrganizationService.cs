using System;
using ZooManagement.Application.Interfaces;
using ZooManagement.Domain.Entities;

namespace ZooManagement.Application.Services
{
    public class FeedingOrganizationService
    {
        private readonly IFeedingScheduleRepository _schedules;
        private readonly IAnimalRepository _animals;

        public FeedingOrganizationService(IFeedingScheduleRepository schedules, IAnimalRepository animals)
        {
            _schedules = schedules;
            _animals = animals;
        }

        public void ScheduleFeeding(Guid animalId, DateTime time, string foodType)
        {
            var schedule = new FeedingSchedule(animalId, time, foodType);
            _schedules.Add(schedule);
        }

        public void FeedNow(Guid scheduleId)
        {
            var schedule = _schedules.GetById(scheduleId);
            var animal = _animals.GetById(schedule.AnimalId);
            animal.Feed(schedule);
            schedule.MarkDone();
        }
    }
}
