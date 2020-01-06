using Microsoft.EntityFrameworkCore.Migrations;

namespace eTaxSim.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StrategyByCountryId",
                table: "StrategyByCountryByRegion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StrategyByCountryByRegion_StrategyByCountryId",
                table: "StrategyByCountryByRegion",
                column: "StrategyByCountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_StrategyByCountryByRegion_StrategyByCountry_StrategyByCountr~",
                table: "StrategyByCountryByRegion",
                column: "StrategyByCountryId",
                principalTable: "StrategyByCountry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StrategyByCountryByRegion_StrategyByCountry_StrategyByCountr~",
                table: "StrategyByCountryByRegion");

            migrationBuilder.DropIndex(
                name: "IX_StrategyByCountryByRegion_StrategyByCountryId",
                table: "StrategyByCountryByRegion");

            migrationBuilder.DropColumn(
                name: "StrategyByCountryId",
                table: "StrategyByCountryByRegion");
        }
    }
}
