using System;

namespace ZooManagement.Domain.Events
{
    public record AnimalMovedEvent(Guid AnimalId, Guid TargetEnclosureId);
}
