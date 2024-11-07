namespace QLPhongMachTu_DOAN_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BacSi",
                c => new
                {
                    MaBS = c.Long(nullable: false, identity: true),
                    MaKhoa = c.Long(nullable: false),
                    CCCD = c.Long(nullable: false),
                    HoTen = c.String(),
                    NgaySinh = c.DateTime(nullable: false),
                    GioiTinh = c.String(),
                    DiaChi = c.String(),
                    SDT = c.String(),
                    MaUser = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.MaBS)
                .ForeignKey("dbo.PhongKhoa", t => t.MaKhoa)
                .ForeignKey("dbo.User", t => t.MaUser)
                .Index(t => t.MaKhoa)
                .Index(t => t.MaUser);

            CreateTable(
                "dbo.PhongKhoa",
                c => new
                {
                    MaPK = c.Long(nullable: false, identity: true),
                    TenPhongBan = c.String(),
                    ChuyenKhoa = c.String(),
                })
                .PrimaryKey(t => t.MaPK);

            CreateTable(
                "dbo.User",
                c => new
                {
                    MaUser = c.Long(nullable: false, identity: true),
                    MaPQ = c.Long(nullable: false),
                    Username = c.String(),
                    Password = c.String(),
                    Email = c.String(),
                    TrangThai = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.MaUser)
                .ForeignKey("dbo.PhanQuyen", t => t.MaPQ)
                .Index(t => t.MaPQ);

            CreateTable(
                "dbo.PhanQuyen",
                c => new
                {
                    MaPQ = c.Long(nullable: false, identity: true),
                    TenQuyen = c.String(nullable: false),
                    ChucNang = c.String(nullable: false),
                    MoTa = c.String(),
                })
                .PrimaryKey(t => t.MaPQ);

            CreateTable(
                "dbo.BenhNhan",
                c => new
                {
                    MaBN = c.Long(nullable: false, identity: true),
                    CCCD = c.Long(nullable: false),
                    HoTen = c.String(),
                    NgaySinh = c.DateTime(nullable: false),
                    GioiTinh = c.String(),
                    DiaChi = c.String(),
                    SDT = c.String(),
                    MaUser = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.MaBN)
                .ForeignKey("dbo.User", t => t.MaUser)
                .Index(t => t.MaUser);

            CreateTable(
                "dbo.ChiTietToaThuoc",
                c => new
                {
                    MaThuoc = c.Long(nullable: false),
                    MaTT = c.Long(nullable: false),
                    SoLuong = c.Int(nullable: false),
                    CachDung = c.String(),
                })
                .PrimaryKey(t => new { t.MaThuoc, t.MaTT })
                .ForeignKey("dbo.KhoThuoc", t => t.MaThuoc)
                .ForeignKey("dbo.ToaThuoc", t => t.MaTT)
                .Index(t => t.MaThuoc)
                .Index(t => t.MaTT);

            CreateTable(
                "dbo.KhoThuoc",
                c => new
                {
                    MaThuoc = c.Long(nullable: false, identity: true),
                    TenThuoc = c.String(),
                    DonGia = c.Double(nullable: false),
                    DonVi = c.String(),
                    NhaCungCap = c.String(),
                    NgayNhap = c.DateTime(nullable: false),
                    HSD = c.DateTime(nullable: false),
                    SoLuongTon = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.MaThuoc);

            CreateTable(
                "dbo.ToaThuoc",
                c => new
                {
                    MaTT = c.Long(nullable: false, identity: true),
                    MaBN = c.Long(nullable: false),
                    MaBS = c.Long(nullable: false),
                    MaLK = c.Long(nullable: false),
                    MaPK = c.Long(nullable: false),
                    NgayKeToa = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.MaTT)
                .ForeignKey("dbo.BacSi", t => t.MaBS)
                .ForeignKey("dbo.BenhNhan", t => t.MaBN)
                .ForeignKey("dbo.LichKham", t => t.MaLK)
                .ForeignKey("dbo.PhieuKham", t => t.MaPK)
                .Index(t => t.MaBN)
                .Index(t => t.MaBS)
                .Index(t => t.MaLK)
                .Index(t => t.MaPK);

            CreateTable(
                "dbo.LichKham",
                c => new
                {
                    MaLK = c.Long(nullable: false, identity: true),
                    MaBS = c.Long(nullable: false),
                    MaBN = c.Long(nullable: false),
                    NgayKham = c.DateTime(nullable: false),
                    MaNV = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.MaLK)
                .ForeignKey("dbo.BacSi", t => t.MaBS)
                .ForeignKey("dbo.BenhNhan", t => t.MaBN)
                .ForeignKey("dbo.NhanVien", t => t.MaNV)
                .Index(t => t.MaBS)
                .Index(t => t.MaBN)
                .Index(t => t.MaNV);

            CreateTable(
                "dbo.NhanVien",
                c => new
                {
                    MaNV = c.Long(nullable: false, identity: true),
                    ChucVu = c.String(),
                    CCCD = c.Long(nullable: false),
                    HoTen = c.String(),
                    NgaySinh = c.DateTime(nullable: false),
                    GioiTinh = c.String(),
                    DiaChi = c.String(),
                    SDT = c.String(),
                    MaUser = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.MaNV)
                .ForeignKey("dbo.User", t => t.MaUser)
                .Index(t => t.MaUser);

            CreateTable(
                "dbo.PhieuKham",
                c => new
                {
                    MaPK = c.Long(nullable: false, identity: true),
                    MaLK = c.Long(nullable: false),
                    MaBN = c.Long(nullable: false),
                    MaBS = c.Long(nullable: false),
                    NgayKham = c.DateTime(nullable: false),
                    SoThuTu = c.Int(nullable: false),
                    TrieuChung = c.String(nullable: false),
                    TieuSuBenhLy = c.String(nullable: false),
                    ChuanDoan = c.String(nullable: false),
                })
                .PrimaryKey(t => t.MaPK)
                .ForeignKey("dbo.BacSi", t => t.MaBS)
                .ForeignKey("dbo.BenhNhan", t => t.MaBN)
                .ForeignKey("dbo.LichKham", t => t.MaLK)
                .Index(t => t.MaLK)
                .Index(t => t.MaBN)
                .Index(t => t.MaBS);

            CreateTable(
                "dbo.HoaDonKhamBenh",
                c => new
                {
                    MaHDKB = c.Long(nullable: false, identity: true),
                    MaBN = c.Long(nullable: false),
                    MaBS = c.Long(nullable: false),
                    MaPK = c.Long(nullable: false),
                    TongTien = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.MaHDKB)
                .ForeignKey("dbo.BacSi", t => t.MaBS)
                .ForeignKey("dbo.BenhNhan", t => t.MaBN)
                .ForeignKey("dbo.PhieuKham", t => t.MaPK)
                .Index(t => t.MaBN)
                .Index(t => t.MaBS)
                .Index(t => t.MaPK);

            CreateTable(
                "dbo.HoaDonThuoc",
                c => new
                {
                    MaDT = c.Long(nullable: false, identity: true),
                    MaTT = c.Long(nullable: false),
                    MaNV = c.Long(nullable: false),
                    NgayMua = c.DateTime(nullable: false),
                    TongTien = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.MaDT)
                .ForeignKey("dbo.NhanVien", t => t.MaNV)
                .ForeignKey("dbo.ToaThuoc", t => t.MaTT)
                .Index(t => t.MaTT)
                .Index(t => t.MaNV);

            CreateTable(
                "dbo.LichPhanCong",
                c => new
                {
                    MaLPC = c.Long(nullable: false, identity: true),
                    MaLK = c.Long(nullable: false),
                    MaNV = c.Long(nullable: false),
                    MaBS = c.Long(nullable: false),
                    NgayThucHien = c.DateTime(nullable: false),
                    ThoiGian = c.DateTime(nullable: false),
                    GhiChu = c.String(),
                })
                .PrimaryKey(t => t.MaLPC)
                .ForeignKey("dbo.BacSi", t => t.MaBS)
                .ForeignKey("dbo.LichKham", t => t.MaLK)
                .ForeignKey("dbo.NhanVien", t => t.MaNV)
                .Index(t => t.MaLK)
                .Index(t => t.MaNV)
                .Index(t => t.MaBS);

            CreateTable(
                "dbo.NhapThuoc",
                c => new
                {
                    MaPN = c.Long(nullable: false, identity: true),
                    MaThuoc = c.Long(nullable: false),
                    TenThuoc = c.String(),
                    NhaCungCap = c.String(),
                    NgayNhap = c.DateTime(nullable: false),
                    HSD = c.DateTime(nullable: false),
                    LoaiThuoc = c.String(),
                    SoLuong = c.Int(nullable: false),
                    GiaNhap = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.MaPN);

        }

        public override void Down()
        {
            DropForeignKey("dbo.LichPhanCong", "MaNV", "dbo.NhanVien");
            DropForeignKey("dbo.LichPhanCong", "MaLK", "dbo.LichKham");
            DropForeignKey("dbo.LichPhanCong", "MaBS", "dbo.BacSi");
            DropForeignKey("dbo.HoaDonThuoc", "MaTT", "dbo.ToaThuoc");
            DropForeignKey("dbo.HoaDonThuoc", "MaNV", "dbo.NhanVien");
            DropForeignKey("dbo.HoaDonKhamBenh", "MaPK", "dbo.PhieuKham");
            DropForeignKey("dbo.HoaDonKhamBenh", "MaBN", "dbo.BenhNhan");
            DropForeignKey("dbo.HoaDonKhamBenh", "MaBS", "dbo.BacSi");
            DropForeignKey("dbo.ChiTietToaThuoc", "MaTT", "dbo.ToaThuoc");
            DropForeignKey("dbo.ToaThuoc", "MaPK", "dbo.PhieuKham");
            DropForeignKey("dbo.PhieuKham", "MaLK", "dbo.LichKham");
            DropForeignKey("dbo.PhieuKham", "MaBN", "dbo.BenhNhan");
            DropForeignKey("dbo.PhieuKham", "MaBS", "dbo.BacSi");
            DropForeignKey("dbo.ToaThuoc", "MaLK", "dbo.LichKham");
            DropForeignKey("dbo.LichKham", "MaNV", "dbo.NhanVien");
            DropForeignKey("dbo.NhanVien", "MaUser", "dbo.User");
            DropForeignKey("dbo.LichKham", "MaBN", "dbo.BenhNhan");
            DropForeignKey("dbo.LichKham", "MaBS", "dbo.BacSi");
            DropForeignKey("dbo.ToaThuoc", "MaBN", "dbo.BenhNhan");
            DropForeignKey("dbo.ToaThuoc", "MaBS", "dbo.BacSi");
            DropForeignKey("dbo.ChiTietToaThuoc", "MaThuoc", "dbo.KhoThuoc");
            DropForeignKey("dbo.BenhNhan", "MaUser", "dbo.User");
            DropForeignKey("dbo.BacSi", "MaUser", "dbo.User");
            DropForeignKey("dbo.User", "MaPQ", "dbo.PhanQuyen");
            DropForeignKey("dbo.BacSi", "MaKhoa", "dbo.PhongKhoa");
            DropIndex("dbo.LichPhanCong", new[] { "MaBS" });
            DropIndex("dbo.LichPhanCong", new[] { "MaNV" });
            DropIndex("dbo.LichPhanCong", new[] { "MaLK" });
            DropIndex("dbo.HoaDonThuoc", new[] { "MaNV" });
            DropIndex("dbo.HoaDonThuoc", new[] { "MaTT" });
            DropIndex("dbo.HoaDonKhamBenh", new[] { "MaPK" });
            DropIndex("dbo.HoaDonKhamBenh", new[] { "MaBS" });
            DropIndex("dbo.HoaDonKhamBenh", new[] { "MaBN" });
            DropIndex("dbo.PhieuKham", new[] { "MaBS" });
            DropIndex("dbo.PhieuKham", new[] { "MaBN" });
            DropIndex("dbo.PhieuKham", new[] { "MaLK" });
            DropIndex("dbo.NhanVien", new[] { "MaUser" });
            DropIndex("dbo.LichKham", new[] { "MaNV" });
            DropIndex("dbo.LichKham", new[] { "MaBN" });
            DropIndex("dbo.LichKham", new[] { "MaBS" });
            DropIndex("dbo.ToaThuoc", new[] { "MaPK" });
            DropIndex("dbo.ToaThuoc", new[] { "MaLK" });
            DropIndex("dbo.ToaThuoc", new[] { "MaBS" });
            DropIndex("dbo.ToaThuoc", new[] { "MaBN" });
            DropIndex("dbo.ChiTietToaThuoc", new[] { "MaTT" });
            DropIndex("dbo.ChiTietToaThuoc", new[] { "MaThuoc" });
            DropIndex("dbo.BenhNhan", new[] { "MaUser" });
            DropIndex("dbo.User", new[] { "MaPQ" });
            DropIndex("dbo.BacSi", new[] { "MaUser" });
            DropIndex("dbo.BacSi", new[] { "MaKhoa" });
            DropTable("dbo.NhapThuoc");
            DropTable("dbo.LichPhanCong");
            DropTable("dbo.HoaDonThuoc");
            DropTable("dbo.HoaDonKhamBenh");
            DropTable("dbo.PhieuKham");
            DropTable("dbo.NhanVien");
            DropTable("dbo.LichKham");
            DropTable("dbo.ToaThuoc");
            DropTable("dbo.KhoThuoc");
            DropTable("dbo.ChiTietToaThuoc");
            DropTable("dbo.BenhNhan");
            DropTable("dbo.PhanQuyen");
            DropTable("dbo.User");
            DropTable("dbo.PhongKhoa");
            DropTable("dbo.BacSi");
        }
    }
}
