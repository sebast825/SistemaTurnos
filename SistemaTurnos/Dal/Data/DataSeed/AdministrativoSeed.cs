﻿using SistemaTurnos.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace SistemaTurnos.Dal.Data.DataSeed
{
    public class AdministrativoSeed : IEntityTypeConfiguration<Administrativo>
    {
        public void Configure(EntityTypeBuilder<Administrativo> builder)
        {
            builder.HasData(
                new Administrativo
                {
                    Id = 8,
                    Nombre = "Laura",
                    Apellido = "Martínez",
                    FechaNacimiento = new DateTime(1990, 6, 12),
                    Telefono = "111222333",
                    NumeroDocumento = "DNI65432100",
                    Email = "laura.martinez@ejemplo.com",
                    SexoId = 2, // Mujer
                    RolId = 1,
                },
                new Administrativo
                {
                    Id = 9,
                    Nombre = "Pedro",
                    Apellido = "Sánchez",
                    FechaNacimiento = new DateTime(1982, 4, 23),
                    Telefono = "444555666",
                    NumeroDocumento = "DNI12345001",
                    Email = "pedro.sanchez@ejemplo.com",
                    SexoId = 1, // Hombre
                    RolId = 2, 
               
                }
            );
        }
    }
}