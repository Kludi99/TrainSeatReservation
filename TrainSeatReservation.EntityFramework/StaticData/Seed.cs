using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainSeatReservation.EntityFramework.Models;

namespace TrainSeatReservation.Data
{
    public class Seed
    {
        private readonly ModelBuilder modelBuilder;

        public Seed(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void Add()
        {
            Roles();
            Dictionaries();
            DictionaryItems();
            Carriages();
            Trains();
            TrainCarriages();
            Seats();
            Discounts();
            TrainTimeTables();
            TrainStations();
            Stations();
            Routes();
            RouteStations();
        }
        private void Roles()
        {
            var adminRole = new IdentityRole("Admin");
            adminRole.NormalizedName = adminRole.Name.ToUpper();
            var clientRole = new IdentityRole("Client");
            clientRole.NormalizedName = clientRole.Name.ToUpper();


            modelBuilder.Entity<IdentityRole>().HasData(
                adminRole,
                clientRole
                );
        }
        private void Dictionaries()
        {
            modelBuilder.Entity<Dictionary>().HasData(
                new Dictionary { Id = 1, Name = "Train Type" },
                new Dictionary { Id = 2, Name = "Carriage Type" },
                new Dictionary { Id = 3, Name = "Carriage Class" },
                new Dictionary { Id = 4, Name = "Seat Type" });
        }
        private void DictionaryItems()
        {
            modelBuilder.Entity<DictionaryItem>().HasData(
                new DictionaryItem { Id = 1, Name = "IC", DictionaryId = 1},
                new DictionaryItem { Id = 2, Name = "EIC", DictionaryId = 1},
                new DictionaryItem { Id = 3, Name = "EIP", DictionaryId = 1},
                new DictionaryItem { Id = 4, Name = "POLREGIO", DictionaryId = 1},
                new DictionaryItem { Id = 5, Name = "Przedziałowy", DictionaryId = 2},
                new DictionaryItem { Id = 6, Name = "Bezprzedziałowy", DictionaryId = 2},
                new DictionaryItem { Id = 7, Name = "1 klasa", DictionaryId = 3},
                new DictionaryItem { Id = 8, Name = "2 klasa", DictionaryId = 3},
                new DictionaryItem { Id = 9, Name = "Okno", DictionaryId = 4},
                new DictionaryItem { Id = 10, Name = "Korytarz", DictionaryId = 4},
                new DictionaryItem { Id = 11, Name = "Środek", DictionaryId = 4},
                new DictionaryItem { Id = 12, Name = "Przy stoliku", DictionaryId = 4}
                );
        }
        private void Carriages()
        {
            modelBuilder.Entity<Carriage>().HasData(
                new Carriage { Id = 1, IsActive = true, Number = 1, CarriageClassId = 7, TypeId = 6  },
                new Carriage { Id = 2, IsActive = true, Number = 2, CarriageClassId = 7, TypeId = 5  },
                new Carriage { Id = 3, IsActive = true, Number = 3, CarriageClassId = 7, TypeId = 5  },
                new Carriage { Id = 4, IsActive = true, Number = 4, CarriageClassId = 7, TypeId = 5  },
                new Carriage { Id = 5, IsActive = true, Number = 5, CarriageClassId = 7, TypeId = 5  },
                new Carriage { Id = 6, IsActive = true, Number = 6, CarriageClassId = 8, TypeId = 5  },
                new Carriage { Id = 7, IsActive = true, Number = 7, CarriageClassId = 8, TypeId = 5  },
                new Carriage { Id = 8, IsActive = true, Number = 8, CarriageClassId = 8, TypeId = 5  },
                new Carriage { Id = 9, IsActive = true, Number = 9, CarriageClassId = 8, TypeId = 5  },
                new Carriage { Id = 10, IsActive = true, Number = 10, CarriageClassId = 8, TypeId = 5  },
                new Carriage { Id = 11, IsActive = true, Number = 1, CarriageClassId = 8, TypeId = 6  },
                new Carriage { Id = 12, IsActive = true, Number = 2, CarriageClassId = 8, TypeId = 6  },
                new Carriage { Id = 13, IsActive = true, Number = 3, CarriageClassId = 8, TypeId = 6  },
                new Carriage { Id = 14, IsActive = true, Number = 4, CarriageClassId = 8, TypeId = 6  },
                new Carriage { Id = 15, IsActive = true, Number = 5, CarriageClassId = 8, TypeId = 6  },
                new Carriage { Id = 16, IsActive = true, Number = 6, CarriageClassId = 7, TypeId = 6  },
                new Carriage { Id = 17, IsActive = true, Number = 7, CarriageClassId = 7, TypeId = 6  }
                );
        }
        private void Trains()
        {
            modelBuilder.Entity<Train>().HasData(
                new Train { Id = 1, IsActive = true, Name = "Nałkowska", Number = "IC 10221", TypeId = 1  },
                new Train { Id = 2, IsActive = true, Name = "Hańcza", Number = "IC 10511", TypeId = 1  },
                new Train { Id = 3, IsActive = true, Name = "Karkonosze", Number = "IC 23441", TypeId = 1  }
                );
        }
        private void TrainCarriages()
        {
            modelBuilder.Entity<TrainCarriage>().HasData(
                new TrainCarriage { Id = 1, TrainId = 1, CarriageId = 1  },
                new TrainCarriage { Id = 2, TrainId = 1, CarriageId = 6  },
                new TrainCarriage { Id = 3, TrainId = 1, CarriageId = 7  },
                new TrainCarriage { Id = 4, TrainId = 1, CarriageId = 9  },
                new TrainCarriage { Id = 5, TrainId = 1, CarriageId = 12  },

                new TrainCarriage { Id = 6, TrainId = 2, CarriageId = 2 },
                new TrainCarriage { Id = 7, TrainId = 2, CarriageId = 3 },
                new TrainCarriage { Id = 8, TrainId = 2, CarriageId = 10 },
                new TrainCarriage { Id = 9, TrainId = 2, CarriageId = 11 },
                new TrainCarriage { Id = 10, TrainId = 2, CarriageId = 13 },
                new TrainCarriage { Id = 11, TrainId = 2, CarriageId = 17 },

                new TrainCarriage { Id = 12, TrainId = 3, CarriageId = 4 },
                new TrainCarriage { Id = 13, TrainId = 3, CarriageId = 5 },
                new TrainCarriage { Id = 14, TrainId = 3, CarriageId = 8 },
                new TrainCarriage { Id = 15, TrainId = 3, CarriageId = 14 },
                new TrainCarriage { Id = 16, TrainId = 3, CarriageId = 15 },
                new TrainCarriage { Id = 17, TrainId = 3, CarriageId = 16 }
                );
        }
        private void Seats()
        {
            modelBuilder.Entity<Seat>().HasData(
                new Seat { Id = 1, Number = 1, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 2, Number = 3, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 3, Number = 5, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 4, Number = 7, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 5, Number = 9, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 6, Number = 11, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 7, Number = 13, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 8, Number = 15, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 9, Number = 17, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 10, Number = 19, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 11, Number = 21, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 12, Number = 23, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 13, Number = 25, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 14, Number = 27, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 15, Number = 29, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 16, Number = 31, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 17, Number = 33, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 18, Number = 35, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 19, Number = 37, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 20, Number = 39, IsFree = true, SeatTypeId = 9, CarriageId = 1 },
                new Seat { Id = 21, Number = 2, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 22, Number = 4, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 23, Number = 6, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 24, Number = 8, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 25, Number = 10, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 26, Number = 12, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 27, Number = 14, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 28, Number = 16, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 29, Number = 18, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 30, Number = 20, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 31, Number = 22, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 32, Number = 24, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 33, Number = 26, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 34, Number = 28, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 35, Number = 30, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 36, Number = 32, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 37, Number = 34, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 38, Number = 36, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 39, Number = 38, IsFree = true, SeatTypeId = 10, CarriageId = 1 },
                new Seat { Id = 40, Number = 40, IsFree = true, SeatTypeId = 10, CarriageId = 1 },

                new Seat { Id = 41, Number = 10, IsFree = true, SeatTypeId = 9, CarriageId = 2},
                new Seat { Id = 42, Number = 11, IsFree = true, SeatTypeId = 10, CarriageId = 2},
                new Seat { Id = 43, Number = 12, IsFree = true, SeatTypeId = 11, CarriageId = 2},
                new Seat { Id = 44, Number = 13, IsFree = true, SeatTypeId = 9, CarriageId = 2},
                new Seat { Id = 45, Number = 14, IsFree = true, SeatTypeId = 10, CarriageId = 2 },
                new Seat { Id = 46, Number = 15, IsFree = true, SeatTypeId = 11, CarriageId = 2 },
                new Seat { Id = 47, Number = 20, IsFree = true, SeatTypeId = 9, CarriageId = 2 },
                new Seat { Id = 48, Number = 21, IsFree = true, SeatTypeId = 10, CarriageId = 2 },
                new Seat { Id = 49, Number = 22, IsFree = true, SeatTypeId = 11, CarriageId = 2 },
                new Seat { Id = 50, Number = 23, IsFree = true, SeatTypeId = 9, CarriageId = 2 },
                new Seat { Id = 51, Number = 24, IsFree = true, SeatTypeId = 10, CarriageId = 2 },
                new Seat { Id = 52, Number = 25, IsFree = true, SeatTypeId = 11, CarriageId = 2 },
                new Seat { Id = 53, Number = 30, IsFree = true, SeatTypeId = 9, CarriageId = 2 },
                new Seat { Id = 54, Number = 31, IsFree = true, SeatTypeId = 10, CarriageId = 2 },
                new Seat { Id = 55, Number = 32, IsFree = true, SeatTypeId = 11, CarriageId = 2 },
                new Seat { Id = 56, Number = 33, IsFree = true, SeatTypeId = 9, CarriageId = 2 },
                new Seat { Id = 57, Number = 34, IsFree = true, SeatTypeId = 10, CarriageId = 2 },
                new Seat { Id = 58, Number = 35, IsFree = true, SeatTypeId = 11, CarriageId = 2 },
                new Seat { Id = 59, Number = 40, IsFree = true, SeatTypeId = 9, CarriageId = 2 },
                new Seat { Id = 60, Number = 41, IsFree = true, SeatTypeId = 10, CarriageId = 2 },
                new Seat { Id = 61, Number = 42, IsFree = true, SeatTypeId = 11, CarriageId = 2 },
                new Seat { Id = 62, Number = 43, IsFree = true, SeatTypeId = 9, CarriageId = 2 },
                new Seat { Id = 63, Number = 44, IsFree = true, SeatTypeId = 10, CarriageId = 2 },
                new Seat { Id = 64, Number = 45, IsFree = true, SeatTypeId = 11, CarriageId = 2 },
                new Seat { Id = 65, Number = 50, IsFree = true, SeatTypeId = 9, CarriageId = 2 },
                new Seat { Id = 66, Number = 51, IsFree = true, SeatTypeId = 10, CarriageId = 2 },
                new Seat { Id = 67, Number = 52, IsFree = true, SeatTypeId = 11, CarriageId = 2 },
                new Seat { Id = 68, Number = 53, IsFree = true, SeatTypeId = 9, CarriageId = 2 },
                new Seat { Id = 69, Number = 54, IsFree = true, SeatTypeId = 10, CarriageId = 2 },
                new Seat { Id = 70, Number = 55, IsFree = true, SeatTypeId = 11, CarriageId = 2 },

                new Seat { Id = 71, Number = 10, IsFree = true, SeatTypeId = 9, CarriageId = 3 },
                new Seat { Id = 72, Number = 11, IsFree = true, SeatTypeId = 10, CarriageId = 3 },
                new Seat { Id = 73, Number = 12, IsFree = true, SeatTypeId = 11, CarriageId = 3 },
                new Seat { Id = 74, Number = 13, IsFree = true, SeatTypeId = 9, CarriageId = 3 },
                new Seat { Id = 75, Number = 14, IsFree = true, SeatTypeId = 10, CarriageId = 3 },
                new Seat { Id = 76, Number = 15, IsFree = true, SeatTypeId = 11, CarriageId = 3 },
                new Seat { Id = 77, Number = 20, IsFree = true, SeatTypeId = 9, CarriageId = 3 },
                new Seat { Id = 78, Number = 21, IsFree = true, SeatTypeId = 10, CarriageId = 3 },
                new Seat { Id = 79, Number = 22, IsFree = true, SeatTypeId = 11, CarriageId = 3 },
                new Seat { Id = 80, Number = 23, IsFree = true, SeatTypeId = 9, CarriageId = 3 },
                new Seat { Id = 81, Number = 24, IsFree = true, SeatTypeId = 10, CarriageId = 3 },
                new Seat { Id = 82, Number = 25, IsFree = true, SeatTypeId = 11, CarriageId = 3 },
                new Seat { Id = 83, Number = 30, IsFree = true, SeatTypeId = 9, CarriageId = 3 },
                new Seat { Id = 84, Number = 31, IsFree = true, SeatTypeId = 10, CarriageId = 3 },
                new Seat { Id = 85, Number = 32, IsFree = true, SeatTypeId = 11, CarriageId = 3 },
                new Seat { Id = 86, Number = 33, IsFree = true, SeatTypeId = 9, CarriageId = 3 },
                new Seat { Id = 87, Number = 34, IsFree = true, SeatTypeId = 10, CarriageId = 3 },
                new Seat { Id = 88, Number = 35, IsFree = true, SeatTypeId = 11, CarriageId = 3 },
                new Seat { Id = 89, Number = 40, IsFree = true, SeatTypeId = 9, CarriageId = 3 },
                new Seat { Id = 90, Number = 41, IsFree = true, SeatTypeId = 10, CarriageId = 3 },
                new Seat { Id = 91, Number = 42, IsFree = true, SeatTypeId = 11, CarriageId = 3 },
                new Seat { Id = 92, Number = 43, IsFree = true, SeatTypeId = 9, CarriageId = 3 },
                new Seat { Id = 93, Number = 44, IsFree = true, SeatTypeId = 10, CarriageId = 3 },
                new Seat { Id = 94, Number = 45, IsFree = true, SeatTypeId = 11, CarriageId = 3 },
                new Seat { Id = 95, Number = 50, IsFree = true, SeatTypeId = 9, CarriageId = 3 },
                new Seat { Id = 96, Number = 51, IsFree = true, SeatTypeId = 10, CarriageId = 3 },
                new Seat { Id = 97, Number = 52, IsFree = true, SeatTypeId = 11, CarriageId = 3 },
                new Seat { Id = 98, Number = 53, IsFree = true, SeatTypeId = 9, CarriageId = 3 },
                new Seat { Id = 99, Number = 54, IsFree = true, SeatTypeId = 10, CarriageId = 3 },
                new Seat { Id = 100, Number = 55, IsFree = true, SeatTypeId = 11, CarriageId = 3 },

                new Seat { Id = 101, Number = 10, IsFree = true, SeatTypeId = 9, CarriageId = 4 },
                new Seat { Id = 102, Number = 11, IsFree = true, SeatTypeId = 10, CarriageId = 4 },
                new Seat { Id = 103, Number = 12, IsFree = true, SeatTypeId = 11, CarriageId = 4 },
                new Seat { Id = 104, Number = 13, IsFree = true, SeatTypeId = 9, CarriageId = 4 },
                new Seat { Id = 105, Number = 14, IsFree = true, SeatTypeId = 10, CarriageId = 4 },
                new Seat { Id = 106, Number = 15, IsFree = true, SeatTypeId = 11, CarriageId = 4 },
                new Seat { Id = 107, Number = 20, IsFree = true, SeatTypeId = 9, CarriageId = 4 },
                new Seat { Id = 108, Number = 21, IsFree = true, SeatTypeId = 10, CarriageId = 4 },
                new Seat { Id = 109, Number = 22, IsFree = true, SeatTypeId = 11, CarriageId = 4 },
                new Seat { Id = 110, Number = 23, IsFree = true, SeatTypeId = 9, CarriageId = 4 },
                new Seat { Id = 111, Number = 24, IsFree = true, SeatTypeId = 10, CarriageId = 4 },
                new Seat { Id = 112, Number = 25, IsFree = true, SeatTypeId = 11, CarriageId = 4 },
                new Seat { Id = 113, Number = 30, IsFree = true, SeatTypeId = 9, CarriageId = 4 },
                new Seat { Id = 114, Number = 31, IsFree = true, SeatTypeId = 10, CarriageId = 4 },
                new Seat { Id = 115, Number = 32, IsFree = true, SeatTypeId = 11, CarriageId = 4 },
                new Seat { Id = 116, Number = 33, IsFree = true, SeatTypeId = 9, CarriageId = 4 },
                new Seat { Id = 117, Number = 34, IsFree = true, SeatTypeId = 10, CarriageId = 4 },
                new Seat { Id = 118, Number = 35, IsFree = true, SeatTypeId = 11, CarriageId = 4 },
                new Seat { Id = 119, Number = 40, IsFree = true, SeatTypeId = 9, CarriageId = 4 },
                new Seat { Id = 120, Number = 41, IsFree = true, SeatTypeId = 10, CarriageId = 4 },
                new Seat { Id = 121, Number = 42, IsFree = true, SeatTypeId = 11, CarriageId = 4 },
                new Seat { Id = 122, Number = 43, IsFree = true, SeatTypeId = 9, CarriageId = 4 },
                new Seat { Id = 123, Number = 44, IsFree = true, SeatTypeId = 10, CarriageId = 4 },
                new Seat { Id = 124, Number = 45, IsFree = true, SeatTypeId = 11, CarriageId = 4 },
                new Seat { Id = 125, Number = 50, IsFree = true, SeatTypeId = 9, CarriageId = 4 },
                new Seat { Id = 126, Number = 51, IsFree = true, SeatTypeId = 10, CarriageId = 4 },
                new Seat { Id = 127, Number = 52, IsFree = true, SeatTypeId = 11, CarriageId = 4 },
                new Seat { Id = 128, Number = 53, IsFree = true, SeatTypeId = 9, CarriageId = 4 },
                new Seat { Id = 129, Number = 54, IsFree = true, SeatTypeId = 10, CarriageId = 4 },
                new Seat { Id = 130, Number = 55, IsFree = true, SeatTypeId = 11, CarriageId = 4 },

                new Seat { Id = 131, Number = 10, IsFree = true, SeatTypeId = 9, CarriageId = 5 },
                new Seat { Id = 132, Number = 11, IsFree = true, SeatTypeId = 10, CarriageId = 5 },
                new Seat { Id = 133, Number = 12, IsFree = true, SeatTypeId = 11, CarriageId = 5 },
                new Seat { Id = 134, Number = 13, IsFree = true, SeatTypeId = 9, CarriageId = 5 },
                new Seat { Id = 135, Number = 14, IsFree = true, SeatTypeId = 10, CarriageId = 5 },
                new Seat { Id = 136, Number = 15, IsFree = true, SeatTypeId = 11, CarriageId = 5 },
                new Seat { Id = 137, Number = 20, IsFree = true, SeatTypeId = 9, CarriageId = 5 },
                new Seat { Id = 138, Number = 21, IsFree = true, SeatTypeId = 10, CarriageId = 5 },
                new Seat { Id = 139, Number = 22, IsFree = true, SeatTypeId = 11, CarriageId = 5 },
                new Seat { Id = 140, Number = 23, IsFree = true, SeatTypeId = 9, CarriageId = 5 },
                new Seat { Id = 141, Number = 24, IsFree = true, SeatTypeId = 10, CarriageId = 5 },
                new Seat { Id = 142, Number = 25, IsFree = true, SeatTypeId = 11, CarriageId = 5 },
                new Seat { Id = 143, Number = 30, IsFree = true, SeatTypeId = 9, CarriageId = 5 },
                new Seat { Id = 144, Number = 31, IsFree = true, SeatTypeId = 10, CarriageId = 5 },
                new Seat { Id = 145, Number = 32, IsFree = true, SeatTypeId = 11, CarriageId = 5 },
                new Seat { Id = 146, Number = 33, IsFree = true, SeatTypeId = 9, CarriageId = 5 },
                new Seat { Id = 147, Number = 34, IsFree = true, SeatTypeId = 10, CarriageId = 5 },
                new Seat { Id = 148, Number = 35, IsFree = true, SeatTypeId = 11, CarriageId = 5 },
                new Seat { Id = 149, Number = 40, IsFree = true, SeatTypeId = 9, CarriageId = 5 },
                new Seat { Id = 150, Number = 41, IsFree = true, SeatTypeId = 10, CarriageId = 5 },
                new Seat { Id = 151, Number = 42, IsFree = true, SeatTypeId = 11, CarriageId = 5 },
                new Seat { Id = 152, Number = 43, IsFree = true, SeatTypeId = 9, CarriageId = 5 },
                new Seat { Id = 153, Number = 44, IsFree = true, SeatTypeId = 10, CarriageId = 5 },
                new Seat { Id = 154, Number = 45, IsFree = true, SeatTypeId = 11, CarriageId = 5 },
                new Seat { Id = 155, Number = 50, IsFree = true, SeatTypeId = 9, CarriageId = 5 },
                new Seat { Id = 156, Number = 51, IsFree = true, SeatTypeId = 10, CarriageId = 5 },
                new Seat { Id = 157, Number = 52, IsFree = true, SeatTypeId = 11, CarriageId = 5 },
                new Seat { Id = 158, Number = 53, IsFree = true, SeatTypeId = 9, CarriageId = 5 },
                new Seat { Id = 159, Number = 54, IsFree = true, SeatTypeId = 10, CarriageId = 5 },
                new Seat { Id = 160, Number = 55, IsFree = true, SeatTypeId = 11, CarriageId = 5 },

                new Seat { Id = 161, Number = 10, IsFree = true, SeatTypeId = 9, CarriageId = 6 },
                new Seat { Id = 162, Number = 11, IsFree = true, SeatTypeId = 10, CarriageId = 6 },
                new Seat { Id = 163, Number = 12, IsFree = true, SeatTypeId = 11, CarriageId = 6 },
                new Seat { Id = 164, Number = 13, IsFree = true, SeatTypeId = 9, CarriageId = 6 },
                new Seat { Id = 165, Number = 14, IsFree = true, SeatTypeId = 10, CarriageId = 6 },
                new Seat { Id = 166, Number = 15, IsFree = true, SeatTypeId = 11, CarriageId = 6 },
                new Seat { Id = 167, Number = 20, IsFree = true, SeatTypeId = 9, CarriageId = 6 },
                new Seat { Id = 168, Number = 21, IsFree = true, SeatTypeId = 10, CarriageId = 6 },
                new Seat { Id = 169, Number = 22, IsFree = true, SeatTypeId = 11, CarriageId = 6 },
                new Seat { Id = 170, Number = 23, IsFree = true, SeatTypeId = 9, CarriageId = 6 },
                new Seat { Id = 171, Number = 24, IsFree = true, SeatTypeId = 10, CarriageId = 6 },
                new Seat { Id = 172, Number = 25, IsFree = true, SeatTypeId = 11, CarriageId = 6 },
                new Seat { Id = 173, Number = 30, IsFree = true, SeatTypeId = 9, CarriageId = 6 },
                new Seat { Id = 174, Number = 31, IsFree = true, SeatTypeId = 10, CarriageId = 6 },
                new Seat { Id = 175, Number = 32, IsFree = true, SeatTypeId = 11, CarriageId = 6 },
                new Seat { Id = 176, Number = 33, IsFree = true, SeatTypeId = 9, CarriageId = 6 },
                new Seat { Id = 177, Number = 34, IsFree = true, SeatTypeId = 10, CarriageId = 6 },
                new Seat { Id = 178, Number = 35, IsFree = true, SeatTypeId = 11, CarriageId = 6 },
                new Seat { Id = 179, Number = 40, IsFree = true, SeatTypeId = 9, CarriageId = 6 },
                new Seat { Id = 180, Number = 41, IsFree = true, SeatTypeId = 10, CarriageId = 6 },
                new Seat { Id = 181, Number = 42, IsFree = true, SeatTypeId = 11, CarriageId = 6 },
                new Seat { Id = 182, Number = 43, IsFree = true, SeatTypeId = 9, CarriageId = 6 },
                new Seat { Id = 183, Number = 44, IsFree = true, SeatTypeId = 10, CarriageId = 6 },
                new Seat { Id = 184, Number = 45, IsFree = true, SeatTypeId = 11, CarriageId = 6 },
                new Seat { Id = 185, Number = 50, IsFree = true, SeatTypeId = 9, CarriageId = 6 },
                new Seat { Id = 186, Number = 51, IsFree = true, SeatTypeId = 10, CarriageId = 6 },
                new Seat { Id = 187, Number = 52, IsFree = true, SeatTypeId = 11, CarriageId = 6 },
                new Seat { Id = 188, Number = 53, IsFree = true, SeatTypeId = 9, CarriageId = 6 },
                new Seat { Id = 189, Number = 54, IsFree = true, SeatTypeId = 10, CarriageId = 6 },
                new Seat { Id = 190, Number = 55, IsFree = true, SeatTypeId = 11, CarriageId = 6 },

                new Seat { Id = 191, Number = 10, IsFree = true, SeatTypeId = 9, CarriageId = 7 },
                new Seat { Id = 192, Number = 11, IsFree = true, SeatTypeId = 10, CarriageId = 7 },
                new Seat { Id = 193, Number = 12, IsFree = true, SeatTypeId = 11, CarriageId = 7 },
                new Seat { Id = 194, Number = 13, IsFree = true, SeatTypeId = 9, CarriageId = 7 },
                new Seat { Id = 195, Number = 14, IsFree = true, SeatTypeId = 10, CarriageId = 7 },
                new Seat { Id = 196, Number = 15, IsFree = true, SeatTypeId = 11, CarriageId = 7 },
                new Seat { Id = 197, Number = 20, IsFree = true, SeatTypeId = 9, CarriageId = 7 },
                new Seat { Id = 198, Number = 21, IsFree = true, SeatTypeId = 10, CarriageId = 7 },
                new Seat { Id = 199, Number = 22, IsFree = true, SeatTypeId = 11, CarriageId = 7 },
                new Seat { Id = 200, Number = 23, IsFree = true, SeatTypeId = 9, CarriageId = 7 },
                new Seat { Id = 201, Number = 24, IsFree = true, SeatTypeId = 10, CarriageId = 7 },
                new Seat { Id = 202, Number = 25, IsFree = true, SeatTypeId = 11, CarriageId = 7 },
                new Seat { Id = 203, Number = 30, IsFree = true, SeatTypeId = 9, CarriageId = 7 },
                new Seat { Id = 204, Number = 31, IsFree = true, SeatTypeId = 10, CarriageId = 7 },
                new Seat { Id = 205, Number = 32, IsFree = true, SeatTypeId = 11, CarriageId = 7 },
                new Seat { Id = 206, Number = 33, IsFree = true, SeatTypeId = 9, CarriageId = 7 },
                new Seat { Id = 207, Number = 34, IsFree = true, SeatTypeId = 10, CarriageId = 7 },
                new Seat { Id = 208, Number = 35, IsFree = true, SeatTypeId = 11, CarriageId = 7 },
                new Seat { Id = 209, Number = 40, IsFree = true, SeatTypeId = 9, CarriageId = 7 },
                new Seat { Id = 210, Number = 41, IsFree = true, SeatTypeId = 10, CarriageId = 7 },
                new Seat { Id = 211, Number = 42, IsFree = true, SeatTypeId = 11, CarriageId = 7 },
                new Seat { Id = 212, Number = 43, IsFree = true, SeatTypeId = 9, CarriageId = 7 },
                new Seat { Id = 213, Number = 44, IsFree = true, SeatTypeId = 10, CarriageId = 7 },
                new Seat { Id = 214, Number = 45, IsFree = true, SeatTypeId = 11, CarriageId = 7 },
                new Seat { Id = 215, Number = 50, IsFree = true, SeatTypeId = 9, CarriageId = 7 },
                new Seat { Id = 216, Number = 51, IsFree = true, SeatTypeId = 10, CarriageId = 7 },
                new Seat { Id = 217, Number = 52, IsFree = true, SeatTypeId = 11, CarriageId = 7 },
                new Seat { Id = 218, Number = 53, IsFree = true, SeatTypeId = 9, CarriageId = 7 },
                new Seat { Id = 219, Number = 54, IsFree = true, SeatTypeId = 10, CarriageId = 7 },
                new Seat { Id = 220, Number = 55, IsFree = true, SeatTypeId = 11, CarriageId = 7 },

                new Seat { Id = 221, Number = 10, IsFree = true, SeatTypeId = 9, CarriageId = 8 },
                new Seat { Id = 222, Number = 11, IsFree = true, SeatTypeId = 10, CarriageId = 8 },
                new Seat { Id = 223, Number = 12, IsFree = true, SeatTypeId = 11, CarriageId = 8 },
                new Seat { Id = 224, Number = 13, IsFree = true, SeatTypeId = 9, CarriageId = 8 },
                new Seat { Id = 225, Number = 14, IsFree = true, SeatTypeId = 10, CarriageId = 8 },
                new Seat { Id = 226, Number = 15, IsFree = true, SeatTypeId = 11, CarriageId = 8 },
                new Seat { Id = 227, Number = 20, IsFree = true, SeatTypeId = 9, CarriageId = 8 },
                new Seat { Id = 228, Number = 21, IsFree = true, SeatTypeId = 10, CarriageId = 8 },
                new Seat { Id = 229, Number = 22, IsFree = true, SeatTypeId = 11, CarriageId = 8 },
                new Seat { Id = 230, Number = 23, IsFree = true, SeatTypeId = 9, CarriageId = 8 },
                new Seat { Id = 231, Number = 24, IsFree = true, SeatTypeId = 10, CarriageId = 8 },
                new Seat { Id = 232, Number = 25, IsFree = true, SeatTypeId = 11, CarriageId = 8 },
                new Seat { Id = 233, Number = 30, IsFree = true, SeatTypeId = 9, CarriageId = 8 },
                new Seat { Id = 234, Number = 31, IsFree = true, SeatTypeId = 10, CarriageId = 8 },
                new Seat { Id = 235, Number = 32, IsFree = true, SeatTypeId = 11, CarriageId = 8 },
                new Seat { Id = 236, Number = 33, IsFree = true, SeatTypeId = 9, CarriageId = 8 },
                new Seat { Id = 237, Number = 34, IsFree = true, SeatTypeId = 10, CarriageId = 8 },
                new Seat { Id = 238, Number = 35, IsFree = true, SeatTypeId = 11, CarriageId = 8 },
                new Seat { Id = 239, Number = 40, IsFree = true, SeatTypeId = 9, CarriageId = 8 },
                new Seat { Id = 240, Number = 41, IsFree = true, SeatTypeId = 10, CarriageId = 8 },
                new Seat { Id = 241, Number = 42, IsFree = true, SeatTypeId = 11, CarriageId = 8 },
                new Seat { Id = 242, Number = 43, IsFree = true, SeatTypeId = 9, CarriageId = 8 },
                new Seat { Id = 243, Number = 44, IsFree = true, SeatTypeId = 10, CarriageId = 8 },
                new Seat { Id = 244, Number = 45, IsFree = true, SeatTypeId = 11, CarriageId = 8 },
                new Seat { Id = 245, Number = 50, IsFree = true, SeatTypeId = 9, CarriageId = 8 },
                new Seat { Id = 246, Number = 51, IsFree = true, SeatTypeId = 10, CarriageId = 8 },
                new Seat { Id = 247, Number = 52, IsFree = true, SeatTypeId = 11, CarriageId = 8 },
                new Seat { Id = 248, Number = 53, IsFree = true, SeatTypeId = 9, CarriageId = 8 },
                new Seat { Id = 249, Number = 54, IsFree = true, SeatTypeId = 10, CarriageId = 8 },
                new Seat { Id = 250, Number = 55, IsFree = true, SeatTypeId = 11, CarriageId = 8 },

                new Seat { Id = 251, Number = 10, IsFree = true, SeatTypeId = 9, CarriageId = 9 },
                new Seat { Id = 252, Number = 11, IsFree = true, SeatTypeId = 10, CarriageId = 9 },
                new Seat { Id = 253, Number = 12, IsFree = true, SeatTypeId = 11, CarriageId = 9 },
                new Seat { Id = 254, Number = 13, IsFree = true, SeatTypeId = 9, CarriageId = 9 },
                new Seat { Id = 255, Number = 14, IsFree = true, SeatTypeId = 10, CarriageId = 9 },
                new Seat { Id = 256, Number = 15, IsFree = true, SeatTypeId = 11, CarriageId = 9 },
                new Seat { Id = 257, Number = 20, IsFree = true, SeatTypeId = 9, CarriageId = 9 },
                new Seat { Id = 258, Number = 21, IsFree = true, SeatTypeId = 10, CarriageId = 9 },
                new Seat { Id = 259, Number = 22, IsFree = true, SeatTypeId = 11, CarriageId = 9 },
                new Seat { Id = 260, Number = 23, IsFree = true, SeatTypeId = 9, CarriageId = 9 },
                new Seat { Id = 261, Number = 24, IsFree = true, SeatTypeId = 10, CarriageId = 9 },
                new Seat { Id = 262, Number = 25, IsFree = true, SeatTypeId = 11, CarriageId = 9 },
                new Seat { Id = 263, Number = 30, IsFree = true, SeatTypeId = 9, CarriageId = 9 },
                new Seat { Id = 264, Number = 31, IsFree = true, SeatTypeId = 10, CarriageId = 9 },
                new Seat { Id = 265, Number = 32, IsFree = true, SeatTypeId = 11, CarriageId = 9 },
                new Seat { Id = 266, Number = 33, IsFree = true, SeatTypeId = 9, CarriageId = 9 },
                new Seat { Id = 267, Number = 34, IsFree = true, SeatTypeId = 10, CarriageId = 9 },
                new Seat { Id = 268, Number = 35, IsFree = true, SeatTypeId = 11, CarriageId = 9 },
                new Seat { Id = 269, Number = 40, IsFree = true, SeatTypeId = 9, CarriageId = 9 },
                new Seat { Id = 270, Number = 41, IsFree = true, SeatTypeId = 10, CarriageId = 9 },
                new Seat { Id = 271, Number = 42, IsFree = true, SeatTypeId = 11, CarriageId = 9 },
                new Seat { Id = 272, Number = 43, IsFree = true, SeatTypeId = 9, CarriageId = 9 },
                new Seat { Id = 273, Number = 44, IsFree = true, SeatTypeId = 10, CarriageId = 9 },
                new Seat { Id = 274, Number = 45, IsFree = true, SeatTypeId = 11, CarriageId = 9 },
                new Seat { Id = 275, Number = 50, IsFree = true, SeatTypeId = 9, CarriageId = 9 },
                new Seat { Id = 276, Number = 51, IsFree = true, SeatTypeId = 10, CarriageId = 9 },
                new Seat { Id = 277, Number = 52, IsFree = true, SeatTypeId = 11, CarriageId = 9 },
                new Seat { Id = 278, Number = 53, IsFree = true, SeatTypeId = 9, CarriageId = 9 },
                new Seat { Id = 279, Number = 54, IsFree = true, SeatTypeId = 10, CarriageId = 9 },
                new Seat { Id = 280, Number = 55, IsFree = true, SeatTypeId = 11, CarriageId = 9 },

                new Seat { Id = 281, Number = 10, IsFree = true, SeatTypeId = 9, CarriageId = 10 },
                new Seat { Id = 282, Number = 11, IsFree = true, SeatTypeId = 10, CarriageId = 10 },
                new Seat { Id = 283, Number = 12, IsFree = true, SeatTypeId = 11, CarriageId = 10 },
                new Seat { Id = 284, Number = 13, IsFree = true, SeatTypeId = 9, CarriageId = 10 },
                new Seat { Id = 285, Number = 14, IsFree = true, SeatTypeId = 10, CarriageId = 10 },
                new Seat { Id = 286, Number = 15, IsFree = true, SeatTypeId = 11, CarriageId = 10 },
                new Seat { Id = 287, Number = 20, IsFree = true, SeatTypeId = 9, CarriageId = 10 },
                new Seat { Id = 288, Number = 21, IsFree = true, SeatTypeId = 10, CarriageId = 10 },
                new Seat { Id = 289, Number = 22, IsFree = true, SeatTypeId = 11, CarriageId = 10 },
                new Seat { Id = 290, Number = 23, IsFree = true, SeatTypeId = 9, CarriageId = 10 },
                new Seat { Id = 291, Number = 24, IsFree = true, SeatTypeId = 10, CarriageId = 10 },
                new Seat { Id = 292, Number = 25, IsFree = true, SeatTypeId = 11, CarriageId = 10 },
                new Seat { Id = 293, Number = 30, IsFree = true, SeatTypeId = 9, CarriageId = 10 },
                new Seat { Id = 294, Number = 31, IsFree = true, SeatTypeId = 10, CarriageId = 10 },
                new Seat { Id = 295, Number = 32, IsFree = true, SeatTypeId = 11, CarriageId = 10 },
                new Seat { Id = 296, Number = 33, IsFree = true, SeatTypeId = 9, CarriageId = 10 },
                new Seat { Id = 297, Number = 34, IsFree = true, SeatTypeId = 10, CarriageId = 10 },
                new Seat { Id = 298, Number = 35, IsFree = true, SeatTypeId = 11, CarriageId = 10 },
                new Seat { Id = 299, Number = 40, IsFree = true, SeatTypeId = 9, CarriageId = 10 },
                new Seat { Id = 300, Number = 41, IsFree = true, SeatTypeId = 10, CarriageId = 10 },
                new Seat { Id = 301, Number = 42, IsFree = true, SeatTypeId = 11, CarriageId = 10 },
                new Seat { Id = 302, Number = 43, IsFree = true, SeatTypeId = 9, CarriageId = 10 },
                new Seat { Id = 303, Number = 44, IsFree = true, SeatTypeId = 10, CarriageId = 10 },
                new Seat { Id = 304, Number = 45, IsFree = true, SeatTypeId = 11, CarriageId = 10 },
                new Seat { Id = 305, Number = 50, IsFree = true, SeatTypeId = 9, CarriageId = 10 },
                new Seat { Id = 306, Number = 51, IsFree = true, SeatTypeId = 10, CarriageId = 10 },
                new Seat { Id = 307, Number = 52, IsFree = true, SeatTypeId = 11, CarriageId = 10 },
                new Seat { Id = 308, Number = 53, IsFree = true, SeatTypeId = 9, CarriageId = 10 },
                new Seat { Id = 309, Number = 54, IsFree = true, SeatTypeId = 10, CarriageId = 10 },
                new Seat { Id = 310, Number = 55, IsFree = true, SeatTypeId = 11, CarriageId = 10 },

                new Seat { Id = 311, Number = 1, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 312, Number = 3, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 313, Number = 5, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 314, Number = 7, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 315, Number = 9, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 316, Number = 11, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 317, Number = 13, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 318, Number = 15, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 319, Number = 17, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 320, Number = 19, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 321, Number = 21, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 322, Number = 23, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 323, Number = 25, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 324, Number = 27, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 325, Number = 29, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 326, Number = 31, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 327, Number = 33, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 328, Number = 35, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 329, Number = 37, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 330, Number = 39, IsFree = true, SeatTypeId = 9, CarriageId = 11 },
                new Seat { Id = 331, Number = 2, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 332, Number = 4, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 333, Number = 6, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 334, Number = 8, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 335, Number = 10, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 336, Number = 12, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 337, Number = 14, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 338, Number = 16, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 339, Number = 18, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 340, Number = 20, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 341, Number = 22, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 342, Number = 24, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 343, Number = 26, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 344, Number = 28, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 345, Number = 30, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 346, Number = 32, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 347, Number = 34, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 348, Number = 36, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 349, Number = 38, IsFree = true, SeatTypeId = 10, CarriageId = 11 },
                new Seat { Id = 350, Number = 40, IsFree = true, SeatTypeId = 10, CarriageId = 11 },

                new Seat { Id = 351, Number = 1, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 352, Number = 3, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 353, Number = 5, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 354, Number = 7, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 355, Number = 9, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 356, Number = 11, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 357, Number = 13, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 358, Number = 15, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 359, Number = 17, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 360, Number = 19, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 361, Number = 21, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 362, Number = 23, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 363, Number = 25, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 364, Number = 27, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 365, Number = 29, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 366, Number = 31, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 367, Number = 33, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 368, Number = 35, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 369, Number = 37, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 370, Number = 39, IsFree = true, SeatTypeId = 9, CarriageId = 12 },
                new Seat { Id = 371, Number = 2, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 372, Number = 4, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 373, Number = 6, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 374, Number = 8, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 375, Number = 10, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 376, Number = 12, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 377, Number = 14, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 378, Number = 16, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 379, Number = 18, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 380, Number = 20, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 381, Number = 22, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 382, Number = 24, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 383, Number = 26, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 384, Number = 28, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 385, Number = 30, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 386, Number = 32, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 387, Number = 34, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 388, Number = 36, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 389, Number = 38, IsFree = true, SeatTypeId = 10, CarriageId = 12 },
                new Seat { Id = 390, Number = 40, IsFree = true, SeatTypeId = 10, CarriageId = 12 },

                new Seat { Id = 391, Number = 1, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 392, Number = 3, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 393, Number = 5, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 394, Number = 7, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 395, Number = 9, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 396, Number = 11, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 397, Number = 13, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 398, Number = 15, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 399, Number = 17, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 400, Number = 19, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 401, Number = 21, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 402, Number = 23, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 403, Number = 25, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 404, Number = 27, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 405, Number = 29, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 406, Number = 31, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 407, Number = 33, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 408, Number = 35, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 409, Number = 37, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 410, Number = 39, IsFree = true, SeatTypeId = 9, CarriageId = 13 },
                new Seat { Id = 411, Number = 2, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 412, Number = 4, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 413, Number = 6, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 414, Number = 8, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 415, Number = 10, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 416, Number = 12, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 417, Number = 14, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 418, Number = 16, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 419, Number = 18, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 420, Number = 20, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 421, Number = 22, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 422, Number = 24, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 423, Number = 26, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 424, Number = 28, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 425, Number = 30, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 426, Number = 32, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 427, Number = 34, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 428, Number = 36, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 429, Number = 38, IsFree = true, SeatTypeId = 10, CarriageId = 13 },
                new Seat { Id = 430, Number = 40, IsFree = true, SeatTypeId = 10, CarriageId = 13 },

                new Seat { Id = 431, Number = 1, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 432, Number = 3, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 433, Number = 5, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 434, Number = 7, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 435, Number = 9, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 436, Number = 11, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 437, Number = 13, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 438, Number = 15, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 439, Number = 17, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 440, Number = 19, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 441, Number = 21, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 442, Number = 23, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 443, Number = 25, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 444, Number = 27, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 445, Number = 29, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 446, Number = 31, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 447, Number = 33, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 448, Number = 35, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 449, Number = 37, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 450, Number = 39, IsFree = true, SeatTypeId = 9, CarriageId = 14 },
                new Seat { Id = 451, Number = 2, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 452, Number = 4, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 453, Number = 6, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 454, Number = 8, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 455, Number = 10, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 456, Number = 12, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 457, Number = 14, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 458, Number = 16, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 459, Number = 18, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 460, Number = 20, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 461, Number = 22, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 462, Number = 24, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 463, Number = 26, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 464, Number = 28, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 465, Number = 30, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 466, Number = 32, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 467, Number = 34, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 468, Number = 36, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 469, Number = 38, IsFree = true, SeatTypeId = 10, CarriageId = 14 },
                new Seat { Id = 470, Number = 40, IsFree = true, SeatTypeId = 10, CarriageId = 14 },

                new Seat { Id = 471, Number = 1, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 472, Number = 3, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 473, Number = 5, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 474, Number = 7, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 475, Number = 9, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 476, Number = 11, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 477, Number = 13, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 478, Number = 15, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 479, Number = 17, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 480, Number = 19, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 481, Number = 21, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 482, Number = 23, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 483, Number = 25, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 484, Number = 27, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 485, Number = 29, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 486, Number = 31, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 487, Number = 33, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 488, Number = 35, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 489, Number = 37, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 490, Number = 39, IsFree = true, SeatTypeId = 9, CarriageId = 15 },
                new Seat { Id = 491, Number = 2, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 492, Number = 4, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 493, Number = 6, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 494, Number = 8, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 495, Number = 10, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 496, Number = 12, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 497, Number = 14, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 498, Number = 16, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 499, Number = 18, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 500, Number = 20, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 501, Number = 22, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 502, Number = 24, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 503, Number = 26, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 504, Number = 28, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 505, Number = 30, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 506, Number = 32, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 507, Number = 34, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 508, Number = 36, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 509, Number = 38, IsFree = true, SeatTypeId = 10, CarriageId = 15 },
                new Seat { Id = 510, Number = 40, IsFree = true, SeatTypeId = 10, CarriageId = 15 },

                new Seat { Id = 511, Number = 1, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 512, Number = 3, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 513, Number = 5, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 514, Number = 7, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 515, Number = 9, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 516, Number = 11, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 517, Number = 13, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 518, Number = 15, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 519, Number = 17, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 520, Number = 19, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 521, Number = 21, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 522, Number = 23, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 523, Number = 25, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 524, Number = 27, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 525, Number = 29, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 526, Number = 31, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 527, Number = 33, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 528, Number = 35, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 529, Number = 37, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 530, Number = 39, IsFree = true, SeatTypeId = 9, CarriageId = 16 },
                new Seat { Id = 531, Number = 2, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 532, Number = 4, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 533, Number = 6, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 534, Number = 8, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 535, Number = 10, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 536, Number = 12, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 537, Number = 14, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 538, Number = 16, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 539, Number = 18, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 540, Number = 20, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 541, Number = 22, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 542, Number = 24, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 543, Number = 26, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 544, Number = 28, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 545, Number = 30, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 546, Number = 32, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 547, Number = 34, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 548, Number = 36, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 549, Number = 38, IsFree = true, SeatTypeId = 10, CarriageId = 16 },
                new Seat { Id = 550, Number = 40, IsFree = true, SeatTypeId = 10, CarriageId = 16 },

                new Seat { Id = 551, Number = 1, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 552, Number = 3, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 553, Number = 5, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 554, Number = 7, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 555, Number = 9, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 556, Number = 11, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 557, Number = 13, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 558, Number = 15, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 559, Number = 17, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 560, Number = 19, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 561, Number = 21, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 562, Number = 23, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 563, Number = 25, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 564, Number = 27, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 565, Number = 29, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 566, Number = 31, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 567, Number = 33, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 568, Number = 35, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 569, Number = 37, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 570, Number = 39, IsFree = true, SeatTypeId = 9, CarriageId = 17 },
                new Seat { Id = 571, Number = 2, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 572, Number = 4, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 573, Number = 6, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 574, Number = 8, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 575, Number = 10, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 576, Number = 12, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 577, Number = 14, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 578, Number = 16, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 579, Number = 18, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 580, Number = 20, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 581, Number = 22, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 582, Number = 24, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 583, Number = 26, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 584, Number = 28, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 585, Number = 30, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 586, Number = 32, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 587, Number = 34, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 588, Number = 36, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 589, Number = 38, IsFree = true, SeatTypeId = 10, CarriageId = 17 },
                new Seat { Id = 590, Number = 40, IsFree = true, SeatTypeId = 10, CarriageId = 17 }
                );
        }
        private void Discounts()
        {
            modelBuilder.Entity<Discount>().HasData(
                new Discount { Id = 1, Name = "Dla dziecka do lat 4", Value = 100, Description = "Dzieci w wieku do 4 lat" },
                new Discount { Id = 2, Name = "Funkcjonariusze Straży Granicznej", Value = 100, Description = @"Funkcjonariusze Straży Granicznej:
                                    1) umundurowani – w czasie wykonywania
                                    czynności służbowych związanych
                                    z ochroną granicy państwowej, a także
                                    w czasie konwojowania osób zatrzymanych, służby patrolowej oraz wykonywania czynności związanych z kontrolą ruchu granicznego,
                                    2) w czasie wykonywania czynności służbowych związanych z zapobieganiem i
                                    przeciwdziałaniem nielegalnej migracji,
                                    realizowanych na szlakach komunikacyjnych o szczególnym znaczeniu międzynarodowym" },
                new Discount { Id = 3, Name = "Funkcjonariusze Służby Celno-Skarbowej", Value = 100, Description = @"Funkcjonariusze Służby Celno-Skarbowej w
                                    czasie wykonywania czynności służbowych
                                    kontroli określonej w dziale V ustawy z dnia
                                    16 listopada 2016 r. o Krajowej Administracji Skarbowej (jednolity tekst Dz.U. 2020
                                    poz. 505)" },
                new Discount { Id = 4, Name = "Umundurowani funkcjonariusze Policji", Value = 100, Description = @"Umundurowani funkcjonariusze Policji
                                    w czasie konwojowania osób zatrzymanych
                                    lub chronionego mienia, przewożenia poczty
                                    specjalnej, służby patrolowej oraz udzielania
                                    pomocy lub asystowania przy czynnościach
                                    organów egzekucyjnych" },
                new Discount { Id = 5, Name = "Żołnierze Żandarmerii Wojskowej", Value = 100, Description = @"Żołnierze Żandarmerii Wojskowej oraz
                                    wojskowych organów porządkowych,
                                    wykonujący czynności urzędowe patrolowania i inne czynności służbowe
                                    w środkach transportu zbiorowego" },
                new Discount { Id = 6, Name = "Opiekun/Przewodnik", Value = 95, Description = @"Opiekun lub przewodnik towarzyszący
                                    w podróży:
                                    1) osobie niezdolnej do samodzielnej
                                    egzystencji ,
                                    albo
                                    2) osobie niewidomej" },
                new Discount { Id = 7, Name = "Przewodnik kombatanta/inwalidy gr. I ", Value = 95, Description = @"Przewodnik lub opiekun towarzyszący w podróży
                                    osobie wymienionej w poz. 1 lub 2:
                                    1) Inwalidzi wojenni i wojskowi zaliczeni do I grupy
                                    inwalidów lub uznani za całkowicie niezdolnych do
                                    pracy i niezdolnych do samodzielnej egzystencji
                                    (choćby bez związku z działaniami wojennymi lub
                                    służbą wojskową)
                                    2) Kombatanci będący inwalidami wojennymi lub
                                    wojskowymi zaliczonymi do I grupy inwalidów
                                    lub uznani za całkowicie niezdolnych do pracy
                                    i niezdolnych do samodzielnej egzystencji, także
                                    w przypadku zaliczenia do I grupy inwalidów
                                    (uznania niezdolności do samodzielnej egzystencji)
                                    z ogólnego stanu zdrowia " },
                new Discount { Id = 8, Name="Żołnierze", Value = 78, Description= @"Żołnierze odbywający niezawodową służbę
                                    wojskową*), z wyjątkiem służby okresowej
                                    i nadterminowej oraz osoby spełniające
                                    obowiązek tej służby w formach równorzędnych
                                    *) tj. żołnierze odbywający:
                                    a) zasadniczą służbę wojskową, w tym służbę kandydacką w Oddziałach Prewencji
                                    Policji, Straży Granicznej lub w Służbie
                                    Ochrony Państwa oraz pełniący terytorialną służbę wojskową albo służbę przygotowawczą;
                                    b) służbę zastępczą,
                                    c) służbę w charakterze kandydatów na żołnierzy zawodowych, tj. pobierający naukę
                                    w:
                                    - uczelni wojskowej (podchorążowie),
                                    - szkole podoficerskiej (kadeci),
                                    - ośrodku szkolenia (elewi),
                                    - orkiestrze,
                                    d) szkolenie wojskowe (dotyczy osób będących cywilnymi studentami uczelni wojskowej lub studentami innej uczelni niż
                                    uczelnia wojskowa powołanych do służby
                                    kandydackiej. Kandydat taki odbywa szkolenie w okresie wakacyjnym)
                                    e) zajęcia wojskowe (dot. studentów szkół
                                    morskich i akademii morskich) lub przeszkolenie wojskowe,
                                    f) ćwiczenia wojskowe." },
                new Discount { Id = 9, Name = "Kombatant/inwalida gr. I", Value = 78, Description = @" 1) Inwalidzi wojenni i wojskowi zaliczeni do I grupy
                                    inwalidów lub uznani za całkowicie niezdolnych do
                                    pracy i niezdolnych do samodzielnej egzystencji
                                    (choćby bez związku z działaniami wojennymi lub
                                    służbą wojskową)
                                    2) Kombatanci będący inwalidami wojennymi lub
                                    wojskowymi zaliczonymi do I grupy inwalidów
                                    lub uznani za całkowicie niezdolnych do pracy
                                    i niezdolnych do samodzielnej egzystencji, także
                                    w przypadku zaliczenia do I grupy inwalidów
                                    (uznania niezdolności do samodzielnej egzystencji)
                                    z ogólnego stanu zdrowia " },
                new Discount { Id = 10, Name = "Dzieci/Młodzież/Studenci niepełnosprawni", Value = 78, Description = @"Dzieci i młodzież dotknięte inwalidztwem
                                    lub niepełnosprawne do ukończenia 24
                                    roku życia oraz studenci dotknięci inwalidztwem lub niepełnosprawni do ukończenia 26 roku życia – wyłącznie przy przejazdach z miejsca zamieszkania lub z
                                    miejsca pobytu (za aktualne miejsce pobytu uznaje się każde miejsce deklarowane
                                    przez podróżnego) do przedszkola, szkoły,
                                    szkoły wyższej, placówki opiekuńczo–
                                    wychowawczej, placówki oświatowo–
                                    wychowawczej, specjalnego ośrodka
                                    szkolno–wychowawczego, specjalnego
                                    ośrodka wychowawczego, ośrodka umożliwiającego dzieciom i młodzieży spełnianie obowiązku szkolnego i obowiązku
                                    nauki, ośrodka rehabilitacyjnowychowawczego, domu pomocy społecznej, ośrodka wsparcia, zakładu opieki
                                    zdrowotnej, poradni psychologiczno–
                                    pedagogicznej, w tym poradni specjalistycznej, a także na turnus rehabilitacyjny
                                    – i z powrotem" },
                new Discount { Id = 11, Name = "Cywilne niewidome ofiary wojny niezdolne do samodzielnej egzystencji", Value = 78, Description = @"Cywilna niewidoma ofiara działań wojennych uznana za osobę niezdolną do samodzielnej egzystencji" },
                new Discount { Id = 12, Name = "Studenci do 26 lat/Doktoranci do 35 lat", Value = 51, Description = @"1) studenci do ukończenia 26 roku życia,
                                    2) słuchacze kolegiów pracowników służb
                                    społecznych, do ukończenia 26 roku
                                    życia,
                                    3) doktoranci do ukończenia 35 roku życia,
                                    4) Studenci – studiujący za granicą, do ukończenia 26 roku życia " },
                new Discount { Id = 13, Name = "Niewidominiezdolni do samodzielnej egzystencji", Value= 51, Description = @"Osoby niewidome uznane za osoby niezdolne do samodzielnej egzystencji*)
                                    *) za osobę niezdolną do samodzielnej
                                    egzystencji należy również uważać osobę niepełnosprawną w stopniu znacznym
                                    i inwalidę I grupy (jeżeli orzeczenie o
                                    zaliczeniu do tej grupy nie utraciło mocy)" },
                new Discount { Id = 14, Name = "Kombatanci", Value = 51, Description = @"Kombatanci będący inwalidami wojennymi lub
                                    wojskowymi zaliczonymi do II lub III grupy inwalidów lub uznani za całkowicie lub częściowo
                                    niezdolnych do pracy" },
                new Discount { Id = 15, Name = "Działacze opozycji antykomunistycznej/osob represjonowane politycznie", Value = 51, Description = @"Działacze opozycji antykomunistycznej oraz osoby
                                    represjonowane z powodów politycznych " },
                new Discount { Id = 16, Name = "Rodzic/Małżonek rodzica  - Karta Dużej Rodziny", Value = 37, Description = @"Rodzice lub małżonkowie rodziców posiadający Kartę Dużej Rodziny w rozumieniu
                                    ustawy o Karcie Dużej Rodziny" },
                new Discount { Id = 17, Name = "Dzieci/Młodzież", Value = 37, Description = @"Dzieci i młodzież w okresie od rozpoczęcia
                                    odbywania obowiązkowego rocznego
                                    przygotowania przedszkolnego do ukończenia szkoły podstawowej lub ponadpodstawowej – publicznej lub niepublicznej o
                                    uprawnieniach szkoły publicznej, nie dłużej
                                    niż do ukończenia 24 roku życia" },
                new Discount { Id = 18, Name = "Honorowy Dawca Krwi", Value = 33, Description = @"Honorowi dawcy krwi, którzy w przypadku ogłoszenia stanu zagrożenia epidemicznego albo stanu
                                    epidemii oddali co najmniej 3 donacje krwi lub jej
                                    składników, w tym osocze po chorobie COVID- 19 " },
                new Discount { Id = 19, Name = "Bilet dla Seniora", Value = 30, Description = @"Osoba która ukończyła 60 lat"}
                );
        }
        private void Stations()
        {
            modelBuilder.Entity<Station>().HasData(
                new Station { Id = 1, Name = "Białystok", City = "Białystok"},
                new Station { Id = 2, Name = "Łapy", City = "Łapy"},
                new Station { Id = 3, Name = "Łapy Osse", City = "Łapy"},
                new Station { Id = 4, Name = "Zdrody Nowe", City = "Zdrody Nowe"},
                new Station { Id = 5, Name = "Racibory", City = "Racibory"},
                new Station { Id = 6, Name = "Jabłoń Kościelna", City = "Jabłoń Kościelna" },
                new Station { Id = 7, Name = "Szymbory", City = "Szymbory" },
                new Station { Id = 8, Name = "Szepietowo", City = "Szepietowo" },
                new Station { Id = 9, Name = "Czyżew", City = "Czyżew" },
                new Station { Id = 10, Name = "Małkinia", City = "Małkinia" },
                new Station { Id = 11, Name = "Łochów", City = "Łochów" },
                new Station { Id = 12, Name = "Tłuszcz", City = "Tłuszcz" },
                new Station { Id = 13, Name = "Wołomin", City = "Wołomin" },
                new Station { Id = 14, Name = "Warszawa Wschodnia", City = "Warszawa" },
                new Station { Id = 15, Name = "Warszawa Centralna", City = "Warszawa" },
                new Station { Id = 16, Name = "Warszawa Zachodnia", City = "Warszawa" },
                new Station { Id = 17, Name = "Koluszki", City = "Koluszki" },
                new Station { Id = 18, Name = "Piotrków Trybunalski", City = "Piotrków Trybunalski" },
                new Station { Id = 19, Name = "Radomsko", City = "Radomsko" },
                new Station { Id = 20, Name = "Częstochowa", City = "Częstochowa" },
                new Station { Id = 21, Name = "Częstochowa Stardom", City = "Częstochowa" },
                new Station { Id = 22, Name = "Lubliniec", City = "Lubliniec" },
                new Station { Id = 23, Name = "Opole Główne", City = "Opole" },
                new Station { Id = 24, Name = "Brzeg", City = "Brzeg" },
                new Station { Id = 25, Name = "Oława", City = "Oława" },
                new Station { Id = 26, Name = "Wrocław Głowny", City = "Wrocław" },
                new Station { Id = 27, Name = "Wrocław Leśnica", City = "Wrocław" },
                new Station { Id = 28, Name = "Środa Śląska", City = "Środa Śląska" },
                new Station { Id = 29, Name = "Legnica", City = "Legnica" },
                new Station { Id = 30, Name = "Chojnów", City = "Chojnów" },
                new Station { Id = 31, Name = "Bolesławiec", City = "Bolesławiec" },
                new Station { Id = 32, Name = "Węgliniec", City = "Węgliniec" },
                new Station { Id = 33, Name = "Pieńsk", City = "Pieńsk" },
                new Station { Id = 34, Name = "Zgorzelec Miasto", City = "Zgorzelec" },
                new Station { Id = 35, Name = "Zgorzelec", City = "Zgorzelec" },

                new Station { Id = 36, Name = "Opoczno Południe", City = "Opoczno" },
                new Station { Id = 37, Name = "Włoszczowa Północ", City = "Włoszczowa" },
                new Station { Id = 38, Name = "Miechów", City = "Miechów" },
                new Station { Id = 39, Name = "Kraków Główny", City = "Kraków" }
                );
        }
        private void TrainTimeTables()
        {
            modelBuilder.Entity<TrainTimeTable>().HasData(
                new TrainTimeTable { Id = 1, DepartureTime = new TimeSpan(13, 41, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12)},
                new TrainTimeTable { Id = 2, ArrivalTime = new TimeSpan(14, 00, 0), DepartureTime = new TimeSpan(14, 01, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 3, ArrivalTime = new TimeSpan(14, 04, 0), DepartureTime = new TimeSpan(14, 05, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 4, ArrivalTime = new TimeSpan(14, 08, 0), DepartureTime = new TimeSpan(14, 09, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 5, ArrivalTime = new TimeSpan(14, 13, 0), DepartureTime = new TimeSpan(14, 13, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 6, ArrivalTime = new TimeSpan(14, 17, 0), DepartureTime = new TimeSpan(14, 18, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 7, ArrivalTime = new TimeSpan(14, 21, 0), DepartureTime = new TimeSpan(14, 21, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 8, ArrivalTime = new TimeSpan(14, 26, 0), DepartureTime = new TimeSpan(14, 27, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 9, ArrivalTime = new TimeSpan(14, 42, 0), DepartureTime = new TimeSpan(14, 43, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 10,  ArrivalTime = new TimeSpan(15, 00, 0), DepartureTime = new TimeSpan( 15, 01, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 11,  ArrivalTime = new TimeSpan(15, 17, 0), DepartureTime = new TimeSpan( 15, 18, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 12,  ArrivalTime = new TimeSpan(15, 29, 0), DepartureTime = new TimeSpan( 15, 30, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 13,  ArrivalTime = new TimeSpan(15, 39, 0), DepartureTime = new TimeSpan( 15, 40, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 14,  ArrivalTime = new TimeSpan(16, 00, 0), DepartureTime = new TimeSpan( 16, 07, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 15,  ArrivalTime = new TimeSpan(16, 13, 0), DepartureTime = new TimeSpan( 16, 29, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 16,  ArrivalTime = new TimeSpan(16, 34, 0), DepartureTime = new TimeSpan( 16, 36, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 17,  ArrivalTime = new TimeSpan(17, 30, 0), DepartureTime = new TimeSpan( 17, 31, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 18,  ArrivalTime = new TimeSpan(17, 54, 0), DepartureTime = new TimeSpan( 17, 55, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 19,  ArrivalTime = new TimeSpan(18, 21, 0), DepartureTime = new TimeSpan( 18, 22, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 20,  ArrivalTime = new TimeSpan(18, 46, 0), DepartureTime = new TimeSpan( 18, 50, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 21,  ArrivalTime = new TimeSpan(18, 54, 0), DepartureTime = new TimeSpan( 18, 57, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 22,  ArrivalTime = new TimeSpan(19, 23, 0), DepartureTime = new TimeSpan( 19, 35, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 23,  ArrivalTime = new TimeSpan(20, 06, 0), DepartureTime = new TimeSpan( 20, 09, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 24,  ArrivalTime = new TimeSpan(20, 29, 0), DepartureTime = new TimeSpan( 20, 30, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 25,  ArrivalTime = new TimeSpan(20, 38, 0), DepartureTime = new TimeSpan( 20, 39, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 26,  ArrivalTime = new TimeSpan(21, 03, 0), DepartureTime = new TimeSpan( 21, 26, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 27,  ArrivalTime = new TimeSpan(21, 35, 0), DepartureTime = new TimeSpan( 21, 36, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 28,  ArrivalTime = new TimeSpan(21, 57, 0), DepartureTime = new TimeSpan( 22, 59, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 29,  ArrivalTime = new TimeSpan(22, 23, 0), DepartureTime = new TimeSpan( 22, 24, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 30,  ArrivalTime = new TimeSpan(22, 36, 0), DepartureTime = new TimeSpan( 22, 37, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 31,  ArrivalTime = new TimeSpan(22, 44, 0), DepartureTime = new TimeSpan( 22, 45, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 32,  ArrivalTime = new TimeSpan(22, 53, 0), DepartureTime = new TimeSpan( 22, 54, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 33,  ArrivalTime = new TimeSpan(23, 01, 0), DepartureTime = new TimeSpan( 23, 02, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 34,  ArrivalTime = new TimeSpan(23, 33, 0), DepartureTime = new TimeSpan( 23, 34, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 35,  ArrivalTime = new TimeSpan(23, 56, 0), DepartureTime = new TimeSpan( 23, 59, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },

                new TrainTimeTable { Id = 36, ArrivalTime = new TimeSpan(17, 32, 0), DepartureTime = new TimeSpan(17, 58, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 37, ArrivalTime = new TimeSpan(18, 18, 0), DepartureTime = new TimeSpan(18, 19, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 38, ArrivalTime = new TimeSpan(18, 38, 0), DepartureTime = new TimeSpan(18, 39, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 39, ArrivalTime = new TimeSpan(18, 55, 0), DepartureTime = new TimeSpan(18, 56, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 40, ArrivalTime = new TimeSpan(19, 13, 0), DepartureTime = new TimeSpan(19, 14, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 41, ArrivalTime = new TimeSpan(19, 30, 0), DepartureTime = new TimeSpan(19, 31, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 42, ArrivalTime = new TimeSpan(19, 43, 0), DepartureTime = new TimeSpan(19, 44, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 43, ArrivalTime = new TimeSpan(19, 54, 0), DepartureTime = new TimeSpan(19, 55, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 44, ArrivalTime = new TimeSpan(20, 17, 0), DepartureTime = new TimeSpan(20, 19, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 45, ArrivalTime = new TimeSpan(20, 25, 0), DepartureTime = new TimeSpan(20, 44, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 46, ArrivalTime = new TimeSpan(20, 48, 0), DepartureTime = new TimeSpan(20, 49, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 47, ArrivalTime = new TimeSpan(21, 58, 0), DepartureTime = new TimeSpan(21, 59, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 48, ArrivalTime = new TimeSpan(22, 31, 0), DepartureTime = new TimeSpan(22, 32, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 49, ArrivalTime = new TimeSpan(23, 10, 0), DepartureTime = new TimeSpan(23, 11, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) },
                new TrainTimeTable { Id = 50, ArrivalTime = new TimeSpan(23, 48, 0), DepartureTime = new TimeSpan(23, 57, 0), StartingDateOfTimeTable = new DateTime(2021, 12, 12) }

                );
        }
        private void TrainStations()
        {
            modelBuilder.Entity<TrainStation>().HasData(
                new TrainStation { Id = 1, StationId = 1, TrainId = 1, TrainTimeTableId = 1 },
                new TrainStation { Id = 2, StationId = 2, TrainId = 1, TrainTimeTableId = 2 },
                new TrainStation { Id = 3, StationId = 3, TrainId = 1, TrainTimeTableId = 3 },
                new TrainStation { Id = 4, StationId = 4, TrainId = 1, TrainTimeTableId = 4 },
                new TrainStation { Id = 5, StationId = 5, TrainId = 1, TrainTimeTableId = 5 },
                new TrainStation { Id = 6, StationId = 6, TrainId = 1, TrainTimeTableId = 6 },
                new TrainStation { Id = 7, StationId = 7, TrainId = 1, TrainTimeTableId = 7 },
                new TrainStation { Id = 8, StationId = 8, TrainId = 1, TrainTimeTableId = 8 },
                new TrainStation { Id = 9, StationId = 9, TrainId = 1, TrainTimeTableId = 9 },
                new TrainStation { Id = 10, StationId = 10, TrainId = 1, TrainTimeTableId = 10 },
                new TrainStation { Id = 11, StationId = 11, TrainId = 1, TrainTimeTableId = 11 }, 
                new TrainStation { Id = 12, StationId = 12, TrainId = 1, TrainTimeTableId = 12 },
                new TrainStation { Id = 13, StationId = 13, TrainId = 1, TrainTimeTableId = 13 },
                new TrainStation { Id = 14, StationId = 14, TrainId = 1, TrainTimeTableId = 14 },
                new TrainStation { Id = 15, StationId = 15, TrainId = 1, TrainTimeTableId = 15 },
                new TrainStation { Id = 16, StationId = 16, TrainId = 1, TrainTimeTableId = 16 },
                new TrainStation { Id = 17, StationId = 17, TrainId = 1, TrainTimeTableId = 17 },
                new TrainStation { Id = 18, StationId = 18, TrainId = 1, TrainTimeTableId = 18 },
                new TrainStation { Id = 19, StationId = 19, TrainId = 1, TrainTimeTableId = 19 },
                new TrainStation { Id = 20, StationId = 20, TrainId = 1, TrainTimeTableId = 20 },
                new TrainStation { Id = 21, StationId = 21, TrainId = 1, TrainTimeTableId = 21 },
                new TrainStation { Id = 22, StationId = 22, TrainId = 1, TrainTimeTableId = 22 },
                new TrainStation { Id = 23, StationId = 23, TrainId = 1, TrainTimeTableId = 23 },
                new TrainStation { Id = 24, StationId = 24, TrainId = 1, TrainTimeTableId = 24 },
                new TrainStation { Id = 25, StationId = 25, TrainId = 1, TrainTimeTableId = 25 },
                new TrainStation { Id = 26, StationId = 26, TrainId = 1, TrainTimeTableId = 26 },
                new TrainStation { Id = 27, StationId = 27, TrainId = 1, TrainTimeTableId = 27 },
                new TrainStation { Id = 28, StationId = 28, TrainId = 1, TrainTimeTableId = 28 },
                new TrainStation { Id = 29, StationId = 29, TrainId = 1, TrainTimeTableId = 29 },
                new TrainStation { Id = 30, StationId = 30, TrainId = 1, TrainTimeTableId = 30 },
                new TrainStation { Id = 31, StationId = 31, TrainId = 1, TrainTimeTableId = 31 },
                new TrainStation { Id = 32, StationId = 32, TrainId = 1, TrainTimeTableId = 32 },
                new TrainStation { Id = 33, StationId = 33, TrainId = 1, TrainTimeTableId = 33 },
                new TrainStation { Id = 34, StationId = 34, TrainId = 1, TrainTimeTableId = 34 },
                new TrainStation { Id = 35, StationId = 35, TrainId = 1, TrainTimeTableId = 35 },

                new TrainStation { Id = 36, StationId = 1, TrainId = 2, TrainTimeTableId = 36 },
                new TrainStation { Id = 37, StationId = 2, TrainId = 2, TrainTimeTableId = 37 },
                new TrainStation { Id = 38, StationId = 8, TrainId = 2, TrainTimeTableId = 38 },
                new TrainStation { Id = 39, StationId = 9, TrainId = 2, TrainTimeTableId = 39 },
                new TrainStation { Id = 40, StationId = 10, TrainId = 2, TrainTimeTableId = 40 },
                new TrainStation { Id = 41, StationId = 11, TrainId = 2, TrainTimeTableId = 41 },
                new TrainStation { Id = 42, StationId = 12, TrainId = 2, TrainTimeTableId = 42 },
                new TrainStation { Id = 43, StationId = 13, TrainId = 2, TrainTimeTableId = 43 },
                new TrainStation { Id = 44, StationId = 14, TrainId = 2, TrainTimeTableId = 44 },
                new TrainStation { Id = 45, StationId = 15, TrainId = 2, TrainTimeTableId = 45 },
                new TrainStation { Id = 46, StationId = 16, TrainId = 2, TrainTimeTableId = 46 },
                new TrainStation { Id = 47, StationId = 36, TrainId = 2, TrainTimeTableId = 47 },
                new TrainStation { Id = 48, StationId = 37, TrainId = 2, TrainTimeTableId = 48 },
                new TrainStation { Id = 49, StationId = 38, TrainId = 2, TrainTimeTableId = 49 },
                new TrainStation { Id = 50, StationId = 39, TrainId = 2, TrainTimeTableId = 50 }
                );
        }
        private void Routes()
        {
            modelBuilder.Entity<Route>().HasData(
                new Route { Id = 1, Name = "Białystok-Zgorzelec", TrainId = 1},
                new Route { Id = 2, Name = "Białystok-Kraków Główny", TrainId = 2}
                );
        }

        private void RouteStations()
        {
            modelBuilder.Entity<RouteStation>().HasData(
                new RouteStation { Id = 1, StartStationId = 1, EndStationId = 2, RouteId = 1, Order = 1, Distance = 30, Price = 5},
                new RouteStation { Id = 2, StartStationId = 2, EndStationId = 3, RouteId = 1, Order = 2, Distance = 20, Price = 5},
                new RouteStation { Id = 3, StartStationId = 3, EndStationId = 4, RouteId = 1, Order = 3, Distance = 36, Price = 5},
                new RouteStation { Id = 4, StartStationId = 4, EndStationId = 5, RouteId = 1, Order = 4, Distance = 20, Price = 5},
                new RouteStation { Id = 5, StartStationId = 5, EndStationId = 6, RouteId = 1, Order = 5, Distance = 17, Price = 5},
                new RouteStation { Id = 6, StartStationId = 6, EndStationId = 7, RouteId = 1, Order = 6, Distance = 45, Price = 5},
                new RouteStation { Id = 7, StartStationId = 7, EndStationId = 8, RouteId = 1, Order = 7, Distance = 32, Price = 5},
                new RouteStation { Id = 8, StartStationId = 8, EndStationId = 9, RouteId = 1, Order = 8, Distance = 23, Price = 5},
                new RouteStation { Id = 9, StartStationId = 9, EndStationId = 10, RouteId = 1, Order = 9, Distance = 21, Price = 5},
                new RouteStation { Id = 10, StartStationId = 10, EndStationId = 11, RouteId = 1, Order = 10, Distance = 21, Price = 5},
                new RouteStation { Id = 11, StartStationId = 11, EndStationId = 12, RouteId = 1, Order = 11, Distance = 30, Price = 5 },
                new RouteStation { Id = 12, StartStationId = 12, EndStationId = 13, RouteId = 1, Order = 12, Distance = 20, Price = 5 },
                new RouteStation { Id = 13, StartStationId = 13, EndStationId = 14, RouteId = 1, Order = 13, Distance = 36, Price = 5 },
                new RouteStation { Id = 14, StartStationId = 14, EndStationId = 15, RouteId = 1, Order = 14, Distance = 20, Price = 5 },
                new RouteStation { Id = 15, StartStationId = 15, EndStationId = 16, RouteId = 1, Order = 15, Distance = 17, Price = 5 },
                new RouteStation { Id = 16, StartStationId = 16, EndStationId = 17, RouteId = 1, Order = 16, Distance = 45, Price = 5 },
                new RouteStation { Id = 17, StartStationId = 17, EndStationId = 18, RouteId = 1, Order = 17, Distance = 32, Price = 5 },
                new RouteStation { Id = 18, StartStationId = 18, EndStationId = 19, RouteId = 1, Order = 18, Distance = 23, Price = 5 },
                new RouteStation { Id = 19, StartStationId = 19, EndStationId = 20, RouteId = 1, Order = 19, Distance = 21, Price = 5 },
                new RouteStation { Id = 20, StartStationId = 20, EndStationId = 21, RouteId = 1, Order = 20, Distance = 21, Price = 5 },
                new RouteStation { Id = 21, StartStationId = 21, EndStationId = 22, RouteId = 1, Order = 21, Distance = 30, Price = 5 },
                new RouteStation { Id = 22, StartStationId = 22, EndStationId = 23, RouteId = 1, Order = 22, Distance = 20, Price = 5 },
                new RouteStation { Id = 23, StartStationId = 23, EndStationId = 24, RouteId = 1, Order = 23, Distance = 36, Price = 5 },
                new RouteStation { Id = 24, StartStationId = 24, EndStationId = 25, RouteId = 1, Order = 24, Distance = 20, Price = 5 },
                new RouteStation { Id = 25, StartStationId = 25, EndStationId = 26, RouteId = 1, Order = 25, Distance = 17, Price = 5 },
                new RouteStation { Id = 26, StartStationId = 26, EndStationId = 27, RouteId = 1, Order = 26, Distance = 45, Price = 5 },
                new RouteStation { Id = 27, StartStationId = 27, EndStationId = 28, RouteId = 1, Order = 27, Distance = 32, Price = 5 },
                new RouteStation { Id = 28, StartStationId = 28, EndStationId = 29, RouteId = 1, Order = 28, Distance = 23, Price = 5 },
                new RouteStation { Id = 29, StartStationId = 29, EndStationId = 30, RouteId = 1, Order = 29, Distance = 21, Price = 5 },
                new RouteStation { Id = 30, StartStationId = 30, EndStationId = 31, RouteId = 1, Order = 30, Distance = 21, Price = 5 },
                new RouteStation { Id = 31, StartStationId = 31, EndStationId = 32, RouteId = 1, Order = 31, Distance = 30, Price = 5 },
                new RouteStation { Id = 32, StartStationId = 32, EndStationId = 33, RouteId = 1, Order = 32, Distance = 20, Price = 5 },
                new RouteStation { Id = 33, StartStationId = 33, EndStationId = 34, RouteId = 1, Order = 33, Distance = 36, Price = 5 },
                new RouteStation { Id = 34, StartStationId = 34, EndStationId = 35, RouteId = 1, Order = 34, Distance = 20, Price = 5 },

                new RouteStation { Id = 35, StartStationId = 1, EndStationId = 2, RouteId = 2, Order = 1, Distance = 17, Price = 5 },
                new RouteStation { Id = 36, StartStationId = 2, EndStationId = 8, RouteId = 2, Order = 2, Distance = 45, Price = 5 },
                new RouteStation { Id = 37, StartStationId = 8, EndStationId = 9, RouteId = 2, Order = 3, Distance = 32, Price = 5 },
                new RouteStation { Id = 38, StartStationId = 9, EndStationId = 10, RouteId = 2, Order = 4, Distance = 23, Price = 5 },
                new RouteStation { Id = 39, StartStationId = 10, EndStationId = 11, RouteId = 2, Order = 5, Distance = 21, Price = 5 },
                new RouteStation { Id = 40, StartStationId = 11, EndStationId = 12, RouteId = 2, Order = 6, Distance = 21, Price = 5 },
                new RouteStation { Id = 41, StartStationId = 12, EndStationId = 13, RouteId = 2, Order = 7, Distance = 30, Price = 5 },
                new RouteStation { Id = 42, StartStationId = 13, EndStationId = 14, RouteId = 2, Order = 8, Distance = 20, Price = 5 },
                new RouteStation { Id = 43, StartStationId = 14, EndStationId = 15, RouteId = 2, Order = 9, Distance = 36, Price = 5 },
                new RouteStation { Id = 44, StartStationId = 15, EndStationId = 16, RouteId = 2, Order = 10, Distance = 20, Price = 5 },
                new RouteStation { Id = 45, StartStationId = 16, EndStationId = 36, RouteId = 2, Order = 11, Distance = 17, Price = 5 },
                new RouteStation { Id = 46, StartStationId = 36, EndStationId = 37, RouteId = 2, Order = 12, Distance = 45, Price = 5 },
                new RouteStation { Id = 47, StartStationId = 37, EndStationId = 38, RouteId = 2, Order = 13, Distance = 32, Price = 5 },
                new RouteStation { Id = 48, StartStationId = 38, EndStationId = 39, RouteId = 2, Order = 14, Distance = 23, Price = 5 }


                );
        }
    }
}
