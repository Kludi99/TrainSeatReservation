//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Infrastructure.Services
{
    public interface IDictionaryService
    {
        List<DictionaryDto> GetDictionaries();
        List<DictionaryItemDto> GetDictionaryItems(int dictionaryId);
        DictionaryItemDto GetDictionaryItem(int id);
        List<DictionaryItemDto> GetDictionaryItems();
        DictionaryItemDto AddDictionaryItem(DictionaryItemDto item);
        DictionaryItemDto EditDictionaryItem(DictionaryItemDto item);
        DictionaryItemDto DeleteDictionaryItem(int id);

        bool DictionaryExistInDb(int id);
        bool DictionaryItemsExistInDb(int id);
        bool DictionaryItemExistInDb(int id);

    }
}
