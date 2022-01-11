//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Facades
{
    public interface ITrainFcd
    {
        List<TrainDto> GetTrains();
        TrainDto GetTrain(int id);
        void AddTrain(TrainDto train);
        void AddTrainWithCarriages(TrainDto train, int compartmentless, int compartmental);
        void UpdateTrain(TrainDto train);
        void DeleteTrain(int id);
        bool IsTrainExists(int id);
    }
}
