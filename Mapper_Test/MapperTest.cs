using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Mapper_Test
{
    public class Tests
    {
        [TestMethod]
        public void MapTest_MapsAddressProperly()
        {
            // Create address entity
            DomainModel.Address sourceAddress = ABB.IKC.Testing.EntityGenerator.GenerateAddress();

            // Map address Domain Model => Entity Framework
            EntityFramework.Address intermediateAddress = EntityMapper.Map<DomainModel.Address, EntityFramework.Address>(sourceAddress);

            // Map address value Entity Framework => Domain Model
            DomainModel.Address finalAddress = EntityMapper.Map<EntityFramework.Address, DomainModel.Address>(intermediateAddress);

            PropertyAssert.PropertyValuesAreEqual(sourceAddress, finalAddress);
        }
    }
}