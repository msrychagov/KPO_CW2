using System;
using ZooManagement.Domain.Events;
using ZooManagement.Domain.ValueObjects;

namespace ZooManagement.Domain.Entities
{
    public class Animal
    {
        public Guid Id { get; private set; }
        public string Species { get; private set; }
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Gender Gender { get; private set; }
        public string FavoriteFood { get; private set; }
        public bool IsHealthy { get; private set; }
        public Guid? EnclosureId { get; private set; }

        public Animal(string species, string name, DateTime dob, Gender gender, string favoriteFood)
        {
            Id = Guid.NewGuid();
            Species = species;
            Name = name;
            DateOfBirth = dob;
            Gender = gender;
            FavoriteFood = favoriteFood;
            IsHealthy = true;
        }

        public void Feed(FeedingSchedule schedule)
        {
            if (schedule.AnimalId != Id)
                throw new InvalidOperationException("Schedule does not match this animal");
            DomainEvents.Raise(new FeedingTimeEvent(Id, schedule.FoodType, schedule.Time));
        }

        public void Heal() => IsHealthy = true;

        public void MoveTo(Guid targetEnclosureId)
        {
            EnclosureId = targetEnclosureId;
            DomainEvents.Raise(new AnimalMovedEvent(Id, targetEnclosureId));
        }
    }
}
