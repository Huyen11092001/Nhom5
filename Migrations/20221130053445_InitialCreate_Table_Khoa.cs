using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QUANLYSINHVIEN.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateTableKhoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diem",
                columns: table => new
                {
                    MaSV = table.Column<string>(type: "TEXT", nullable: false),
                    TenSV = table.Column<string>(type: "TEXT", nullable: true),
                    TenMH = table.Column<string>(type: "TEXT", nullable: true),
                    DiemMH = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diem", x => x.MaSV);
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Tenkhoa = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lop",
                columns: table => new
                {
                    IdLop = table.Column<string>(type: "TEXT", nullable: false),
                    TenLop = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lop", x => x.IdLop);
                });

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

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    IdSV = table.Column<string>(type: "TEXT", nullable: false),
                    TenSV = table.Column<string>(type: "TEXT", nullable: true),
                    Điachi = table.Column<string>(type: "TEXT", nullable: true),
                    TenLop = table.Column<string>(type: "TEXT", nullable: true),
                    IdLop = table.Column<string>(type: "TEXT", nullable: true),
                    Tenkhoa = table.Column<string>(type: "TEXT", nullable: true),
                    Id = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.IdSV);
                    table.ForeignKey(
                        name: "FK_SinhVien_Khoa_Id",
                        column: x => x.Id,
                        principalTable: "Khoa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhVien_Lop_IdLop",
                        column: x => x.IdLop,
                        principalTable: "Lop",
                        principalColumn: "IdLop");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_Id",
                table: "SinhVien",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IdLop",
                table: "SinhVien",
                column: "IdLop");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diem");

            migrationBuilder.DropTable(
                name: "Monhoc");

            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "Khoa");

            migrationBuilder.DropTable(
                name: "Lop");
        }
    }
}
