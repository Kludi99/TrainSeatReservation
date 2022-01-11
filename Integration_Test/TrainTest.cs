using NUnit.Framework;
using System.Linq;
using TrainSeatReservation.EntityFramework.Models;

namespace Integration_Test
{
    public class TrainTests
    {
        IntegrationContext context = new IntegrationContext();
        [Test, Isolated]
        public void AddTrainToDB()
        {
            var train = new Train
            {
                Name = "Name",
                Number = "12345",
                TypeId = 1
            };

            context.Trains.Add(train);
            context.SaveChanges();
            var trainDB = context.Trains.Where(x => x.Name == "Name").FirstOrDefault();
            Assert.That(trainDB.Name, Is.EqualTo(train.Name));
            Assert.That(trainDB.Number, Is.EqualTo(train.Number));
            Assert.That(trainDB.TypeId, Is.EqualTo(train.TypeId));
        }
        [Test, Isolated]
        public void DeleteTrainFromDB()
        {
            var train = new Train
            {
                Name = "Name",
                Number = "12345",
                TypeId = 1
            };

            context.Trains.Add(train);
            context.SaveChanges();
            context.Trains.Remove(train);
            var rowChanged = context.SaveChanges();
            Assert.That(rowChanged, Is.EqualTo(1));

        }
        [Test, Isolated]
        public void EditTrainInDB()
        {
            var train = new Train
            {
                Name = "Name",
                Number = "12345",
                TypeId = 1
            };

            context.Trains.Add(train);
            context.SaveChanges();
            train.Number = "0123";
            context.Trains.Update(train);
            int rowChanged = context.SaveChanges();
            Assert.That(rowChanged, Is.EqualTo(1));

        }
    }
}