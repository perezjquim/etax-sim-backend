using Microsoft.EntityFrameworkCore.Migrations;

namespace eTaxSim.Migrations
{
    public partial class new5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParamByStrategy_StrategyParamRule_SimulationParamRuleId",
                table: "ParamByStrategy");

            migrationBuilder.DropIndex(
                name: "IX_ParamByStrategy_SimulationParamRuleId",
                table: "ParamByStrategy");

            migrationBuilder.AddColumn<int>(
                name: "StrategyParamRuleId",
                table: "ParamByStrategy",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParamByStrategy_StrategyParamRuleId",
                table: "ParamByStrategy",
                column: "StrategyParamRuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParamByStrategy_StrategyParamRule_StrategyParamRuleId",
                table: "ParamByStrategy",
                column: "StrategyParamRuleId",
                principalTable: "StrategyParamRule",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParamByStrategy_StrategyParamRule_StrategyParamRuleId",
                table: "ParamByStrategy");

            migrationBuilder.DropIndex(
                name: "IX_ParamByStrategy_StrategyParamRuleId",
                table: "ParamByStrategy");

            migrationBuilder.DropColumn(
                name: "StrategyParamRuleId",
                table: "ParamByStrategy");

            migrationBuilder.CreateIndex(
                name: "IX_ParamByStrategy_SimulationParamRuleId",
                table: "ParamByStrategy",
                column: "SimulationParamRuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParamByStrategy_StrategyParamRule_SimulationParamRuleId",
                table: "ParamByStrategy",
                column: "SimulationParamRuleId",
                principalTable: "StrategyParamRule",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
