﻿// <auto-generated />
using System;
using DBModules.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFDatabase.Migrations
{
    [DbContext(typeof(EFTestDbContext))]
    partial class EFTestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DBModules.SQL.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("SupervisorId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("SupervisorId");

                    b.ToTable("Departments", (string)null);
                });

            modelBuilder.Entity("DBModules.SQL.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("DBModules.SQL.Models.EmployeeProject", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("char(36)");

                    b.Property<string>("EmployeeRole")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeProjects");
                });

            modelBuilder.Entity("DBModules.SQL.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Locations", (string)null);
                });

            modelBuilder.Entity("DBModules.SQL.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("SupervisorId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("SupervisorId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DBModules.SQL.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("salary_amount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("DBModules.SQL.Models.Supervisor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Supervisors", (string)null);
                });

            modelBuilder.Entity("DBModules.SQL.Models.Department", b =>
                {
                    b.HasOne("DBModules.SQL.Models.Location", "Location")
                        .WithMany("Departments")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBModules.SQL.Models.Supervisor", "Supervisor")
                        .WithMany("Departments")
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("DBModules.SQL.Models.Employee", b =>
                {
                    b.HasOne("DBModules.SQL.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBModules.SQL.Models.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DBModules.SQL.Models.EmployeeProject", b =>
                {
                    b.HasOne("DBModules.SQL.Models.Employee", "Employee")
                        .WithMany("EmployeeProject")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBModules.SQL.Models.Project", "Project")
                        .WithMany("EmployeeProject")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DBModules.SQL.Models.Project", b =>
                {
                    b.HasOne("DBModules.SQL.Models.Supervisor", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("DBModules.SQL.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("DBModules.SQL.Models.Employee", b =>
                {
                    b.Navigation("EmployeeProject");
                });

            modelBuilder.Entity("DBModules.SQL.Models.Location", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("DBModules.SQL.Models.Project", b =>
                {
                    b.Navigation("EmployeeProject");
                });

            modelBuilder.Entity("DBModules.SQL.Models.Role", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("DBModules.SQL.Models.Supervisor", b =>
                {
                    b.Navigation("Departments");
                });
#pragma warning restore 612, 618
        }
    }
}
