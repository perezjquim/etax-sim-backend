using Microsoft.EntityFrameworkCore.Migrations;

namespace eTaxSim.Migrations
{
    public partial class new34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                 name: "StrategyByCountryId",
                 table: "Country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                 name: "StrategyByCountryId",
                 table: "Country");
        }
    }
}
