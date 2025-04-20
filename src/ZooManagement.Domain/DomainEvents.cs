using System;

namespace ZooManagement.Domain
{
    public static class DomainEvents
    {
        public static Action<object>? Handlers { get; set; }

        public static void Raise<T>(T @event)
        {
            Handlers?.Invoke(@event!);
        }
    }
}
