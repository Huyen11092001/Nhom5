using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QUANLYSINHVIEN.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableSinhVien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Qld");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Qld",
                columns: table => new
                {
                    MaSV = table.Column<string>(type: "TEXT", nullable: false),
                    Diem = table.Column<string>(type: "TEXT", nullable: true),
                    TenSV = table.Column<string>(type: "TEXT", nullable: false),
                    Tenmonhoc = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qld", x => x.MaSV);
                });
        }
    }
}
