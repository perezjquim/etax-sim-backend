using Microsoft.EntityFrameworkCore.Migrations;

namespace etax_sim.Migrations
{
    public partial class newTablesNew1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParamByStrategy_SimulationParamRule_SimulationParamRuleId1",
                table: "ParamByStrategy");

            migrationBuilder.DropForeignKey(
                name: "FK_ParamByStrategy_Strategy_StrategyId1",
                table: "ParamByStrategy");

            migrationBuilder.DropForeignKey(
                name: "FK_StrategyByCountry_Country_CountryId1",
                table: "StrategyByCountry");

            migrationBuilder.DropForeignKey(
                name: "FK_StrategyByCountry_Strategy_StrategyId1",
                table: "StrategyByCountry");

            migrationBuilder.DropForeignKey(
                name: "FK_StrategyByCountryByRegion_Country_CountryId1",
                table: "StrategyByCountryByRegion");

            migrationBuilder.DropIndex(
                name: "IX_StrategyByCountryByRegion_CountryId1",
                table: "StrategyByCountryByRegion");

            migrationBuilder.DropIndex(
                name: "IX_StrategyByCountry_CountryId1",
                table: "StrategyByCountry");

            migrationBuilder.DropIndex(
                name: "IX_StrategyByCountry_StrategyId1",
                table: "StrategyByCountry");

            migrationBuilder.DropIndex(
                name: "IX_ParamByStrategy_SimulationParamRuleId1",
                table: "ParamByStrategy");

            migrationBuilder.DropIndex(
                name: "IX_ParamByStrategy_StrategyId1",
                table: "ParamByStrategy");

            migrationBuilder.DropColumn(
                name: "CountryId1",
                table: "StrategyByCountryByRegion");

            migrationBuilder.DropColumn(
                name: "CountryId1",
                table: "StrategyByCountry");

            migrationBuilder.DropColumn(
                name: "StrategyId1",
                table: "StrategyByCountry");

            migrationBuilder.DropColumn(
                name: "SimulationParamRuleId1",
                table: "ParamByStrategy");

            migrationBuilder.DropColumn(
                name: "StrategyId1",
                table: "ParamByStrategy");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StrategyByCountryByRegion",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "StrategyByCountryByRegion",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StrategyId",
                table: "StrategyByCountry",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StrategyByCountry",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "StrategyByCountry",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StrategyId",
                table: "ParamByStrategy",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SimulationParamRuleId",
                table: "ParamByStrategy",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "ParamName",
                table: "ParamByStrategy",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.CreateIndex(
                name: "IX_StrategyByCountryByRegion_CountryId",
                table: "StrategyByCountryByRegion",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_StrategyByCountry_CountryId",
                table: "StrategyByCountry",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_StrategyByCountry_StrategyId",
                table: "StrategyByCountry",
                column: "StrategyId");

            migrationBuilder.CreateIndex(
                name: "IX_ParamByStrategy_SimulationParamRuleId",
                table: "ParamByStrategy",
                column: "SimulationParamRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ParamByStrategy_StrategyId",
                table: "ParamByStrategy",
                column: "StrategyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParamByStrategy_SimulationParamRule_SimulationParamRuleId",
                table: "ParamByStrategy",
                column: "SimulationParamRuleId",
                principalTable: "SimulationParamRule",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParamByStrategy_Strategy_StrategyId",
                table: "ParamByStrategy",
                column: "StrategyId",
                principalTable: "Strategy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StrategyByCountry_Country_CountryId",
                table: "StrategyByCountry",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StrategyByCountry_Strategy_StrategyId",
                table: "StrategyByCountry",
                column: "StrategyId",
                principalTable: "Strategy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StrategyByCountryByRegion_Country_CountryId",
                table: "StrategyByCountryByRegion",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParamByStrategy_SimulationParamRule_SimulationParamRuleId",
                table: "ParamByStrategy");

            migrationBuilder.DropForeignKey(
                name: "FK_ParamByStrategy_Strategy_StrategyId",
                table: "ParamByStrategy");

            migrationBuilder.DropForeignKey(
                name: "FK_StrategyByCountry_Country_CountryId",
                table: "StrategyByCountry");

            migrationBuilder.DropForeignKey(
                name: "FK_StrategyByCountry_Strategy_StrategyId",
                table: "StrategyByCountry");

            migrationBuilder.DropForeignKey(
                name: "FK_StrategyByCountryByRegion_Country_CountryId",
                table: "StrategyByCountryByRegion");

            migrationBuilder.DropIndex(
                name: "IX_StrategyByCountryByRegion_CountryId",
                table: "StrategyByCountryByRegion");

            migrationBuilder.DropIndex(
                name: "IX_StrategyByCountry_CountryId",
                table: "StrategyByCountry");

            migrationBuilder.DropIndex(
                name: "IX_StrategyByCountry_StrategyId",
                table: "StrategyByCountry");

            migrationBuilder.DropIndex(
                name: "IX_ParamByStrategy_SimulationParamRuleId",
                table: "ParamByStrategy");

            migrationBuilder.DropIndex(
                name: "IX_ParamByStrategy_StrategyId",
                table: "ParamByStrategy");

            migrationBuilder.AlterColumn<double>(
                name: "Description",
                table: "StrategyByCountryByRegion",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryId",
                table: "StrategyByCountryByRegion",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CountryId1",
                table: "StrategyByCountryByRegion",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StrategyId",
                table: "StrategyByCountry",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "Description",
                table: "StrategyByCountry",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryId",
                table: "StrategyByCountry",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CountryId1",
                table: "StrategyByCountry",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrategyId1",
                table: "StrategyByCountry",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StrategyId",
                table: "ParamByStrategy",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "SimulationParamRuleId",
                table: "ParamByStrategy",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "ParamName",
                table: "ParamByStrategy",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SimulationParamRuleId1",
                table: "ParamByStrategy",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrategyId1",
                table: "ParamByStrategy",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StrategyByCountryByRegion_CountryId1",
                table: "StrategyByCountryByRegion",
                column: "CountryId1");

            migrationBuilder.CreateIndex(
                name: "IX_StrategyByCountry_CountryId1",
                table: "StrategyByCountry",
                column: "CountryId1");

            migrationBuilder.CreateIndex(
                name: "IX_StrategyByCountry_StrategyId1",
                table: "StrategyByCountry",
                column: "StrategyId1");

            migrationBuilder.CreateIndex(
                name: "IX_ParamByStrategy_SimulationParamRuleId1",
                table: "ParamByStrategy",
                column: "SimulationParamRuleId1");

            migrationBuilder.CreateIndex(
                name: "IX_ParamByStrategy_StrategyId1",
                table: "ParamByStrategy",
                column: "StrategyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ParamByStrategy_SimulationParamRule_SimulationParamRuleId1",
                table: "ParamByStrategy",
                column: "SimulationParamRuleId1",
                principalTable: "SimulationParamRule",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParamByStrategy_Strategy_StrategyId1",
                table: "ParamByStrategy",
                column: "StrategyId1",
                principalTable: "Strategy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StrategyByCountry_Country_CountryId1",
                table: "StrategyByCountry",
                column: "CountryId1",
                principalTable: "Country",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StrategyByCountry_Strategy_StrategyId1",
                table: "StrategyByCountry",
                column: "StrategyId1",
                principalTable: "Strategy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StrategyByCountryByRegion_Country_CountryId1",
                table: "StrategyByCountryByRegion",
                column: "CountryId1",
                principalTable: "Country",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
