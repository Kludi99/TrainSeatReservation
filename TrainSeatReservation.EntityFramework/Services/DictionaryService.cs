using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.CustomLogs;
using TrainSeatReservation.Commons.Dto;
using TrainSeatReservation.Data;
using TrainSeatReservation.EntityFramework.Models;
using TrainSeatReservation.Interfaces.Facades;
using TrainSeatReservation.Interfaces.Infrastructure.Services;

namespace TrainSeatReservation.EntityFramework.Services
{
    public class DictionaryService :IDictionaryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public DictionaryService(ApplicationDbContext context,
                                IMapper mapper,
                                ILogger<DictionaryService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public DictionaryItemDto AddDictionaryItem(DictionaryItemDto item)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(CustomLog.LogInfo(m.Name));

            var result = _context.DictionaryItems.OrderBy(x => x.Id).LastOrDefault(x => x.DictionaryId == item.DictionaryId);


            if (result == null)
            {
                item.Id = item.DictionaryId * 1000;
            }
            else
            {
                item.Id = result.Id + 1;
            }
            _context.DictionaryItems.Add(_mapper.Map<DictionaryItem>(item));
            _context.SaveChanges();
            return item;

        }

        public DictionaryItemDto DeleteDictionaryItem(int id)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(CustomLog.LogInfo(m.Name));

            var result = _context.DictionaryItems.SingleOrDefault(x => x.Id == id);
            _context.DictionaryItems.Remove(result);
            _context.SaveChanges();

            return _mapper.Map<DictionaryItemDto>(result);

        }
        public DictionaryItemDto GetDictionaryItem(int id)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(CustomLog.LogInfo(m.Name));

            var result = _context.DictionaryItems.SingleOrDefault(x => x.Id == id);

            return _mapper.Map<DictionaryItemDto>(result);

        }

        public DictionaryItemDto EditDictionaryItem(DictionaryItemDto item)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(CustomLog.LogInfo(m.Name));
            _context.DictionaryItems.Update(_mapper.Map<DictionaryItem>(item));
            _context.SaveChanges();
            return item;
        }

        public List<DictionaryDto> GetDictionaries()
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(CustomLog.LogInfo(m.Name));

            return GetDictionariesQuery().ToList();
        }

        public List<DictionaryItemDto> GetDictionaryItems(int dictionaryId)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(CustomLog.LogInfo(m.Name));

            return GetDictionaryItemsQuery(dictionaryId).ToList();
        }

        public List<DictionaryItemDto> GetDictionaryItems()
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(CustomLog.LogInfo(m.Name));

            return GetDictionaryItemsQuery().ToList();
        }

        private IEnumerable<DictionaryDto> GetDictionariesQuery()
        {
            var result = _context.Dictionaries.AsNoTracking();

            return _mapper.Map<DictionaryDto[]>(result);

        }
        private IEnumerable<DictionaryItemDto> GetDictionaryItemsQuery()
        {

            var result = _context.DictionaryItems.AsNoTracking();

            return _mapper.Map<DictionaryItemDto[]>(result);


        }
        private IEnumerable<DictionaryItemDto> GetDictionaryItemsQuery(int dictionaryId)
        {

            var result = _context.DictionaryItems.AsNoTracking().Where(x => x.DictionaryId == dictionaryId);

            return _mapper.Map<DictionaryItemDto[]>(result);


        }

        public bool DictionaryExistInDb(int Id)
        {
            return _context.Dictionaries.Any(x => x.Id == Id);
        }
        public bool DictionaryItemsExistInDb(int Id)
        {
            return _context.DictionaryItems.Any(x => x.DictionaryId == Id);
        }
        public bool DictionaryItemExistInDb(int Id)
        {
            return _context.DictionaryItems.Any(x => x.Id == Id);
        }

    }
}
