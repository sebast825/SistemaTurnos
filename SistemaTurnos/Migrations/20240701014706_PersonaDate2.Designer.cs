﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaTurnos.Dal.Data;

#nullable disable

namespace SistemaTurnos.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240701014706_PersonaDate2")]
    partial class PersonaDate2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaTurnos.Dal.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroDocumento")
                        .HasColumnType("int");

                    b.Property<int>("SexoId")
                        .HasColumnType("int");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SexoId");

                    b.ToTable("Personas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Pérez",
                            Email = "juan.perez@example.com",
                            FechaCreacion = new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7240),
                            FechaNacimiento = new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Juan",
                            NumeroDocumento = 12345678,
                            SexoId = 1,
                            Telefono = 123456789
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Gómez",
                            Email = "maria.gomez@example.com",
                            FechaCreacion = new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7260),
                            FechaNacimiento = new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "María",
                            NumeroDocumento = 87654321,
                            SexoId = 2,
                            Telefono = 987654321
                        },
                        new
                        {
                            Id = 3,
                            Apellido = "Rodríguez",
                            Email = "pedro.rodriguez@example.com",
                            FechaCreacion = new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7263),
                            FechaNacimiento = new DateTime(1988, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Pedro",
                            NumeroDocumento = 56781234,
                            SexoId = 1,
                            Telefono = 456789123
                        },
                        new
                        {
                            Id = 4,
                            Apellido = "Martínez",
                            Email = "ana.martinez@example.com",
                            FechaCreacion = new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7266),
                            FechaNacimiento = new DateTime(1995, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Ana",
                            NumeroDocumento = 34567812,
                            SexoId = 2,
                            Telefono = 654321789
                        },
                        new
                        {
                            Id = 5,
                            Apellido = "Gutiérrez",
                            Email = "lucas.gutierrez@example.com",
                            FechaCreacion = new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7269),
                            FechaNacimiento = new DateTime(1987, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Lucas",
                            NumeroDocumento = 78123456,
                            SexoId = 1,
                            Telefono = 789123456
                        },
                        new
                        {
                            Id = 6,
                            Apellido = "López",
                            Email = "laura.lopez@example.com",
                            FechaCreacion = new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7271),
                            FechaNacimiento = new DateTime(1993, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Laura",
                            NumeroDocumento = 23456781,
                            SexoId = 2,
                            Telefono = 321654987
                        },
                        new
                        {
                            Id = 7,
                            Apellido = "Sánchez",
                            Email = "gabriel.sanchez@example.com",
                            FechaCreacion = new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7273),
                            FechaNacimiento = new DateTime(1986, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Gabriel",
                            NumeroDocumento = 67812345,
                            SexoId = 1,
                            Telefono = 896745231
                        },
                        new
                        {
                            Id = 8,
                            Apellido = "Fernández",
                            Email = "carolina.fernandez@example.com",
                            FechaCreacion = new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7354),
                            FechaNacimiento = new DateTime(1991, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Carolina",
                            NumeroDocumento = 45678123,
                            SexoId = 2,
                            Telefono = 478512369
                        },
                        new
                        {
                            Id = 9,
                            Apellido = "Díaz",
                            Email = "jorge.diaz@example.com",
                            FechaCreacion = new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7357),
                            FechaNacimiento = new DateTime(1989, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Jorge",
                            NumeroDocumento = 56781234,
                            SexoId = 1,
                            Telefono = 369874512
                        },
                        new
                        {
                            Id = 10,
                            Apellido = "Ramírez",
                            Email = "valeria.ramirez@example.com",
                            FechaCreacion = new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7359),
                            FechaNacimiento = new DateTime(1994, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Valeria",
                            NumeroDocumento = 67812345,
                            SexoId = 2,
                            Telefono = 214365879
                        },
                        new
                        {
                            Id = 11,
                            Apellido = "Ramírez",
                            Email = "valeria.ramirez@example.com",
                            FechaCreacion = new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7362),
                            FechaNacimiento = new DateTime(1993, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Valeria",
                            NumeroDocumento = 67812345,
                            SexoId = 2,
                            Telefono = 214365879
                        });
                });

            modelBuilder.Entity("SistemaTurnos.Dal.Entities.Sexo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sexos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Hombre"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Mujer"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Otro"
                        });
                });

            modelBuilder.Entity("SistemaTurnos.Dal.Entities.Persona", b =>
                {
                    b.HasOne("SistemaTurnos.Dal.Entities.Sexo", "Sexo")
                        .WithMany()
                        .HasForeignKey("SexoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sexo");
                });
#pragma warning restore 612, 618
        }
    }
}