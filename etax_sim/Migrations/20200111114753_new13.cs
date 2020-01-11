using Microsoft.EntityFrameworkCore.Migrations;

namespace eTaxSim.Migrations
{
    public partial class new13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StrategyByCountryByRegion_Strategy_ParentStrategyId",
                table: "StrategyByCountryByRegion");

            migrationBuilder.DropIndex(
                name: "IX_StrategyByCountryByRegion_ParentStrategyId",
                table: "StrategyByCountryByRegion");

            migrationBuilder.DropColumn(
                name: "ParentStrategyId",
                table: "StrategyByCountryByRegion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentStrategyId",
                table: "StrategyByCountryByRegion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StrategyByCountryByRegion_ParentStrategyId",
                table: "StrategyByCountryByRegion",
                column: "ParentStrategyId");

            migrationBuilder.AddForeignKey(
                name: "FK_StrategyByCountryByRegion_Strategy_ParentStrategyId",
                table: "StrategyByCountryByRegion",
                column: "ParentStrategyId",
                principalTable: "Strategy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
