using Microsoft.EntityFrameworkCore.Migrations;

namespace eTaxSim.Migrations
{
    public partial class new3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimulationLogParam_ParamByStrategy_GetParamByStrategyId",
                table: "SimulationLogParam");

            migrationBuilder.RenameColumn(
                name: "GetParamByStrategyId",
                table: "SimulationLogParam",
                newName: "ParamByStrategyId");

            migrationBuilder.RenameIndex(
                name: "IX_SimulationLogParam_GetParamByStrategyId",
                table: "SimulationLogParam",
                newName: "IX_SimulationLogParam_ParamByStrategyId");

            migrationBuilder.AddForeignKey(
                name: "FK_SimulationLogParam_ParamByStrategy_ParamByStrategyId",
                table: "SimulationLogParam",
                column: "ParamByStrategyId",
                principalTable: "ParamByStrategy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimulationLogParam_ParamByStrategy_ParamByStrategyId",
                table: "SimulationLogParam");

            migrationBuilder.RenameColumn(
                name: "ParamByStrategyId",
                table: "SimulationLogParam",
                newName: "GetParamByStrategyId");

            migrationBuilder.RenameIndex(
                name: "IX_SimulationLogParam_ParamByStrategyId",
                table: "SimulationLogParam",
                newName: "IX_SimulationLogParam_GetParamByStrategyId");

            migrationBuilder.AddForeignKey(
                name: "FK_SimulationLogParam_ParamByStrategy_GetParamByStrategyId",
                table: "SimulationLogParam",
                column: "GetParamByStrategyId",
                principalTable: "ParamByStrategy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
