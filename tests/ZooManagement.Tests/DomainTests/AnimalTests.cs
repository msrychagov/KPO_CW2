using System;
using Xunit;
using ZooManagement.Domain.Entities;
using ZooManagement.Domain.ValueObjects;

namespace ZooManagement.Tests.DomainTests
{
    public class AnimalTests
    {
        [Fact]
        public void NewAnimal_IsHealthyByDefault()
        {
            var a = new Animal("Lion","Leo",new DateTime(2020,1,1),Gender.Male,"Meat");
            Assert.True(a.IsHealthy);
        }
    }
}
