//Program powstał na Wydziale Informatyki Politechniki Białostockiej
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
        public DbSet<TicketResigned> TicketsResigned{ get; set; }
        public DbSet<TrainStation> TrainStations { get; set; }
        public DbSet<TicketDiscount> TicketDiscounts { get; set; }
        public DbSet<Dictionary> Dictionaries { get; set; }
        public DbSet<DictionaryItem> DictionaryItems { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<TrainTimeTable> TrainTimeTables { get; set; }
        public DbSet<SeatTicket> SeatTickets { get; set; }
        public DbSet<RouteTicket> RouteTickets { get; set; }
        public DbSet<TicketChange> TicketChanges { get; set; }

        public ApplicationDbContext() : base()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        
        //TODO: Create Indexes!!!!!
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);

            //  builder.Entity<Dictionary>().ToTable("Dictionary");
            // builder.Entity<DictionaryItem>().ToTable("DictionaryItem");


            //builder.Entity<Carriage>().ToTable("Carriage");
            // builder.Entity<Carriage>().HasOne(x => x.CarriageClass).WithMany(x => x.Carriages);
            // builder.Entity<Carriage>().HasOne(x => x.Type).WithMany(x => x.Carriages);

            // builder.Entity<Seat>().ToTable("Seat");
            builder.Entity<TrainStation>()
                 .HasOne(x => x.TrainTimeTable)
                 .WithMany(x => x.TrainStations)
                 .HasForeignKey(x => x.TrainTimeTableId);

            builder.Entity<Seat>()
                .HasOne(x => x.Carriage)
                .WithMany(x => x.Seats)
                .HasForeignKey(x => x.CarriageId);

            builder.Entity<TrainCarriage>()
                .HasOne(x => x.Carriage)
                .WithMany(x => x.TrainCarriages)
                .HasForeignKey(k => k.CarriageId);
            builder.Entity<TrainCarriage>()
                .HasOne(x => x.Train)
                .WithMany(x => x.TrainCarriages)
                .HasForeignKey(k => k.TrainId);

            /*  builder.Entity<Train>()
                     .HasOne(a => a.Route)
                     .WithOne(b => b.Train)
                     .HasForeignKey<Route>(b => b.TrainId)
                     .OnDelete(DeleteBehavior.Cascade);*/
            builder.Entity<Route>()
                  .HasOne(x => x.Train)
                  .WithMany(x => x.Routes)
                  .HasForeignKey(k => k.TrainId);

            // builder.Entity<Discount>().ToTable("Discount");

            //builder.Entity<Route>().ToTable("Route");

            builder.Entity<RouteStation>()
                .HasOne(x => x.Route)
                .WithMany(x => x.RouteStations)
                .HasForeignKey(x => x.RouteId);
            builder.Entity<RouteStation>()
                .HasOne(x => x.StartStation)
                .WithMany(x => x.RouteStations);

            builder.Entity<TicketDiscount>()
                .HasOne(x => x.Ticket)
                .WithMany(x => x.TicketDiscounts);

            builder.Entity<SeatTicket>()
                .HasOne(x => x.Seat)
                .WithMany(x => x.SeatTickets)
                .HasForeignKey(x => x.SeatId);

            builder.Entity<SeatTicket>()
              .HasOne(x => x.Ticket)
              .WithMany(x => x.SeatTickets)
              .HasForeignKey(x => x.TicketId);

            builder.Entity<RouteTicket>()
                .HasOne(x => x.Ticket)
                .WithMany(x => x.RouteTickets)
                .HasForeignKey(x => x.TicketId);

            builder.Entity<TicketChange>()
                .HasOne(x => x.Ticket)
                .WithMany(x => x.TicketChanges)
                .HasForeignKey(x => x.TicketId);

            //Indexes

            builder.Entity<Train>()
                .HasIndex(x => x.Number)
                .IsUnique();
            builder.Entity<RouteStation>()
                .HasIndex(i => new { i.RouteId, i.StartStationId, i.EndStationId })
                .IsUnique();
            builder.Entity<TrainTimeTable>()
                .HasIndex(i => new { i.ArrivalTime, i.DepartureTime, i.StartingDateOfTimeTable })
            .IsUnique();
            builder.Entity<TrainStation>()
                .HasIndex(i => new { i.TrainId, i.StationId, i.TrainTimeTableId, i.RouteId })
                .IsUnique();
            builder.Entity<Station>()
                .HasIndex(i => i.Name)
                .IsUnique();


            Seed seed = new Seed(builder);
            seed.Add();

            base.OnModelCreating(builder);
        }
    }
}
