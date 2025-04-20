using System;
using System.Collections.Generic;
using ZooManagement.Domain.Entities;

namespace ZooManagement.Application.Interfaces
{
    public interface IAnimalRepository
    {
        Animal GetById(Guid id);
        void Add(Animal animal);
        void Remove(Guid id);
        IEnumerable<Animal> GetAll();
    }
}
