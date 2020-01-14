using Microsoft.EntityFrameworkCore.Migrations;

namespace eTaxSim.Migrations
{
    public partial class new28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(
                name: "ParentStrategyId",
                table: "StrategyByCountryByRegion");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "StrategyByCountryId",
                table: "StrategyByCountryByRegion",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StrategyByCountryByRegion_StrategyByCountry_StrategyByCountr~",
                table: "StrategyByCountryByRegion",
                column: "StrategyByCountryId",
                principalTable: "StrategyByCountry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
