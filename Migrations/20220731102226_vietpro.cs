using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScadaProject.Migrations
{
    public partial class vietpro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayChuyen",
                table: "SettingPLCs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayChuyen",
                table: "SettingPLCs");
        }
    }
}
