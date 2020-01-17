using Microsoft.EntityFrameworkCore.Migrations;

namespace eTaxSim.Migrations
{
    public partial class new36 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImplementingClass",
                table: "Strategy",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImplementingClass",
                table: "Strategy",
                nullable: true);
        }
    }
}
