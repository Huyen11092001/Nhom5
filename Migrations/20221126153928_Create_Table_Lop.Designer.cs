﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace QUANLYSINHVIEN.Migrations
{
    [DbContext(typeof(ApplicationDbcontext))]
    [Migration("20221126153928_Create_Table_Lop")]
    partial class CreateTableLop
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
                        .HasColumnType("TEXT");

                    b.HasKey("Makhoa");

                    b.ToTable("Khoa");
                });

            modelBuilder.Entity("QUANLYSINHVIEN.Models.Lop", b =>
                {
                    b.Property<string>("Malop")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tenlop")
                        .HasColumnType("TEXT");

                    b.HasKey("Malop");

                    b.ToTable("Lop");
                });
#pragma warning restore 612, 618
        }
    }
}
