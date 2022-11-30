using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QUANLYSINHVIEN.Models;

    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext (DbContextOptions<ApplicationDbcontext> options)
            : base(options)
        {
        }

        public DbSet<QUANLYSINHVIEN.Models.Khoa> Khoa { get; set; } = default!;

        public DbSet<QUANLYSINHVIEN.Models.Lop> Lop { get; set; } = default!;

        public DbSet<QUANLYSINHVIEN.Models.SinhVien> SinhVien { get; set; } = default!;

        public DbSet<QUANLYSINHVIEN.Models.Qlmh> Qlmh { get; set; } = default!;

        public DbSet<QUANLYSINHVIEN.Models.Qld> Qld { get; set; } = default!;
    }
