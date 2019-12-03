using BanducciAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanducciAPI.Data
{
    public class BanducciDataContext: DbContext
    {
        public BanducciDataContext(DbContextOptions<BanducciDataContext> options): base(options)
        {

        }

        public DbSet<BanducciLocation> BanducciLocation { get; set; }
        public DbSet<BanducciEmployee> BanducciEmployee { get; set; }
        public DbSet<BanducciRepair> BanducciRepair { get; set; }
        public DbSet<BanducciServSafe> BanducciServSafe { get; set; }
    }
}
