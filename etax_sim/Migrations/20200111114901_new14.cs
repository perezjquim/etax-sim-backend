using Microsoft.EntityFrameworkCore.Migrations;

namespace eTaxSim.Migrations
{
    public partial class new14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "StrategyByCountryByRegion");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "StrategyByCountry");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "StrategyByCountryByRegion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "StrategyByCountry",
                nullable: true);
        }
    }
}
