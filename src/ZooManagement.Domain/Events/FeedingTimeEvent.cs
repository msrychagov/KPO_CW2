using System;

namespace ZooManagement.Domain.Events
{
    public record FeedingTimeEvent(Guid AnimalId, string FoodType, DateTime Time);
}
