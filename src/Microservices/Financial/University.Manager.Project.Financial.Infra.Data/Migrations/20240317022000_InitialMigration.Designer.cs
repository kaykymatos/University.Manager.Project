﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using University.Manager.Project.Financial.Infra.Data.Context;

#nullable disable

namespace University.Manager.Project.Financial.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240317022000_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("University.Manager.Project.Financial.Domain.Entities.CourseInstallments", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationData")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InstallmentPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<long>("InstallmentsNumber")
                        .HasColumnType("bigint");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedData")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CourseInstallments");
                });
#pragma warning restore 612, 618
        }
    }
}