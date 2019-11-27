using Microsoft.EntityFrameworkCore.Migrations;

namespace etax_sim.Migrations
{
    public partial class _231120193 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "IRSTax",
                table: "__CALC_PT_IRS_TRAB_DEP__",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "IRSTax",
                table: "__CALC_PT_IRS_PENS__",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IRSTax",
                table: "__CALC_PT_IRS_TRAB_DEP__");

            migrationBuilder.DropColumn(
                name: "IRSTax",
                table: "__CALC_PT_IRS_PENS__");
        }
    }
}
