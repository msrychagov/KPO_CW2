using System;

namespace ZooManagement.Domain.Entities
{
    public class FeedingSchedule
    {
        public Guid Id { get; private set; }
        public Guid AnimalId { get; private set; }
        public DateTime Time { get; private set; }
        public string FoodType { get; private set; }
        public bool Completed { get; private set; }

        public FeedingSchedule(Guid animalId, DateTime time, string foodType)
        {
            Id = Guid.NewGuid();
            AnimalId = animalId;
            Time = time;
            FoodType = foodType;
        }

        public void Reschedule(DateTime newTime) => Time = newTime;
        public void MarkDone() => Completed = true;
    }
}
