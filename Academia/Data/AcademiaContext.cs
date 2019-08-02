using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Academia.Models;

    public class AcademiaContext : DbContext
    {
        public AcademiaContext (DbContextOptions<AcademiaContext> options)
            : base(options)
        {
        }

        public DbSet<Academia.Models.Cargo> Cargo { get; set; }

        public DbSet<Academia.Models.Empleado> Empleado { get; set; }

        public DbSet<Academia.Models.Hojadevida> Hojadevida { get; set; }
    }
