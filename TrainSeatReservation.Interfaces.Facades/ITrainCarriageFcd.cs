using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Facades
{
    public interface ITrainCarriageFcd
    {
        List<TrainCarriageDto> GetTrainCarriages();
        TrainCarriageDto GetTrainCarriage(int id);
        void AddTrainCarriage(TrainCarriageDto trainCarriage);
        void UpdateTrainCarriage(TrainCarriageDto trainCarriage);
        void DeleteTrainCarriage(int id);
        bool IsTrainCarriageExists(int id);
    }
}
