using Microsoft.EntityFrameworkCore.Migrations;

namespace eTaxSim.Migrations
{
    public partial class new9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StrategyByCountryByRegion_Strategy_ParentStrategyId",
                table: "StrategyByCountryByRegion");

            migrationBuilder.AlterColumn<int>(
                name: "ParentStrategyId",
                table: "StrategyByCountryByRegion",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_StrategyByCountryByRegion_Strategy_ParentStrategyId",
                table: "StrategyByCountryByRegion",
                column: "ParentStrategyId",
                principalTable: "Strategy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StrategyByCountryByRegion_Strategy_ParentStrategyId",
                table: "StrategyByCountryByRegion");

            migrationBuilder.AlterColumn<int>(
                name: "ParentStrategyId",
                table: "StrategyByCountryByRegion",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StrategyByCountryByRegion_Strategy_ParentStrategyId",
                table: "StrategyByCountryByRegion",
                column: "ParentStrategyId",
                principalTable: "Strategy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
