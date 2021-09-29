using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Infrastructure.Services
{
    public interface ITrainTimeTableService
    {
        List<TrainTimeTableDto> GetTrainTimeTables();
        TrainTimeTableDto GetTrainTimeTable(int id);
        void AddTrainTimeTable(TrainTimeTableDto trainTimeTable);
        void UpdateTrainTimeTable(TrainTimeTableDto trainTimeTable);
        void DeleteTrainTimeTable(int id);
        bool IsTrainTimeTableExists(int id);
    }
}
