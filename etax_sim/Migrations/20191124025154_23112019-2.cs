using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace etax_sim.Migrations
{
    public partial class _231120192 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__CALC_IRS_PT__");

            migrationBuilder.DropColumn(
                name: "Max",
                table: "SimulationParamRule");

            migrationBuilder.DropColumn(
                name: "Min",
                table: "SimulationParamRule");

            migrationBuilder.AddColumn<double>(
                name: "MaxValue",
                table: "SimulationParamRule",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MinValue",
                table: "SimulationParamRule",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "SimulationType",
                table: "SimulationLog",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "__CALC_PT_IRS_PENS__",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumberOfMarriageHolders = table.Column<int>(nullable: false),
                    IsHandicapped = table.Column<bool>(nullable: false),
                    IsArmedForces = table.Column<bool>(nullable: false),
                    MaxSalary = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___CALC_PT_IRS_PENS__", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "__CALC_PT_IRS_TRAB_DEP__",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumberOfMarriageHolders = table.Column<int>(nullable: false),
                    IsHandicapped = table.Column<bool>(nullable: false),
                    MaxSalary = table.Column<double>(nullable: false),
                    NumberOfDependants = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___CALC_PT_IRS_TRAB_DEP__", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__CALC_PT_IRS_PENS__");

            migrationBuilder.DropTable(
                name: "__CALC_PT_IRS_TRAB_DEP__");

            migrationBuilder.DropColumn(
                name: "MaxValue",
                table: "SimulationParamRule");

            migrationBuilder.DropColumn(
                name: "MinValue",
                table: "SimulationParamRule");

            migrationBuilder.DropColumn(
                name: "SimulationType",
                table: "SimulationLog");

            migrationBuilder.AddColumn<int>(
                name: "Max",
                table: "SimulationParamRule",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Min",
                table: "SimulationParamRule",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "__CALC_IRS_PT__",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___CALC_IRS_PT__", x => x.ID);
                });
        }
    }
}
