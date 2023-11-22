﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MisPacientes_04.Data;

#nullable disable

namespace MisPacientes_04.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20231122125057_migracionInit_07_relAnamnesis_AntFam_fix")]
    partial class migracionInit_07_relAnamnesis_AntFam_fix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MisPacientes_04.Models.Anamnesis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EnfermedadActual")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("MotivoConsulta")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<int?>("PacienteRefId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacienteRefId")
                        .IsUnique()
                        .HasFilter("[PacienteRefId] IS NOT NULL");

                    b.ToTable("Anamnesis");
                });

            modelBuilder.Entity("MisPacientes_04.Models.AntecedenteFamiliar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnamnesisRefId")
                        .HasColumnType("int");

                    b.Property<string>("DescripcionAntecedentes")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("E_Cardios")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("E_Respiratorias")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.HasKey("Id");

                    b.HasIndex("AnamnesisRefId")
                        .IsUnique()
                        .HasFilter("[AnamnesisRefId] IS NOT NULL");

                    b.ToTable("AntecedenteFamiliar");
                });

            modelBuilder.Entity("MisPacientes_04.Models.ObraSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ObraSocial");
                });

            modelBuilder.Entity("MisPacientes_04.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("MedicoReferido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroAfiliado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ObraSocialRefId")
                        .HasColumnType("int");

                    b.Property<string>("Provincia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ObraSocialRefId")
                        .IsUnique()
                        .HasFilter("[ObraSocialRefId] IS NOT NULL");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("MisPacientes_04.Models.Anamnesis", b =>
                {
                    b.HasOne("MisPacientes_04.Models.Paciente", "Paciente")
                        .WithOne("Anamnesis")
                        .HasForeignKey("MisPacientes_04.Models.Anamnesis", "PacienteRefId");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("MisPacientes_04.Models.AntecedenteFamiliar", b =>
                {
                    b.HasOne("MisPacientes_04.Models.Anamnesis", "Anamnesis")
                        .WithOne("AntecedenteFamiliar")
                        .HasForeignKey("MisPacientes_04.Models.AntecedenteFamiliar", "AnamnesisRefId");

                    b.Navigation("Anamnesis");
                });

            modelBuilder.Entity("MisPacientes_04.Models.Paciente", b =>
                {
                    b.HasOne("MisPacientes_04.Models.ObraSocial", "ObraSocial")
                        .WithOne("Paciente")
                        .HasForeignKey("MisPacientes_04.Models.Paciente", "ObraSocialRefId");

                    b.Navigation("ObraSocial");
                });

            modelBuilder.Entity("MisPacientes_04.Models.Anamnesis", b =>
                {
                    b.Navigation("AntecedenteFamiliar");
                });

            modelBuilder.Entity("MisPacientes_04.Models.ObraSocial", b =>
                {
                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("MisPacientes_04.Models.Paciente", b =>
                {
                    b.Navigation("Anamnesis");
                });
#pragma warning restore 612, 618
        }
    }
}
