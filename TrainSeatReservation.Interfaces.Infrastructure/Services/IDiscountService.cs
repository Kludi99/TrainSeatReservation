﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Infrastructure.Services
{
    public interface IDiscountService
    {
        List<DiscountDto> GetDiscounts();
        DiscountDto GetDiscount(int id);
        void AddDiscount(DiscountDto discount);
        void UpdateDiscount(DiscountDto discount);
        void DeleteDiscount(int id);
        bool IsDiscountExists(int id);
    }
}
