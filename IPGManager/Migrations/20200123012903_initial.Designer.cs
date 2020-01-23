﻿// <auto-generated />
using System;
using IPGManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IPGManager.Migrations
{
    [DbContext(typeof(IPGManagerDBContext))]
    [Migration("20200123012903_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IPGManager.Models.Cargo", b =>
                {
                    b.Property<int>("CargoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NivelCargo")
                        .HasColumnType("int");

                    b.Property<string>("NomeCargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CargoId");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("IPGManager.Models.Departamento", b =>
                {
                    b.Property<int>("DepartamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeDepartamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("DepartamentoId");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("IPGManager.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("FuncionarioId");

                    b.HasIndex("CargoId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("IPGManager.Models.Genero", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GeneroTipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GeneroId");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("IPGManager.Models.Login", b =>
                {
                    b.Property<string>("LoginId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginId");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("IPGManager.Models.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ProfessorId");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("IPGManager.Models.Tarefa", b =>
                {
                    b.Property<int>("TarefaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataTarefa")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoTarefa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeTarefa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TarefaId");

                    b.HasIndex("CargoId");

                    b.ToTable("Tarefa");
                });

            modelBuilder.Entity("IPGManager.Models.Funcionario", b =>
                {
                    b.HasOne("IPGManager.Models.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IPGManager.Models.Genero", "Genero")
                        .WithMany("Funcionarios")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IPGManager.Models.Professor", b =>
                {
                    b.HasOne("IPGManager.Models.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IPGManager.Models.Genero", "Genero")
                        .WithMany("Professores")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IPGManager.Models.Tarefa", b =>
                {
                    b.HasOne("IPGManager.Models.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
