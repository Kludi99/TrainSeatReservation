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
    public class TrainTimeTableFcd : ITrainTimeTableFcd
    {
        private readonly ITrainTimeTableService _service;

        public TrainTimeTableFcd(ITrainTimeTableService service)
        {
            _service = service;
        }

        public List<TrainTimeTableDto> GetTrainTimeTables()
        {
            return _service.GetTrainTimeTables();
        }
        public TrainTimeTableDto GetTrainTimeTable(int id)
        {
            return _service.GetTrainTimeTable(id);
        }
        public void AddTrainTimeTable(TrainTimeTableDto trainTimeTable)
        {
            _service.AddTrainTimeTable(trainTimeTable);
        }
        public void UpdateTrainTimeTable(TrainTimeTableDto trainTimeTable)
        {
            _service.UpdateTrainTimeTable(trainTimeTable);
        }
        public void DeleteTrainTimeTable(int id)
        {
            _service.DeleteTrainTimeTable(id);
        }
        public bool IsTrainTimeTableExists(int id)
        {
            return _service.IsTrainTimeTableExists(id);
        }
    }
}
