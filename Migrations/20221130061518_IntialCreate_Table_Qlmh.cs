using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QUANLYSINHVIEN.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreateTableQlmh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monhoc");

            migrationBuilder.CreateTable(
                name: "Qlmh",
                columns: table => new
                {
                    Mamonhoc = table.Column<string>(type: "TEXT", nullable: false),
                    Tenmonhoc = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qlmh", x => x.Mamonhoc);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Qlmh");

            migrationBuilder.CreateTable(
                name: "Monhoc",
                columns: table => new
                {
                    MaMH = table.Column<string>(type: "TEXT", nullable: false),
                    TenMH = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monhoc", x => x.MaMH);
                });
        }
    }
}
