using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScadaProject.Migrations
{
    public partial class DtbToOnline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SetGeneralInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTruongCa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameProduct = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetGeneralInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingPLCs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TocDoChuan = table.Column<int>(type: "int", nullable: false),
                    ThoiGianTinhDungMay = table.Column<int>(type: "int", nullable: false),
                    ThoiGianChapNhanGoi = table.Column<int>(type: "int", nullable: false),
                    ThoiGianTinhGoiCan = table.Column<int>(type: "int", nullable: false),
                    ThoiGianDayGoiCan = table.Column<int>(type: "int", nullable: false),
                    ThoiGianCapNhap = table.Column<int>(type: "int", nullable: false),
                    ThoiGianDayGoi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingPLCs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetGeneralInformations");

            migrationBuilder.DropTable(
                name: "SettingPLCs");
        }
    }
}
