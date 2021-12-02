using FinanzasApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanzasApp.DB
{
    public class FinanzasContext : DbContext
    {
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Gastos> Gastos { get; set; }
        public DbSet<Ingresos> Ingresos { get; set; }

        public FinanzasContext(DbContextOptions<FinanzasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
