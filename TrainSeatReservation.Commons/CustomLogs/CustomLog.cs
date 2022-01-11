//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.CustomLogs
{
    public static class CustomLog
    {
        public static string LogInfo(string methodName)
        {
            return "Executing " + methodName + " service method";
        }
        public static string ErrorInfo(string methodName, string message)
        {
            return "Error in  " + methodName + " - " + message;
        }
    }
}
