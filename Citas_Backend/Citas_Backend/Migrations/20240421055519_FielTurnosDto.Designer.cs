﻿// <auto-generated />
using System;
using Citas_Backend.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Citas_Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240421055519_FielTurnosDto")]
    partial class FielTurnosDto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Security")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Citas_Backend.Entities.CitasEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("char(36)")
                        .HasColumnName("doctor_id");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("estado");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("fecha");

                    b.Property<Guid>("PacienteId")
                        .HasColumnType("char(36)")
                        .HasColumnName("paciente_id");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("userId");

                    b.ToTable("citas", "cita");
                });

            modelBuilder.Entity("Citas_Backend.Entities.ConsultaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<decimal>("Altura")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("altura");

                    b.Property<string>("Antecedentes")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("antecedentes");

                    b.Property<Guid>("CitaId")
                        .HasColumnType("char(36)")
                        .HasColumnName("cita_id");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("comentario");

                    b.Property<string>("Diagnostico")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("diagnostico");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("fecha");

                    b.Property<string>("Medicamento")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("medicamento");

                    b.Property<string>("MotivoConsulta")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("motivo_consulta");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("peso");

                    b.HasKey("Id");

                    b.HasIndex("CitaId");

                    b.ToTable("consultas", "cita");
                });

            modelBuilder.Entity("Citas_Backend.Entities.DoctorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<Guid>("EspecialidadId")
                        .HasColumnType("char(36)")
                        .HasColumnName("especialidad_id");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.Property<Guid>("TurnoId")
                        .HasColumnType("char(36)")
                        .HasColumnName("turno_id");

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadId");

                    b.HasIndex("TurnoId");

                    b.ToTable("doctores", "Security");
                });

            modelBuilder.Entity("Citas_Backend.Entities.EspecialidadEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("descripcion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("especialidades", "cita");
                });

            modelBuilder.Entity("Citas_Backend.Entities.PacienteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("contrasena");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("correo_electronico");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("genero");

                    b.Property<string>("Identidad")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("identidad");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("fecha");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("telefono");

                    b.HasKey("Id");

                    b.ToTable("pacientes", "cita");
                });

            modelBuilder.Entity("Citas_Backend.Entities.TurnoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("DiaSemana")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("dia_semana");

                    b.Property<DateTime>("HoraFin")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("hora_fin");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("hora_inicio");

                    b.HasKey("Id");

                    b.ToTable("turnos", "cita");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("roles", "Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("roles_claims", "Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("users_claims", "Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("users_logins", "Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("users_roles", "Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("users_tokens", "Security");
                });

            modelBuilder.Entity("todo_list_backend.Entities.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("last_name");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("users", "Security");
                });

            modelBuilder.Entity("Citas_Backend.Entities.CitasEntity", b =>
                {
                    b.HasOne("Citas_Backend.Entities.DoctorEntity", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Citas_Backend.Entities.PacienteEntity", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("todo_list_backend.Entities.UserEntity", "User")
                        .WithMany("Cita")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Paciente");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Citas_Backend.Entities.ConsultaEntity", b =>
                {
                    b.HasOne("Citas_Backend.Entities.CitasEntity", "Cita")
                        .WithMany()
                        .HasForeignKey("CitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cita");
                });

            modelBuilder.Entity("Citas_Backend.Entities.DoctorEntity", b =>
                {
                    b.HasOne("Citas_Backend.Entities.EspecialidadEntity", "Especialidad")
                        .WithMany()
                        .HasForeignKey("EspecialidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Citas_Backend.Entities.TurnoEntity", "Turno")
                        .WithMany()
                        .HasForeignKey("TurnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidad");

                    b.Navigation("Turno");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("todo_list_backend.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("todo_list_backend.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("todo_list_backend.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("todo_list_backend.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("todo_list_backend.Entities.UserEntity", b =>
                {
                    b.Navigation("Cita");
                });
#pragma warning restore 612, 618
        }
    }
}
