﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eTaxSim.Models;

namespace eTaxSim.Migrations
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

            modelBuilder.Entity("eTaxSim.Models.CalcPT_IRSPens", b =>
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

            modelBuilder.Entity("eTaxSim.Models.CalcPT_IRSTrabDep", b =>
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

            modelBuilder.Entity("eTaxSim.Models.Company", b =>
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

            modelBuilder.Entity("eTaxSim.Models.Country", b =>
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

            modelBuilder.Entity("eTaxSim.Models.ParamByStrategy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<bool>("IsInput")
                        .HasColumnName("IsInput");

                    b.Property<string>("ParamName")
                        .HasColumnName("ParamName");

                    b.Property<int>("StrategyId")
                        .HasColumnName("StrategyId");

                    b.Property<int?>("StrategyParamRuleId");

                    b.HasKey("Id");

                    b.HasIndex("StrategyId");

                    b.HasIndex("StrategyParamRuleId");

                    b.ToTable("ParamByStrategy");
                });

            modelBuilder.Entity("eTaxSim.Models.Region", b =>
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

            modelBuilder.Entity("eTaxSim.Models.Role", b =>
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

            modelBuilder.Entity("eTaxSim.Models.Sector", b =>
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

            modelBuilder.Entity("eTaxSim.Models.SimulationLog", b =>
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

            modelBuilder.Entity("eTaxSim.Models.SimulationLogParam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnName("ModifiedAt");

                    b.Property<int?>("ParamByStrategyId");

                    b.Property<string>("ParamValue")
                        .HasColumnName("ParamValue");

                    b.Property<int?>("SimulationLogId");

                    b.HasKey("Id");

                    b.HasIndex("ParamByStrategyId");

                    b.HasIndex("SimulationLogId");

                    b.ToTable("SimulationLogParam");
                });

            modelBuilder.Entity("eTaxSim.Models.Strategy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Strategy");
                });

            modelBuilder.Entity("eTaxSim.Models.StrategyByCountry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int>("CountryId")
                        .HasColumnName("CountryId");

                    b.Property<int>("StrategyId")
                        .HasColumnName("StrategyId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("StrategyId");

                    b.ToTable("StrategyByCountry");
                });

            modelBuilder.Entity("eTaxSim.Models.StrategyByCountryByRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int>("CountryId")
                        .HasColumnName("CountryId");

                    b.Property<int>("RegionId")
                        .HasColumnName("RegionId");

                    b.Property<int?>("StrategyByCountryId");

                    b.Property<int>("StrategyId")
                        .HasColumnName("StrategyId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("RegionId");

                    b.HasIndex("StrategyByCountryId");

                    b.HasIndex("StrategyId");

                    b.ToTable("StrategyByCountryByRegion");
                });

            modelBuilder.Entity("eTaxSim.Models.StrategyParamRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<double?>("MaxValue")
                        .HasColumnName("MaxValue");

                    b.Property<double?>("MinValue")
                        .HasColumnName("MinValue");

                    b.HasKey("Id");

                    b.ToTable("StrategyParamRule");
                });

            modelBuilder.Entity("eTaxSim.Models.Company", b =>
                {
                    b.HasOne("eTaxSim.Models.Region", "Region")
                        .WithMany("Companies")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eTaxSim.Models.Sector", "Sector")
                        .WithMany("Companies")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eTaxSim.Models.ParamByStrategy", b =>
                {
                    b.HasOne("eTaxSim.Models.Strategy", "Strategy")
                        .WithMany("ParamByStrategy")
                        .HasForeignKey("StrategyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eTaxSim.Models.StrategyParamRule", "StrategyParamRule")
                        .WithMany()
                        .HasForeignKey("StrategyParamRuleId");
                });

            modelBuilder.Entity("eTaxSim.Models.Region", b =>
                {
                    b.HasOne("eTaxSim.Models.Country", "Country")
                        .WithMany("Regions")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eTaxSim.Models.Role", b =>
                {
                    b.HasOne("eTaxSim.Models.Company", "Company")
                        .WithMany("Roles")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eTaxSim.Models.SimulationLog", b =>
                {
                    b.HasOne("eTaxSim.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eTaxSim.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eTaxSim.Models.SimulationLogParam", b =>
                {
                    b.HasOne("eTaxSim.Models.ParamByStrategy", "ParamByStrategy")
                        .WithMany()
                        .HasForeignKey("ParamByStrategyId");

                    b.HasOne("eTaxSim.Models.SimulationLog", "SimulationLog")
                        .WithMany("Params")
                        .HasForeignKey("SimulationLogId");
                });

            modelBuilder.Entity("eTaxSim.Models.StrategyByCountry", b =>
                {
                    b.HasOne("eTaxSim.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eTaxSim.Models.Strategy", "Strategy")
                        .WithMany()
                        .HasForeignKey("StrategyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eTaxSim.Models.StrategyByCountryByRegion", b =>
                {
                    b.HasOne("eTaxSim.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eTaxSim.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eTaxSim.Models.StrategyByCountry", "StrategyByCountry")
                        .WithMany("StrategyByCountryByRegion")
                        .HasForeignKey("StrategyByCountryId");

                    b.HasOne("eTaxSim.Models.Strategy", "Strategy")
                        .WithMany()
                        .HasForeignKey("StrategyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
