using Microsoft.EntityFrameworkCore.Migrations;

namespace eTaxSim.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimulationLogParam_SimulationLog_SimulationLogId",
                table: "SimulationLogParam");

            migrationBuilder.DropColumn(
                name: "IsInput",
                table: "SimulationLogParam");

            migrationBuilder.DropColumn(
                name: "ParamName",
                table: "SimulationLogParam");

            migrationBuilder.AlterColumn<int>(
                name: "SimulationLogId",
                table: "SimulationLogParam",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "GetParamByStrategyId",
                table: "SimulationLogParam",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInput",
                table: "ParamByStrategy",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_SimulationLogParam_GetParamByStrategyId",
                table: "SimulationLogParam",
                column: "GetParamByStrategyId");

            migrationBuilder.AddForeignKey(
                name: "FK_SimulationLogParam_ParamByStrategy_GetParamByStrategyId",
                table: "SimulationLogParam",
                column: "GetParamByStrategyId",
                principalTable: "ParamByStrategy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SimulationLogParam_SimulationLog_SimulationLogId",
                table: "SimulationLogParam",
                column: "SimulationLogId",
                principalTable: "SimulationLog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimulationLogParam_ParamByStrategy_GetParamByStrategyId",
                table: "SimulationLogParam");

            migrationBuilder.DropForeignKey(
                name: "FK_SimulationLogParam_SimulationLog_SimulationLogId",
                table: "SimulationLogParam");

            migrationBuilder.DropIndex(
                name: "IX_SimulationLogParam_GetParamByStrategyId",
                table: "SimulationLogParam");

            migrationBuilder.DropColumn(
                name: "GetParamByStrategyId",
                table: "SimulationLogParam");

            migrationBuilder.DropColumn(
                name: "IsInput",
                table: "ParamByStrategy");

            migrationBuilder.AlterColumn<int>(
                name: "SimulationLogId",
                table: "SimulationLogParam",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInput",
                table: "SimulationLogParam",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ParamName",
                table: "SimulationLogParam",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SimulationLogParam_SimulationLog_SimulationLogId",
                table: "SimulationLogParam",
                column: "SimulationLogId",
                principalTable: "SimulationLog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
