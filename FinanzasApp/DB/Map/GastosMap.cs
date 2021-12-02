using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanzasApp.Models.Map
{
    public class GastosMap : IEntityTypeConfiguration<Gastos>
    {
        public void Configure(EntityTypeBuilder<Gastos> builder)
        {
            builder.ToTable("Gasto");
            builder.HasKey(gasto => gasto.Id);
            builder.HasOne(gasto => gasto.Cuenta)
                .WithMany()
                .HasForeignKey(gasto => gasto.CuentaId);
        }
    }
}
