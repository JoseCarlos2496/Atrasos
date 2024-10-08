﻿// <auto-generated />
using System;
using Atrasos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Atrasos.Infrastructure.Migrations
{
    [DbContext(typeof(AtrasosDBContext))]
    [Migration("20240815201512_AtrasoAPI")]
    partial class AtrasoAPI
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Atrasos.Domain.Entities.Atraso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Actualizado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasColumnName("Actualizado")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("Creado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasColumnName("Creado")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("EsActivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(true)
                        .HasColumnName("EsActivo");

                    b.Property<bool>("EstadoDeuda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(false)
                        .HasColumnName("EstadoDeuda");

                    b.Property<DateTime>("FechaHora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasColumnName("FechaHora")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Nombre");

                    b.Property<bool>("Permiso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(false)
                        .HasColumnName("Permiso");

                    b.Property<decimal>("Valor")
                        .HasPrecision(19, 2)
                        .HasColumnType("DECIMAL")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.ToTable("Atraso", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
