using MyClinicApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicApi.Data
{
    public class ClinicContext : DbContext
    {
        public DbSet<doctor> doctors { get; set; }
        public DbSet<patient> patients { get; set; }
        public DbSet<appointment> appointments { get; set; }

        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        {
        }

    }
}
