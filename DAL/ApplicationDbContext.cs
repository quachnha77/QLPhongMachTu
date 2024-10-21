using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("ApplicationDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<ChiTietToaThuoc>()
                .HasKey(ct => new { ct.MaThuoc, ct.MaTT });

        }

        public DbSet<BacSi> BacSi { get; set; }
        public DbSet<BenhNhan> BenhNhan { get; set; }
        public DbSet<ChiTietToaThuoc> ChiTietToaThuoc { get; set; }
        public DbSet<HoaDonKhamBenh> HoaDonKhamBenh { get; set; }
        public DbSet<HoaDonThuoc> HoaDonThuoc { get; set; }
        public DbSet<LichKham> LichKham { get; set; }
        public DbSet<LichPhanCong> LichPhanCong { get; set; }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<NhapThuoc> NhapThuoc { get; set; }
        public DbSet<PhanQuyen> PhanQuyen { get; set; }
        public DbSet<PhieuKham> PhieuKham { get; set; }
        public DbSet<PhongKhoa> PhongKhoa { get; set; }
        public DbSet<KhoThuoc> Thuoc { get; set; }
        public DbSet<ToaThuoc> ToaThuoc {get;set;}
        public DbSet<User> User { get; set; }
    }
}
