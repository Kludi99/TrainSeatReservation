//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Facades
{
    public interface IDiscountFcd
    {
        List<DiscountDto> GetDiscounts();
        DiscountDto GetDiscount(int id);
        void AddDiscount(DiscountDto discount);
        void UpdateDiscount(DiscountDto discount);
        void DeleteDiscount(int id);
        bool IsDiscountExists(int id);
    }
}
