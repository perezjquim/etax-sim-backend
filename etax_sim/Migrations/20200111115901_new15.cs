using Microsoft.EntityFrameworkCore.Migrations;

namespace eTaxSim.Migrations
{
    public partial class new15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MinValue",
                table: "StrategyParamRule",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "MaxValue",
                table: "StrategyParamRule",
                nullable: true,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MinValue",
                table: "StrategyParamRule",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MaxValue",
                table: "StrategyParamRule",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
