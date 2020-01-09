using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eTaxSim.Migrations
{
    public partial class new4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParamByStrategy_SimulationParamRule_SimulationParamRuleId",
                table: "ParamByStrategy");

            migrationBuilder.DropTable(
                name: "SimulationParamRule");

            migrationBuilder.CreateTable(
                name: "StrategyParamRule",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MinValue = table.Column<double>(nullable: false),
                    MaxValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrategyParamRule", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ParamByStrategy_StrategyParamRule_SimulationParamRuleId",
                table: "ParamByStrategy",
                column: "SimulationParamRuleId",
                principalTable: "StrategyParamRule",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParamByStrategy_StrategyParamRule_SimulationParamRuleId",
                table: "ParamByStrategy");

            migrationBuilder.DropTable(
                name: "StrategyParamRule");

            migrationBuilder.CreateTable(
                name: "SimulationParamRule",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MaxValue = table.Column<double>(nullable: false),
                    MinValue = table.Column<double>(nullable: false),
                    ParamName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimulationParamRule", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ParamByStrategy_SimulationParamRule_SimulationParamRuleId",
                table: "ParamByStrategy",
                column: "SimulationParamRuleId",
                principalTable: "SimulationParamRule",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
