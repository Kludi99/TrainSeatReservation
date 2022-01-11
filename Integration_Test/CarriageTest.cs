using NUnit.Framework;
using System.Linq;
using TrainSeatReservation.EntityFramework.Models;

namespace Integration_Test
{
    public class CarriageTest
    {
        IntegrationContext context = new IntegrationContext();
        [Test, Isolated]
        public void AddCarriageToDB()
        {
            var carriage = new Carriage
            {
                CarriageClassId = 8,
                Number = 100,
                TypeId = 5
            };

            context.Carriages.Add(carriage);
            context.SaveChanges();
            var carriageDB = context.Carriages.Where(x => x.Number == 100).FirstOrDefault();
            Assert.That(carriageDB.CarriageClassId, Is.EqualTo(carriage.CarriageClassId));
            Assert.That(carriageDB.Number, Is.EqualTo(carriage.Number));
            Assert.That(carriageDB.TypeId, Is.EqualTo(carriage.TypeId));
        }
        [Test, Isolated]
        public void DeleteCarriageFromDB()
        {
            var carriage = new Carriage
            {
                CarriageClassId = 8,
                Number = 100,
                TypeId = 5
            };

            context.Carriages.Add(carriage);
            context.SaveChanges();
            context.Carriages.Remove(carriage);
            var rowChanged = context.SaveChanges();
            Assert.That(rowChanged, Is.EqualTo(1));

        }
        [Test, Isolated]
        public void EditCarriageInDB()
        {
            var carriage = new Carriage
            {
                CarriageClassId = 8,
                Number = 100,
                TypeId = 5
            };

            context.Carriages.Add(carriage);
            context.SaveChanges();
            carriage.Number = 100;
            context.Carriages.Update(carriage);
            int rowChanged = context.SaveChanges();
            Assert.That(rowChanged, Is.EqualTo(1));

        }
    }
}
