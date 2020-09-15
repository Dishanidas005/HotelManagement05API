using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hms.Models
{
    public class hmsContext:DbContext

    {
        public hmsContext(DbContextOptions options) : base(options)
        { }
        public hmsContext()
        {

        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }

        public virtual DbSet<Booking> Bookings{ get; set; }
        public virtual object Booking { get; internal set; }
    }
}
