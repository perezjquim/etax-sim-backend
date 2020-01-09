using Microsoft.EntityFrameworkCore.Migrations;

namespace eTaxSim.Migrations
{
    public partial class new7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SimulationParamRuleId",
                table: "ParamByStrategy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SimulationParamRuleId",
                table: "ParamByStrategy",
                nullable: false,
                defaultValue: 0);
        }
    }
}
