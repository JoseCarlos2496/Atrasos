using Atrasos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atrasos.Infrastructure.Data.Configurations
{
    public class AtrasoConfigrations : IEntityTypeConfiguration<Atraso>
    {

        void IEntityTypeConfiguration<Atraso>.Configure(EntityTypeBuilder<Atraso> builder)
        {
            builder.ToTable("Atraso");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .IsRequired()
                   .HasColumnName("Id")
                   .HasColumnType("INT")
                   .UseIdentityColumn(1);

            builder.Property(a => a.Nombre)
                   .IsRequired()
                   .HasColumnName("Nombre")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(128);

            builder.Property(a => a.Permiso)
                   .IsRequired()
                   .HasColumnName("Permiso")
                   .HasColumnType("BIT")
                   .HasDefaultValue(false);

            builder.Property(a => a.FechaHora)
                   .IsRequired()
                   .HasColumnName("FechaHora")
                   .HasColumnType("DATETIME2")
                   .HasDefaultValueSql("getdate()");

            builder.Property(a => a.Valor)
                   .IsRequired()
                   .HasColumnName("Valor")
                   .HasColumnType("DECIMAL")
                   .HasPrecision(19, 2);

            builder.Property(a => a.EstadoDeuda)
                   .IsRequired()
                   .HasColumnName("EstadoDeuda")
                   .HasColumnType("BIT")
                   .HasDefaultValue(false);

            builder.Property(a => a.EsActivo)
                   .IsRequired()
                   .HasColumnName("EsActivo")
                   .HasColumnType("BIT")
                   .HasDefaultValue(true);

            builder.Property(a => a.Creado)
                   .IsRequired()
                   .HasColumnName("Creado")
                   .HasColumnType("DATETIME2")
                   .HasDefaultValueSql("getdate()");

            builder.Property(a => a.Actualizado)
                   .IsRequired()
                   .HasColumnName("Actualizado")
                   .HasColumnType("DATETIME2")
                   .HasDefaultValueSql("getdate()");
        }
    }
}
