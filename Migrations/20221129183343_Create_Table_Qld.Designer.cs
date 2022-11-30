﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace QUANLYSINHVIEN.Migrations
{
    [DbContext(typeof(ApplicationDbcontext))]
    [Migration("20221129183343_Create_Table_Qld")]
    partial class CreateTableQld
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("QUANLYSINHVIEN.Models.Khoa", b =>
                {
                    b.Property<string>("Makhoa")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tenkhoa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Makhoa");

                    b.ToTable("Khoa");
                });

            modelBuilder.Entity("QUANLYSINHVIEN.Models.Lop", b =>
                {
                    b.Property<string>("Malop")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tenlop")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Malop");

                    b.ToTable("Lop");
                });

            modelBuilder.Entity("QUANLYSINHVIEN.Models.Qld", b =>
                {
                    b.Property<string>("MaSV")
                        .HasColumnType("TEXT");

                    b.Property<string>("Diem")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenSV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tenmonhoc")
                        .HasColumnType("TEXT");

                    b.HasKey("MaSV");

                    b.ToTable("Qld");
                });

            modelBuilder.Entity("QUANLYSINHVIEN.Models.Qlmh", b =>
                {
                    b.Property<string>("Mamonhoc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tenmonhoc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Mamonhoc");

                    b.ToTable("Qlmh");
                });

            modelBuilder.Entity("QUANLYSINHVIEN.Models.SinhVien", b =>
                {
                    b.Property<string>("MaSV")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Hovaten")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaLop")
                        .HasColumnType("TEXT");

                    b.Property<string>("Makhoa")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tenkhoa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tenlop")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaSV");

                    b.HasIndex("MaLop");

                    b.HasIndex("Makhoa");

                    b.ToTable("SinhVien");
                });

            modelBuilder.Entity("QUANLYSINHVIEN.Models.SinhVien", b =>
                {
                    b.HasOne("QUANLYSINHVIEN.Models.Lop", "Lop")
                        .WithMany()
                        .HasForeignKey("MaLop");

                    b.HasOne("QUANLYSINHVIEN.Models.Khoa", "Khoa")
                        .WithMany()
                        .HasForeignKey("Makhoa");

                    b.Navigation("Khoa");

                    b.Navigation("Lop");
                });
#pragma warning restore 612, 618
        }
    }
}
