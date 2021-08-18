using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrainSeatReservation.Commons;
using TrainSeatReservation.EntityFramework.Models;

namespace TrainSeatReservation.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Train> Trains { get; set; }
        public DbSet<Carriage> Carriages { get; set; }
        public DbSet<TrainCarriage> TrainCarriages { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteStation> RouteStations { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TrainStation> TrainStations { get; set; }
        public DbSet<TicketDiscount> TicketDiscounts { get; set; }

      /*  public ApplicationDbContext() : base()
        {

        }*/
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Train>().ToTable("Train").
                HasIndex(x => x.Number)
                .IsUnique();

            builder.Entity<Carriage>().ToTable("Carriage");

            builder.Entity<TrainCarriage>().ToTable("TrainCarriage");
            builder.Entity<TrainCarriage>()
                .HasOne(x => x.Carriage)
                .WithMany(x => x.TrainCarriages)
                .HasForeignKey(k => k.CarriageId);
            builder.Entity<TrainCarriage>()
                .HasOne(x => x.Train)
                .WithMany(x => x.TrainCarriages)
                .HasForeignKey(k => k.TrainId);

            builder.Entity<Discount>().ToTable("Discount");

            builder.Entity<Route>().ToTable("Route");

            builder.Entity<RouteStation>().ToTable("RouteStation")
                .HasOne(x => x.Route)
                .WithMany(x => x.RouteStations)
                .HasForeignKey(x => x.RouteId);

            builder.Entity<RouteStation>().HasIndex(i => new { i.RouteId, i.StartStationId, i.EndStationId }).IsUnique();

            builder.Entity<Station>().ToTable("Station");

            builder.Entity<Ticket>().ToTable("Ticket");
            builder.Entity<Ticket>();

            builder.Entity<TrainStation>().ToTable("TrainStation");

            builder.Entity<TicketDiscount>().ToTable("TicketDiscount")
                .HasOne(x => x.Ticket)
                .WithMany(x => x.TicketDiscounts);

            base.OnModelCreating(builder);
        }
    }
}
