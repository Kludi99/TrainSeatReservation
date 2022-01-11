//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using NUnit.Framework;
using System.Linq;
using TrainSeatReservation.EntityFramework.Models;

namespace Integration_Test
{
    public class DictionaryTest
    {
        IntegrationContext context = new IntegrationContext();
        [Test, Isolated]
        public void AddDictionaryToDB()
        {
            var dictionary = new Dictionary
            {
                Name = "Słownik"            
            };

            context.Dictionaries.Add(dictionary);
            context.SaveChanges();
            var dictionaryDB = context.Dictionaries.Where(x => x.Name == "Słownik").FirstOrDefault();
            Assert.That(dictionaryDB.Name, Is.EqualTo(dictionary.Name));
            Assert.That(dictionaryDB.Id, Is.EqualTo(dictionary.Id));
        }
        [Test, Isolated]
        public void DeleteDictionaryFromDB()
        {
            var dictionary = new Dictionary
            {
                Name = "Słownik"
            };

            context.Dictionaries.Add(dictionary);
            context.SaveChanges();
            context.Dictionaries.Remove(dictionary);
            var rowChanged = context.SaveChanges();
            Assert.That(rowChanged, Is.EqualTo(1));

        }
        [Test, Isolated]
        public void EditDictionaryInDB()
        {
            var dictionary = new Dictionary
            {
                Name = "Słownik"
            };

            context.Dictionaries.Add(dictionary);
            context.SaveChanges();
            dictionary.Name = "SłownikNowy";
            context.Dictionaries.Update(dictionary);
            int rowChanged = context.SaveChanges();
            Assert.That(rowChanged, Is.EqualTo(1));

        }
    }
}
