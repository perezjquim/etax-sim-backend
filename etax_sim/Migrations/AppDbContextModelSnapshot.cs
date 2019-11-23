﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using etax_sim.Models;

namespace etax_sim.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("etax_sim.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("Name");

                    b.HasKey("CountryId");

                    b.ToTable("countries");
                });

            modelBuilder.Entity("etax_sim.Models.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("Name");

                    b.HasKey("RegionId");

                    b.HasIndex("CountryId");

                    b.ToTable("regions");
                });

            modelBuilder.Entity("etax_sim.Models.Region", b =>
                {
                    b.HasOne("etax_sim.Models.Country", "Country")
                        .WithMany("Regions")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
