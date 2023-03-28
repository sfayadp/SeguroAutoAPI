﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeguroAutoAPI.DataAccess.Context;

#nullable disable

namespace SeguroAutoAPI.Migrations
{
    [DbContext(typeof(SeguroAutoContext))]
    [Migration("20230328053439_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SeguroAutoAPI.DataAccess.Models.Cobertura", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MontoCubierto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PolizaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PolizaId");

                    b.ToTable("Coberturas");
                });

            modelBuilder.Entity("SeguroAutoAPI.DataAccess.Models.Poliza", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CiudadResidencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionResidencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaFinPoliza")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicioPoliza")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaNacimientoCliente")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdentificacionCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModeloAutomotor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombrePlan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroPoliza")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlacaAutomotor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorMaximoCubierto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("VehiculoTieneInspeccion")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Polizas");
                });

            modelBuilder.Entity("SeguroAutoAPI.DataAccess.Models.Cobertura", b =>
                {
                    b.HasOne("SeguroAutoAPI.DataAccess.Models.Poliza", "Poliza")
                        .WithMany("Coberturas")
                        .HasForeignKey("PolizaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poliza");
                });

            modelBuilder.Entity("SeguroAutoAPI.DataAccess.Models.Poliza", b =>
                {
                    b.Navigation("Coberturas");
                });
#pragma warning restore 612, 618
        }
    }
}