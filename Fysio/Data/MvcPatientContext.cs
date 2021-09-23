using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fysio.Models;

    public class MvcPatientContext : DbContext
    {
        public MvcPatientContext (DbContextOptions<MvcPatientContext> options)
            : base(options)
        {
        }

        public DbSet<Fysio.Models.Patient> Patient { get; set; }
    }
