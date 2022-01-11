//Program powstał na Wydziale Informatyki Politechniki Białostockiej
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
using TrainSeatReservation.Interfaces.Infrastructure.Services;

namespace TrainSeatReservation.EntityFramework.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public DiscountService(ApplicationDbContext context,
                                IMapper mapper,
                                ILogger<DiscountService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public void AddDiscount(DiscountDto item)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(CustomLog.LogInfo(m.Name));

            var result = _context.Discounts.OrderBy(x => x.Id).LastOrDefault(x => x.Id == item.Id);

            _context.Discounts.Add(_mapper.Map<Discount>(item));
            _context.SaveChanges();
        }

        public void DeleteDiscount(int id)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(CustomLog.LogInfo(m.Name));

            var result = _context.Discounts.SingleOrDefault(x => x.Id == id);
            _context.Discounts.Remove(result);
            _context.SaveChanges();

        }
        public DiscountDto GetDiscount(int id)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(CustomLog.LogInfo(m.Name));

            var result = _context.Discounts.SingleOrDefault(x => x.Id == id);

            return _mapper.Map<DiscountDto>(result);

        }

        public void UpdateDiscount(DiscountDto item)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(CustomLog.LogInfo(m.Name));
            _context.Discounts.Update(_mapper.Map<Discount>(item));
            _context.SaveChanges();
         
        }

        public List<DiscountDto> GetDiscounts()
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(CustomLog.LogInfo(m.Name));

            return GetDiscountsQuery().ToList();
        }
        public bool IsDiscountExists(int Id)
        {
            return _context.Discounts.Any(x => x.Id == Id);
        }

        private IEnumerable<DiscountDto> GetDiscountsQuery()
        {
            var result = _context.Discounts.AsNoTracking();

            return _mapper.Map<DiscountDto[]>(result);

        }
    }
}
