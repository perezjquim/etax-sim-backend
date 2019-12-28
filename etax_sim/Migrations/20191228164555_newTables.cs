using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace etax_sim.Migrations
{
    public partial class newTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParamByStrategyId",
                table: "SimulationParamRule",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrategyByCountryByRegionId",
                table: "Region",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrategyByCountryByRegionId",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrategyByCountryId",
                table: "Country",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ParamByStrategy",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StrategyId = table.Column<string>(nullable: true),
                    SimulationParamRuleId = table.Column<double>(nullable: false),
                    ParamName = table.Column<double>(nullable: false),
                    ParamValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamByStrategy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StrategyByCountry",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<string>(nullable: true),
                    StrategyId = table.Column<string>(nullable: true),
                    Description = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrategyByCountry", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StrategyByCountryByRegion",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<string>(nullable: true),
                    RegionId = table.Column<int>(nullable: false),
                    StrategyId = table.Column<int>(nullable: false),
                    Description = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrategyByCountryByRegion", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Strategy",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ParamByStrategyId = table.Column<int>(nullable: true),
                    StrategyByCountryByRegionId = table.Column<int>(nullable: true),
                    StrategyByCountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strategy", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Strategy_ParamByStrategy_ParamByStrategyId",
                        column: x => x.ParamByStrategyId,
                        principalTable: "ParamByStrategy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Strategy_StrategyByCountryByRegion_StrategyByCountryByRegion~",
                        column: x => x.StrategyByCountryByRegionId,
                        principalTable: "StrategyByCountryByRegion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Strategy_StrategyByCountry_StrategyByCountryId",
                        column: x => x.StrategyByCountryId,
                        principalTable: "StrategyByCountry",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SimulationParamRule_ParamByStrategyId",
                table: "SimulationParamRule",
                column: "ParamByStrategyId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_StrategyByCountryByRegionId",
                table: "Region",
                column: "StrategyByCountryByRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_StrategyByCountryByRegionId",
                table: "Country",
                column: "StrategyByCountryByRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_StrategyByCountryId",
                table: "Country",
                column: "StrategyByCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Strategy_ParamByStrategyId",
                table: "Strategy",
                column: "ParamByStrategyId");

            migrationBuilder.CreateIndex(
                name: "IX_Strategy_StrategyByCountryByRegionId",
                table: "Strategy",
                column: "StrategyByCountryByRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Strategy_StrategyByCountryId",
                table: "Strategy",
                column: "StrategyByCountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Country_StrategyByCountryByRegion_StrategyByCountryByRegionId",
                table: "Country",
                column: "StrategyByCountryByRegionId",
                principalTable: "StrategyByCountryByRegion",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Country_StrategyByCountry_StrategyByCountryId",
                table: "Country",
                column: "StrategyByCountryId",
                principalTable: "StrategyByCountry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Region_StrategyByCountryByRegion_StrategyByCountryByRegionId",
                table: "Region",
                column: "StrategyByCountryByRegionId",
                principalTable: "StrategyByCountryByRegion",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SimulationParamRule_ParamByStrategy_ParamByStrategyId",
                table: "SimulationParamRule",
                column: "ParamByStrategyId",
                principalTable: "ParamByStrategy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Country_StrategyByCountryByRegion_StrategyByCountryByRegionId",
                table: "Country");

            migrationBuilder.DropForeignKey(
                name: "FK_Country_StrategyByCountry_StrategyByCountryId",
                table: "Country");

            migrationBuilder.DropForeignKey(
                name: "FK_Region_StrategyByCountryByRegion_StrategyByCountryByRegionId",
                table: "Region");

            migrationBuilder.DropForeignKey(
                name: "FK_SimulationParamRule_ParamByStrategy_ParamByStrategyId",
                table: "SimulationParamRule");

            migrationBuilder.DropTable(
                name: "Strategy");

            migrationBuilder.DropTable(
                name: "ParamByStrategy");

            migrationBuilder.DropTable(
                name: "StrategyByCountryByRegion");

            migrationBuilder.DropTable(
                name: "StrategyByCountry");

            migrationBuilder.DropIndex(
                name: "IX_SimulationParamRule_ParamByStrategyId",
                table: "SimulationParamRule");

            migrationBuilder.DropIndex(
                name: "IX_Region_StrategyByCountryByRegionId",
                table: "Region");

            migrationBuilder.DropIndex(
                name: "IX_Country_StrategyByCountryByRegionId",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Country_StrategyByCountryId",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "ParamByStrategyId",
                table: "SimulationParamRule");

            migrationBuilder.DropColumn(
                name: "StrategyByCountryByRegionId",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "StrategyByCountryByRegionId",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "StrategyByCountryId",
                table: "Country");
        }
    }
}
