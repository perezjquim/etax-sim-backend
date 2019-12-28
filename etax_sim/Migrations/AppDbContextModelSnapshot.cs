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

            modelBuilder.Entity("etax_sim.Models.CalcPT_IRSPens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<double>("IRSTax")
                        .HasColumnName("IRSTax");

                    b.Property<bool>("IsArmedForces")
                        .HasColumnName("IsArmedForces");

                    b.Property<bool>("IsHandicapped")
                        .HasColumnName("IsHandicapped");

                    b.Property<double>("MaxSalary")
                        .HasColumnName("MaxSalary");

                    b.Property<int>("NumberOfMarriageHolders")
                        .HasColumnName("NumberOfMarriageHolders");

                    b.HasKey("Id");

                    b.ToTable("__CALC_PT_IRS_PENS__");
                });

            modelBuilder.Entity("etax_sim.Models.CalcPT_IRSTrabDep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<double>("IRSTax")
                        .HasColumnName("IRSTax");

                    b.Property<bool>("IsHandicapped")
                        .HasColumnName("IsHandicapped");

                    b.Property<double>("MaxSalary")
                        .HasColumnName("MaxSalary");

                    b.Property<int>("NumberOfDependants")
                        .HasColumnName("NumberOfDependants");

                    b.Property<int>("NumberOfMarriageHolders")
                        .HasColumnName("NumberOfMarriageHolders");

                    b.HasKey("Id");

                    b.ToTable("__CALC_PT_IRS_TRAB_DEP__");
                });

            modelBuilder.Entity("etax_sim.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Description")
                        .HasColumnName("Description");

                    b.Property<bool>("IsActive")
                        .HasColumnName("IsActive");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnName("ModifiedAt");

                    b.Property<string>("Name")
                        .HasColumnName("Name");

                    b.Property<int>("RegionId")
                        .HasColumnName("RegionId");

                    b.Property<int>("SectorId")
                        .HasColumnName("SectorId");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.HasIndex("SectorId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("etax_sim.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Description")
                        .HasColumnName("Description");

                    b.Property<bool>("IsActive")
                        .HasColumnName("IsActive");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnName("ModifiedAt");

                    b.Property<string>("Name")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("etax_sim.Models.ParamByStrategy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<double>("ParamName")
                        .HasColumnName("ParamName");

                    b.Property<double>("ParamValue")
                        .HasColumnName("ParamValue");

                    b.Property<double>("SimulationParamRuleId")
                        .HasColumnName("SimulationParamRuleId");

                    b.Property<int?>("SimulationParamRuleId1");

                    b.Property<string>("StrategyId")
                        .HasColumnName("StrategyId");

                    b.Property<int?>("StrategyId1");

                    b.HasKey("Id");

                    b.HasIndex("SimulationParamRuleId1");

                    b.HasIndex("StrategyId1");

                    b.ToTable("ParamByStrategy");
                });

            modelBuilder.Entity("etax_sim.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int>("CountryId")
                        .HasColumnName("CountryId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Description")
                        .HasColumnName("Description");

                    b.Property<bool>("IsActive")
                        .HasColumnName("IsActive");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnName("ModifiedAt");

                    b.Property<string>("Name")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("etax_sim.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int>("CompanyId")
                        .HasColumnName("CompanyId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Description")
                        .HasColumnName("Description");

                    b.Property<bool>("IsActive")
                        .HasColumnName("IsActive");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnName("ModifiedAt");

                    b.Property<string>("Name")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("etax_sim.Models.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Description")
                        .HasColumnName("Description");

                    b.Property<bool>("IsActive")
                        .HasColumnName("IsActive");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnName("ModifiedAt");

                    b.Property<string>("Name")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Sector");
                });

            modelBuilder.Entity("etax_sim.Models.SimulationLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnName("ModifiedAt");

                    b.Property<int>("RegionId")
                        .HasColumnName("RegionId");

                    b.Property<int>("RoleId")
                        .HasColumnName("RoleId");

                    b.Property<string>("SimulationType")
                        .HasColumnName("SimulationType");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.HasIndex("RoleId");

                    b.ToTable("SimulationLog");
                });

            modelBuilder.Entity("etax_sim.Models.SimulationLogParam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt");

                    b.Property<bool>("IsInput")
                        .HasColumnName("IsInput");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnName("ModifiedAt");

                    b.Property<string>("ParamName")
                        .HasColumnName("ParamName");

                    b.Property<string>("ParamValue")
                        .HasColumnName("ParamValue");

                    b.Property<int>("SimulationLogId")
                        .HasColumnName("SimulationLogId");

                    b.HasKey("Id");

                    b.HasIndex("SimulationLogId");

                    b.ToTable("SimulationLogParam");
                });

            modelBuilder.Entity("etax_sim.Models.SimulationParamRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<double>("MaxValue")
                        .HasColumnName("MaxValue");

                    b.Property<double>("MinValue")
                        .HasColumnName("MinValue");

                    b.Property<string>("ParamName")
                        .HasColumnName("ParamName");

                    b.HasKey("Id");

                    b.ToTable("SimulationParamRule");
                });

            modelBuilder.Entity("etax_sim.Models.Strategy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Strategy");
                });

            modelBuilder.Entity("etax_sim.Models.StrategyByCountry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("CountryId")
                        .HasColumnName("CountryId");

                    b.Property<int?>("CountryId1");

                    b.Property<double>("Description")
                        .HasColumnName("Description");

                    b.Property<string>("StrategyId")
                        .HasColumnName("StrategyId");

                    b.Property<int?>("StrategyId1");

                    b.HasKey("Id");

                    b.HasIndex("CountryId1");

                    b.HasIndex("StrategyId1");

                    b.ToTable("StrategyByCountry");
                });

            modelBuilder.Entity("etax_sim.Models.StrategyByCountryByRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("CountryId")
                        .HasColumnName("CountryId");

                    b.Property<int?>("CountryId1");

                    b.Property<double>("Description")
                        .HasColumnName("Description");

                    b.Property<int>("RegionId")
                        .HasColumnName("RegionId");

                    b.Property<int>("StrategyId")
                        .HasColumnName("StrategyId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId1");

                    b.HasIndex("RegionId");

                    b.HasIndex("StrategyId");

                    b.ToTable("StrategyByCountryByRegion");
                });

            modelBuilder.Entity("etax_sim.Models.Company", b =>
                {
                    b.HasOne("etax_sim.Models.Region", "Region")
                        .WithMany("Companies")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("etax_sim.Models.Sector", "Sector")
                        .WithMany("Companies")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("etax_sim.Models.ParamByStrategy", b =>
                {
                    b.HasOne("etax_sim.Models.SimulationParamRule", "SimulationParamRule")
                        .WithMany()
                        .HasForeignKey("SimulationParamRuleId1");

                    b.HasOne("etax_sim.Models.Strategy", "Strategy")
                        .WithMany()
                        .HasForeignKey("StrategyId1");
                });

            modelBuilder.Entity("etax_sim.Models.Region", b =>
                {
                    b.HasOne("etax_sim.Models.Country", "Country")
                        .WithMany("Regions")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("etax_sim.Models.Role", b =>
                {
                    b.HasOne("etax_sim.Models.Company", "Company")
                        .WithMany("Roles")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("etax_sim.Models.SimulationLog", b =>
                {
                    b.HasOne("etax_sim.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("etax_sim.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("etax_sim.Models.SimulationLogParam", b =>
                {
                    b.HasOne("etax_sim.Models.SimulationLog", "SimulationLog")
                        .WithMany("Params")
                        .HasForeignKey("SimulationLogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("etax_sim.Models.StrategyByCountry", b =>
                {
                    b.HasOne("etax_sim.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId1");

                    b.HasOne("etax_sim.Models.Strategy", "Strategy")
                        .WithMany()
                        .HasForeignKey("StrategyId1");
                });

            modelBuilder.Entity("etax_sim.Models.StrategyByCountryByRegion", b =>
                {
                    b.HasOne("etax_sim.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId1");

                    b.HasOne("etax_sim.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("etax_sim.Models.Strategy", "Strategy")
                        .WithMany()
                        .HasForeignKey("StrategyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
