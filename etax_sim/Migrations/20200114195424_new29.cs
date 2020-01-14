using Microsoft.EntityFrameworkCore.Migrations;

namespace eTaxSim.Migrations
{
    public partial class new29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentStrategyId",
                table: "StrategyByCountryByRegion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
