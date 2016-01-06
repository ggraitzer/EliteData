using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using EliteData.DataRepository.Models;

namespace EliteData.DataRepository
{
    public class EliteDataContext : DbContext
    {
        public DbSet<SolarSystem> Systems { get; set; }
    }
}
