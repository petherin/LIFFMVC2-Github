using LIFFMVC2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LIFFMVC2.DataContexts
{
    public class FilmsDb : DbContext
    {
        public FilmsDb ()
            :  base("DefaultConnection")
            {
            }

        public DbSet<Film> Films { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<TimeSlot> Slots { get; set; }
        public DbSet<Venue> Venues { get; set; }
    }
}