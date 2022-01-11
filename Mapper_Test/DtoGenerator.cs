using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace Mapper_Test
{
    public static class DtoGenerator
    {
        public static List<CarriageDto> GenerateCarriagesDto()
        {
            var carriages = new List<CarriageDto>();
            carriages.Add(new CarriageDto { Id = 1, IsActive = true, Number = 1, CarriageClassId = 7, TypeId = 6, EletricalOutlet = true, BicyclePlace = true });
            carriages.Add(new CarriageDto { Id = 2, IsActive = true, Number = 2, CarriageClassId = 7, TypeId = 5 });
            carriages.Add(new CarriageDto { Id = 3, IsActive = true, Number = 3, CarriageClassId = 7, TypeId = 5 });
            carriages.Add(new CarriageDto { Id = 4, IsActive = true, Number = 4, CarriageClassId = 7, TypeId = 5, BicyclePlace = true });
            carriages.Add(new CarriageDto { Id = 5, IsActive = true, Number = 5, CarriageClassId = 7, TypeId = 5 });
            carriages.Add(new CarriageDto { Id = 6, IsActive = true, Number = 6, CarriageClassId = 8, TypeId = 5 });
            carriages.Add(new CarriageDto { Id = 7, IsActive = true, Number = 7, CarriageClassId = 8, TypeId = 5, BicyclePlace = true });
            carriages.Add(new CarriageDto { Id = 8, IsActive = true, Number = 8, CarriageClassId = 8, TypeId = 5 });
            carriages.Add(new CarriageDto { Id = 9, IsActive = true, Number = 9, CarriageClassId = 8, TypeId = 5 });
            carriages.Add(new CarriageDto { Id = 10, IsActive = true, Number = 10, CarriageClassId = 8, TypeId = 5 });
            carriages.Add(new CarriageDto { Id = 11, IsActive = true, Number = 1, CarriageClassId = 8, TypeId = 6, EletricalOutlet = true });
            carriages.Add(new CarriageDto { Id = 12, IsActive = true, Number = 2, CarriageClassId = 8, TypeId = 6, EletricalOutlet = true });
            carriages.Add(new CarriageDto { Id = 13, IsActive = true, Number = 3, CarriageClassId = 8, TypeId = 6, EletricalOutlet = true });
            carriages.Add(new CarriageDto { Id = 14, IsActive = true, Number = 4, CarriageClassId = 8, TypeId = 6, EletricalOutlet = true });
            carriages.Add(new CarriageDto { Id = 15, IsActive = true, Number = 5, CarriageClassId = 8, TypeId = 6, EletricalOutlet = true });
            carriages.Add(new CarriageDto { Id = 16, IsActive = true, Number = 6, CarriageClassId = 7, TypeId = 6, EletricalOutlet = true });
            carriages.Add(new CarriageDto { Id = 17, IsActive = true, Number = 7, CarriageClassId = 7, TypeId = 6, EletricalOutlet = true });

            return carriages;
        }
    }
}
