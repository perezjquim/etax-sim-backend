using Microsoft.EntityFrameworkCore.Migrations;

namespace eTaxSim.Migrations
{
    public partial class new35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                 name: "StrategyByCountryId",
                 table: "Country");

            migrationBuilder.DropColumn(
                 name: "StrategyByCountryByRegionId",
                 table: "Country");

            migrationBuilder.DropColumn(
                 name: "StrategyByCountryByRegionId",
                 table: "Region");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                 name: "StrategyByCountryId",
                 table: "Country");

            migrationBuilder.DropColumn(
                 name: "StrategyByCountryByRegionId",
                 table: "Country");

            migrationBuilder.DropColumn(
                 name: "StrategyByCountryByRegionId",
                 table: "Region");
        }
    }
}
