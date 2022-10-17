using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DatabaseTestingMoq.Models;

namespace DatabaseTestingMoq.Data
{
    public class DatabaseTestingMoqContext : DbContext
    {
        public DatabaseTestingMoqContext (DbContextOptions<DatabaseTestingMoqContext> options)
            : base(options)
        {
        }


        //mock data shoudld be virtual
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<Pass> Passes { get; set; }
        public virtual DbSet<ParkingSpot> ParkingSpot { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
    }
}
