using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QUANLYSINHVIEN.Migrations
{
    /// <inheritdoc />
    public partial class Khoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    Makhoa = table.Column<string>(type: "TEXT", nullable: false),
                    Tenkhoa = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.Makhoa);
                });

            migrationBuilder.CreateTable(
                name: "Lop",
                columns: table => new
                {
                    Malop = table.Column<string>(type: "TEXT", nullable: false),
                    Tenlop = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lop", x => x.Malop);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Khoa");

            migrationBuilder.DropTable(
                name: "Lop");
        }
    }
}
