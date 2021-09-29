using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;
using TrainSeatReservation.Interfaces.Facades;
using TrainSeatReservation.Interfaces.Infrastructure.Services;

namespace TrainSeatReservation.Facades
{
    public class DiscountFcd : IDiscountFcd
    {
        private readonly IDiscountService _service;

        public DiscountFcd(IDiscountService service)
        {
            _service = service;
        }

        public List<DiscountDto> GetDiscounts()
        {
            return _service.GetDiscounts();
        }
        public DiscountDto GetDiscount(int id)
        {
            return _service.GetDiscount(id);
        }
        public void AddDiscount(DiscountDto discount)
        {
            _service.AddDiscount(discount);
        }
        public void UpdateDiscount(DiscountDto discount)
        {
            _service.UpdateDiscount(discount);
        }
        public void DeleteDiscount(int id)
        {
            _service.DeleteDiscount(id);
        }
        public bool IsDiscountExists(int id)
        {
            return _service.IsDiscountExists(id);
        }
    }
}
