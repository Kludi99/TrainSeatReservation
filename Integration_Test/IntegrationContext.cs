//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Data;

namespace Integration_Test
{
    public class IntegrationContext : ApplicationDbContext
    {
        public IntegrationContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-5BTG7QB;Database=TrainSeatReservationDB;User Id=TrainReservationUser;Password=zaq1@WSX;MultipleActiveResultSets=true");
            }
        }

    }
}
