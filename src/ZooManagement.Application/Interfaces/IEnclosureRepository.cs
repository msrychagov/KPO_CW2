using System;
using System.Collections.Generic;
using ZooManagement.Domain.Entities;

namespace ZooManagement.Application.Interfaces
{
    public interface IEnclosureRepository
    {
        Enclosure GetById(Guid id);
        void Add(Enclosure enclosure);
        void Remove(Guid id);
        IEnumerable<Enclosure> GetAll();
    }
}
