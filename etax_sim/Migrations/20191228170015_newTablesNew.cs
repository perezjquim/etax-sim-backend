using Microsoft.EntityFrameworkCore.Migrations;

namespace eTaxSim.Migrations
{
    public partial class newTablesNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Country_StrategyByCountryByRegion_StrategyByCountryByRegionId",
                table: "Country");

            migrationBuilder.DropForeignKey(
                name: "FK_Country_StrategyByCountry_StrategyByCountryId",
                table: "Country");

            migrationBuilder.DropForeignKey(
                name: "FK_Region_StrategyByCountryByRegion_StrategyByCountryByRegionId",
                table: "Region");

            migrationBuilder.DropForeignKey(
                name: "FK_SimulationParamRule_ParamByStrategy_ParamByStrategyId",
                table: "SimulationParamRule");

            migrationBuilder.DropForeignKey(
                name: "FK_Strategy_ParamByStrategy_ParamByStrategyId",
                table: "Strategy");

            migrationBuilder.DropForeignKey(
                name: "FK_Strategy_StrategyByCountryByRegion_StrategyByCountryByRegion~",
                table: "Strategy");

            migrationBuilder.DropForeignKey(
                name: "FK_Strategy_StrategyByCountry_StrategyByCountryId",
                table: "Strategy");

            migrationBuilder.DropIndex(
                name: "IX_Strategy_ParamByStrategyId",
                table: "Strategy");

            migrationBuilder.DropIndex(
                name: "IX_Strategy_StrategyByCountryByRegionId",
                table: "Strategy");

            migrationBuilder.DropIndex(
                name: "IX_Strategy_StrategyByCountryId",
                table: "Strategy");

            migrationBuilder.DropIndex(
                name: "IX_SimulationParamRule_ParamByStrategyId",
                table: "SimulationParamRule");

            migrationBuilder.DropIndex(
                name: "IX_Region_StrategyByCountryByRegionId",
                table: "Region");

            migrationBuilder.DropIndex(
                name: "IX_Country_StrategyByCountryByRegionId",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Country_StrategyByCountryId",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "ParamByStrategyId",
                table: "Strategy");

            migrationBuilder.DropColumn(
                name: "StrategyByCountryByRegionId",
                table: "Strategy");

            migrationBuilder.DropColumn(
                name: "StrategyByCountryId",
                table: "Strategy");

            migrationBuilder.DropColumn(
                name: "ParamByStrategyId",
                table: "SimulationParamRule");

            migrationBuilder.DropColumn(
                name: "StrategyByCountryByRegionId",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "StrategyByCountryByRegionId",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "StrategyByCountryId",
                table: "Country");

            migrationBuilder.AddColumn<int>(
                name: "CountryId1",
                table: "StrategyByCountryByRegion",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId1",
                table: "StrategyByCountry",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrategyId1",
                table: "StrategyByCountry",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SimulationParamRuleId1",
                table: "ParamByStrategy",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrategyId1",
                table: "ParamByStrategy",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StrategyByCountryByRegion_CountryId1",
                table: "StrategyByCountryByRegion",
                column: "CountryId1");

            migrationBuilder.CreateIndex(
                name: "IX_StrategyByCountryByRegion_RegionId",
                table: "StrategyByCountryByRegion",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_StrategyByCountryByRegion_StrategyId",
                table: "StrategyByCountryByRegion",
                column: "StrategyId");

            migrationBuilder.CreateIndex(
                name: "IX_StrategyByCountry_CountryId1",
                table: "StrategyByCountry",
                column: "CountryId1");

            migrationBuilder.CreateIndex(
                name: "IX_StrategyByCountry_StrategyId1",
                table: "StrategyByCountry",
                column: "StrategyId1");

            migrationBuilder.CreateIndex(
                name: "IX_ParamByStrategy_SimulationParamRuleId1",
                table: "ParamByStrategy",
                column: "SimulationParamRuleId1");

            migrationBuilder.CreateIndex(
                name: "IX_ParamByStrategy_StrategyId1",
                table: "ParamByStrategy",
                column: "StrategyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ParamByStrategy_SimulationParamRule_SimulationParamRuleId1",
                table: "ParamByStrategy",
                column: "SimulationParamRuleId1",
                principalTable: "SimulationParamRule",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParamByStrategy_Strategy_StrategyId1",
                table: "ParamByStrategy",
                column: "StrategyId1",
                principalTable: "Strategy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StrategyByCountry_Country_CountryId1",
                table: "StrategyByCountry",
                column: "CountryId1",
                principalTable: "Country",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StrategyByCountry_Strategy_StrategyId1",
                table: "StrategyByCountry",
                column: "StrategyId1",
                principalTable: "Strategy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StrategyByCountryByRegion_Country_CountryId1",
                table: "StrategyByCountryByRegion",
                column: "CountryId1",
                principalTable: "Country",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StrategyByCountryByRegion_Region_RegionId",
                table: "StrategyByCountryByRegion",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StrategyByCountryByRegion_Strategy_StrategyId",
                table: "StrategyByCountryByRegion",
                column: "StrategyId",
                principalTable: "Strategy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParamByStrategy_SimulationParamRule_SimulationParamRuleId1",
                table: "ParamByStrategy");

            migrationBuilder.DropForeignKey(
                name: "FK_ParamByStrategy_Strategy_StrategyId1",
                table: "ParamByStrategy");

            migrationBuilder.DropForeignKey(
                name: "FK_StrategyByCountry_Country_CountryId1",
                table: "StrategyByCountry");

            migrationBuilder.DropForeignKey(
                name: "FK_StrategyByCountry_Strategy_StrategyId1",
                table: "StrategyByCountry");

            migrationBuilder.DropForeignKey(
                name: "FK_StrategyByCountryByRegion_Country_CountryId1",
                table: "StrategyByCountryByRegion");

            migrationBuilder.DropForeignKey(
                name: "FK_StrategyByCountryByRegion_Region_RegionId",
                table: "StrategyByCountryByRegion");

            migrationBuilder.DropForeignKey(
                name: "FK_StrategyByCountryByRegion_Strategy_StrategyId",
                table: "StrategyByCountryByRegion");

            migrationBuilder.DropIndex(
                name: "IX_StrategyByCountryByRegion_CountryId1",
                table: "StrategyByCountryByRegion");

            migrationBuilder.DropIndex(
                name: "IX_StrategyByCountryByRegion_RegionId",
                table: "StrategyByCountryByRegion");

            migrationBuilder.DropIndex(
                name: "IX_StrategyByCountryByRegion_StrategyId",
                table: "StrategyByCountryByRegion");

            migrationBuilder.DropIndex(
                name: "IX_StrategyByCountry_CountryId1",
                table: "StrategyByCountry");

            migrationBuilder.DropIndex(
                name: "IX_StrategyByCountry_StrategyId1",
                table: "StrategyByCountry");

            migrationBuilder.DropIndex(
                name: "IX_ParamByStrategy_SimulationParamRuleId1",
                table: "ParamByStrategy");

            migrationBuilder.DropIndex(
                name: "IX_ParamByStrategy_StrategyId1",
                table: "ParamByStrategy");

            migrationBuilder.DropColumn(
                name: "CountryId1",
                table: "StrategyByCountryByRegion");

            migrationBuilder.DropColumn(
                name: "CountryId1",
                table: "StrategyByCountry");

            migrationBuilder.DropColumn(
                name: "StrategyId1",
                table: "StrategyByCountry");

            migrationBuilder.DropColumn(
                name: "SimulationParamRuleId1",
                table: "ParamByStrategy");

            migrationBuilder.DropColumn(
                name: "StrategyId1",
                table: "ParamByStrategy");

            migrationBuilder.AddColumn<int>(
                name: "ParamByStrategyId",
                table: "Strategy",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrategyByCountryByRegionId",
                table: "Strategy",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrategyByCountryId",
                table: "Strategy",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParamByStrategyId",
                table: "SimulationParamRule",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrategyByCountryByRegionId",
                table: "Region",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrategyByCountryByRegionId",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrategyByCountryId",
                table: "Country",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Strategy_ParamByStrategyId",
                table: "Strategy",
                column: "ParamByStrategyId");

            migrationBuilder.CreateIndex(
                name: "IX_Strategy_StrategyByCountryByRegionId",
                table: "Strategy",
                column: "StrategyByCountryByRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Strategy_StrategyByCountryId",
                table: "Strategy",
                column: "StrategyByCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SimulationParamRule_ParamByStrategyId",
                table: "SimulationParamRule",
                column: "ParamByStrategyId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_StrategyByCountryByRegionId",
                table: "Region",
                column: "StrategyByCountryByRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_StrategyByCountryByRegionId",
                table: "Country",
                column: "StrategyByCountryByRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_StrategyByCountryId",
                table: "Country",
                column: "StrategyByCountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Country_StrategyByCountryByRegion_StrategyByCountryByRegionId",
                table: "Country",
                column: "StrategyByCountryByRegionId",
                principalTable: "StrategyByCountryByRegion",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Country_StrategyByCountry_StrategyByCountryId",
                table: "Country",
                column: "StrategyByCountryId",
                principalTable: "StrategyByCountry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Region_StrategyByCountryByRegion_StrategyByCountryByRegionId",
                table: "Region",
                column: "StrategyByCountryByRegionId",
                principalTable: "StrategyByCountryByRegion",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SimulationParamRule_ParamByStrategy_ParamByStrategyId",
                table: "SimulationParamRule",
                column: "ParamByStrategyId",
                principalTable: "ParamByStrategy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Strategy_ParamByStrategy_ParamByStrategyId",
                table: "Strategy",
                column: "ParamByStrategyId",
                principalTable: "ParamByStrategy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Strategy_StrategyByCountryByRegion_StrategyByCountryByRegion~",
                table: "Strategy",
                column: "StrategyByCountryByRegionId",
                principalTable: "StrategyByCountryByRegion",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Strategy_StrategyByCountry_StrategyByCountryId",
                table: "Strategy",
                column: "StrategyByCountryId",
                principalTable: "StrategyByCountry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
