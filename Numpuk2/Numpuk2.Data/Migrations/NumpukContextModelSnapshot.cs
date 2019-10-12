﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Numpuk2.Data;

namespace Numpuk2.Data.Migrations
{
    [DbContext(typeof(NumpukContext))]
    partial class NumpukContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Numpuk2.Domain.Client", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Numpuk2.Domain.Examination", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<double>("ClientAge")
                        .HasColumnType("double precision");

                    b.Property<string>("ClientId")
                        .HasColumnType("text");

                    b.Property<int>("Consistency")
                        .HasColumnType("integer");

                    b.Property<double?>("GeneralNumberOfBacteria")
                        .HasColumnType("double precision");

                    b.Property<bool?>("HasAkkermansiaMuciniphila")
                        .HasColumnType("boolean");

                    b.Property<bool?>("HasFaecalibactriumPrausnitzii")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("MaterialRegistrationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double?>("PhValue")
                        .HasColumnType("double precision");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Examinations");
                });

            modelBuilder.Entity("Numpuk2.Domain.Result", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ExaminationId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ExaminationId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("Numpuk2.Domain.Examination", b =>
                {
                    b.HasOne("Numpuk2.Domain.Client", "Client")
                        .WithMany("Examinations")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("Numpuk2.Domain.Result", b =>
                {
                    b.HasOne("Numpuk2.Domain.Examination", null)
                        .WithMany("Results")
                        .HasForeignKey("ExaminationId");
                });
#pragma warning restore 612, 618
        }
    }
}
