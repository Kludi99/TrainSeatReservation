//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.CustomLogs
{
    public static class CustomException
    {
        public const string UserExistsInDb = "User exists in database";
        public const string UserDoesNotExistInDb = "User does not exist in database";
        public const string DictionaryDoesNotExistInDb = "Dictionary does not exist in database";
        public const string DictionaryItemDoesNotExistInDb = "Dictionary item does not exist in database";
        public const string DictionaryItemsDoNotExistInDb = "Dictionary items do not exist in database";
        public const string DictionaryItemExistsInDb = "Dictionary item exists in database";
    }
}
