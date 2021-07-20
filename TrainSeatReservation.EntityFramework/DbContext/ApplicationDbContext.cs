using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrainSeatReservation.EntityFramework.Models;

namespace TrainSeatReservation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Train> Trains { get; set; }
        public DbSet<Carriage> Carriages { get; set; }
        public DbSet<TrainCarriage> TrainCarriages { get; set; }

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


            base.OnModelCreating(builder);
        }
    }
}
