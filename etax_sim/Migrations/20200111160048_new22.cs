using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eTaxSim.Migrations
{
    public partial class new22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RuleAllowedValues_StrategyParamRule_StrategyParamRuleId",
                table: "RuleAllowedValues");

            migrationBuilder.DropIndex(
                name: "IX_RuleAllowedValues_StrategyParamRuleId",
                table: "RuleAllowedValues");

            migrationBuilder.DropColumn(
                name: "StrategyParamRuleId",
                table: "RuleAllowedValues");

            migrationBuilder.CreateTable(
                name: "ParamAllowedValues",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParamByStrategyId = table.Column<int>(nullable: true),
                    RuleAllowedValueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamAllowedValues", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ParamAllowedValues_ParamByStrategy_ParamByStrategyId",
                        column: x => x.ParamByStrategyId,
                        principalTable: "ParamByStrategy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParamAllowedValues_RuleAllowedValues_RuleAllowedValueId",
                        column: x => x.RuleAllowedValueId,
                        principalTable: "RuleAllowedValues",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParamAllowedValues_ParamByStrategyId",
                table: "ParamAllowedValues",
                column: "ParamByStrategyId");

            migrationBuilder.CreateIndex(
                name: "IX_ParamAllowedValues_RuleAllowedValueId",
                table: "ParamAllowedValues",
                column: "RuleAllowedValueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParamAllowedValues");

            migrationBuilder.AddColumn<int>(
                name: "StrategyParamRuleId",
                table: "RuleAllowedValues",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RuleAllowedValues_StrategyParamRuleId",
                table: "RuleAllowedValues",
                column: "StrategyParamRuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RuleAllowedValues_StrategyParamRule_StrategyParamRuleId",
                table: "RuleAllowedValues",
                column: "StrategyParamRuleId",
                principalTable: "StrategyParamRule",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
