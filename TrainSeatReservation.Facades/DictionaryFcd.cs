using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.CustomLogs;
using TrainSeatReservation.Commons.Dto;
using TrainSeatReservation.Interfaces.Facades;
using TrainSeatReservation.Interfaces.Infrastructure.Services;

namespace TrainSeatReservation.Facades
{
    public class DictionaryFcd : IDictionaryFcd
    {
        private readonly IDictionaryService _dictionaryService;
        public DictionaryFcd(IDictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
        }
        public List<DictionaryDto> GetDictionaries()
        {
            return _dictionaryService.GetDictionaries();
        }

        public List<DictionaryItemDto> GetDictionaryItems(int dictionaryId)
        {
            return _dictionaryService.GetDictionaryItems(dictionaryId);
        }
        public DictionaryItemDto GetDictionaryItem(int id)
        {
            return _dictionaryService.GetDictionaryItem(id);
        }

        public List<DictionaryItemDto> GetDictionaryItems()
        {
            return _dictionaryService.GetDictionaryItems();
        }

        public DictionaryItemDto AddDictionaryItem(DictionaryItemDto item)
        {
            if (!_dictionaryService.DictionaryExistInDb(item.DictionaryId))
            {
                throw new InvalidOperationException(CustomException.DictionaryDoesNotExistInDb);
            }
            if (_dictionaryService.DictionaryItemExistInDb(item.Id))
            {
                throw new InvalidOperationException(CustomException.DictionaryItemExistsInDb);
            }
            return _dictionaryService.AddDictionaryItem(item);

        }

        public DictionaryItemDto EditDictionaryItem(DictionaryItemDto item)
        {
            if (!_dictionaryService.DictionaryItemExistInDb(item.Id))
            {
                throw new InvalidOperationException(CustomException.DictionaryItemDoesNotExistInDb);
            }
            return _dictionaryService.EditDictionaryItem(item);
        }

        public DictionaryItemDto DeleteDictionaryItem(int id)
        {
            if (!_dictionaryService.DictionaryItemExistInDb(id))
            {
                throw new InvalidOperationException(CustomException.DictionaryItemDoesNotExistInDb);
            }
            return _dictionaryService.DeleteDictionaryItem(id);
        }

        public bool DictionaryExistInDb(int id)
        {
            return _dictionaryService.DictionaryExistInDb(id);
        }
        public bool DictionaryItemsExistInDb(int id)
        {
            return _dictionaryService.DictionaryItemsExistInDb(id);
        }
        public bool DictionaryItemExistInDb(int id)
        {
            return _dictionaryService.DictionaryItemExistInDb(id);
        }
    }
}
