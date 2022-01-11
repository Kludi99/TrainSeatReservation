using NUnit.Framework;
using System.Linq;
using TrainSeatReservation.EntityFramework.Models;


namespace Integration_Test
{
    class DictionaryItemTest
    {
        IntegrationContext context = new IntegrationContext();
        [Test, Isolated]
        public void AddDictionaryItemToDB()
        {
            var dictionaryItem = new DictionaryItem
            {
                Name = "Item",
                DictionaryId = 1
            };

            context.DictionaryItems.Add(dictionaryItem);
            context.SaveChanges();
            var dictionaryItemDB = context.DictionaryItems.Where(x => x.Name == "Item").FirstOrDefault();
            Assert.That(dictionaryItemDB.Name, Is.EqualTo(dictionaryItem.Name));
            Assert.That(dictionaryItemDB.Id, Is.EqualTo(dictionaryItem.Id));
            Assert.That(dictionaryItemDB.DictionaryId, Is.EqualTo(dictionaryItem.DictionaryId));
        }
        [Test, Isolated]
        public void DeleteDictionaryItemFromDB()
        {
            var dictionaryItem = new DictionaryItem
            {
                Name = "Item",
                DictionaryId = 1
            };

            context.DictionaryItems.Add(dictionaryItem);
            context.SaveChanges();
            context.DictionaryItems.Remove(dictionaryItem);
            var rowChanged = context.SaveChanges();
            Assert.That(rowChanged, Is.EqualTo(1));

        }
        [Test, Isolated]
        public void EditDictionaryItemInDB()
        {
            var dictionaryItem = new DictionaryItem
            {
                Name = "Item",
                DictionaryId = 1
            };

            context.DictionaryItems.Add(dictionaryItem);
            context.SaveChanges();
            dictionaryItem.Name = "ItemNowy";
            context.DictionaryItems.Update(dictionaryItem);
            int rowChanged = context.SaveChanges();
            Assert.That(rowChanged, Is.EqualTo(1));

        }
    }
}
