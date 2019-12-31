using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eTaxSim.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "StrategyByCountryByRegion",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false),
                    StrategyId = table.Column<int>(nullable: false),
                    ParentStrategyId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrategyByCountryByRegion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StrategyByCountryByRegion_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StrategyByCountryByRegion_Strategy_ParentStrategyId",
                        column: x => x.ParentStrategyId,
                        principalTable: "Strategy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StrategyByCountryByRegion_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StrategyByCountryByRegion_Strategy_StrategyId",
                        column: x => x.StrategyId,
                        principalTable: "Strategy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            

            migrationBuilder.CreateIndex(
                name: "IX_StrategyByCountryByRegion_CountryId",
                table: "StrategyByCountryByRegion",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_StrategyByCountryByRegion_ParentStrategyId",
                table: "StrategyByCountryByRegion",
                column: "ParentStrategyId");

            migrationBuilder.CreateIndex(
                name: "IX_StrategyByCountryByRegion_RegionId",
                table: "StrategyByCountryByRegion",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_StrategyByCountryByRegion_StrategyId",
                table: "StrategyByCountryByRegion",
                column: "StrategyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__CALC_PT_IRS_PENS__");

            migrationBuilder.DropTable(
                name: "__CALC_PT_IRS_TRAB_DEP__");

            migrationBuilder.DropTable(
                name: "ParamByStrategy");

            migrationBuilder.DropTable(
                name: "SimulationLogParam");

            migrationBuilder.DropTable(
                name: "StrategyByCountry");

            migrationBuilder.DropTable(
                name: "StrategyByCountryByRegion");

            migrationBuilder.DropTable(
                name: "SimulationParamRule");

            migrationBuilder.DropTable(
                name: "SimulationLog");

            migrationBuilder.DropTable(
                name: "Strategy");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Sector");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
