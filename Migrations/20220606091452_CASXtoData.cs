using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScadaProject.Migrations
{
    public partial class CASXtoData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SettingCaSanXuats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStartHour = table.Column<int>(type: "int", nullable: false),
                    TimeStarMinute = table.Column<int>(type: "int", nullable: false),
                    NameTruongCa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingCaSanXuats", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingCaSanXuats");
        }
    }
}
