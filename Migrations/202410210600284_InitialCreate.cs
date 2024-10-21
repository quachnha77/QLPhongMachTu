namespace QLPhongMachTu_DOAN_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BacSis",
                c => new
                    {
                        MaSo = c.Long(nullable: false, identity: true),
                        MaKhoa = c.Long(nullable: false),
                        CCCD = c.Long(nullable: false),
                        HoTen = c.String(),
                        NgaySinh = c.DateTime(nullable: false),
                        GioiTinh = c.String(),
                        DiaChi = c.String(),
                        SDT = c.String(),
                        MaUser = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.MaSo)
                .ForeignKey("dbo.PhongKhoas", t => t.MaKhoa)
                .ForeignKey("dbo.Users", t => t.MaUser)
                .Index(t => t.MaKhoa)
                .Index(t => t.MaUser);
            
            CreateTable(
                "dbo.PhongKhoas",
                c => new
                    {
                        MaPK = c.Long(nullable: false, identity: true),
                        TenPhongBan = c.String(),
                        ChuyenKhoa = c.String(),
                    })
                .PrimaryKey(t => t.MaPK);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        MaUser = c.Long(nullable: false, identity: true),
                        MaPQ = c.Long(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.MaUser)
                .ForeignKey("dbo.PhanQuyens", t => t.MaPQ)
                .Index(t => t.MaPQ);
            
            CreateTable(
                "dbo.PhanQuyens",
                c => new
                    {
                        MaPQ = c.Long(nullable: false, identity: true),
                        TenQuyen = c.String(nullable: false),
                        ChucNang = c.String(nullable: false),
                        MoTa = c.String(),
                    })
                .PrimaryKey(t => t.MaPQ);
            
            CreateTable(
                "dbo.BenhNhans",
                c => new
                    {
                        MaSo = c.Long(nullable: false, identity: true),
                        CCCD = c.Long(nullable: false),
                        HoTen = c.String(),
                        NgaySinh = c.DateTime(nullable: false),
                        GioiTinh = c.String(),
                        DiaChi = c.String(),
                        SDT = c.String(),
                        MaUser = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.MaSo)
                .ForeignKey("dbo.Users", t => t.MaUser)
                .Index(t => t.MaUser);
            
            CreateTable(
                "dbo.ChiTietToaThuocs",
                c => new
                    {
                        MaThuoc = c.Long(nullable: false),
                        MaTT = c.Long(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        CachDung = c.String(),
                    })
                .PrimaryKey(t => new { t.MaThuoc, t.MaTT })
                .ForeignKey("dbo.KhoThuocs", t => t.MaThuoc)
                .ForeignKey("dbo.ToaThuocs", t => t.MaTT)
                .Index(t => t.MaThuoc)
                .Index(t => t.MaTT);
            
            CreateTable(
                "dbo.KhoThuocs",
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
                "dbo.ToaThuocs",
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
                .ForeignKey("dbo.BacSis", t => t.MaBS)
                .ForeignKey("dbo.BenhNhans", t => t.MaBN)
                .ForeignKey("dbo.LichKhams", t => t.MaLK)
                .ForeignKey("dbo.PhieuKhams", t => t.MaPK)
                .Index(t => t.MaBN)
                .Index(t => t.MaBS)
                .Index(t => t.MaLK)
                .Index(t => t.MaPK);
            
            CreateTable(
                "dbo.LichKhams",
                c => new
                    {
                        MaLK = c.Long(nullable: false, identity: true),
                        MaBS = c.Long(nullable: false),
                        MaBN = c.Long(nullable: false),
                        NgayKham = c.DateTime(nullable: false),
                        MaNV = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.MaLK)
                .ForeignKey("dbo.BacSis", t => t.MaBS)
                .ForeignKey("dbo.BenhNhans", t => t.MaBN)
                .ForeignKey("dbo.NhanViens", t => t.MaNV)
                .Index(t => t.MaBS)
                .Index(t => t.MaBN)
                .Index(t => t.MaNV);
            
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        MaSo = c.Long(nullable: false, identity: true),
                        CCCD = c.Long(nullable: false),
                        HoTen = c.String(),
                        NgaySinh = c.DateTime(nullable: false),
                        GioiTinh = c.String(),
                        DiaChi = c.String(),
                        SDT = c.String(),
                        MaUser = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.MaSo)
                .ForeignKey("dbo.Users", t => t.MaUser)
                .Index(t => t.MaUser);
            
            CreateTable(
                "dbo.PhieuKhams",
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
                .ForeignKey("dbo.BacSis", t => t.MaBS)
                .ForeignKey("dbo.BenhNhans", t => t.MaBN)
                .ForeignKey("dbo.LichKhams", t => t.MaLK)
                .Index(t => t.MaLK)
                .Index(t => t.MaBN)
                .Index(t => t.MaBS);
            
            CreateTable(
                "dbo.HoaDonKhamBenhs",
                c => new
                    {
                        MaHDKB = c.Long(nullable: false, identity: true),
                        MaBN = c.Long(nullable: false),
                        MaBS = c.Long(nullable: false),
                        MaPK = c.Long(nullable: false),
                        TongTien = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MaHDKB)
                .ForeignKey("dbo.BacSis", t => t.MaBS)
                .ForeignKey("dbo.BenhNhans", t => t.MaBN)
                .ForeignKey("dbo.PhieuKhams", t => t.MaPK)
                .Index(t => t.MaBN)
                .Index(t => t.MaBS)
                .Index(t => t.MaPK);
            
            CreateTable(
                "dbo.HoaDonThuocs",
                c => new
                    {
                        MaDT = c.Long(nullable: false, identity: true),
                        MaTT = c.Long(nullable: false),
                        MaNV = c.Long(nullable: false),
                        NgayMua = c.DateTime(nullable: false),
                        TongTien = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MaDT)
                .ForeignKey("dbo.NhanViens", t => t.MaNV)
                .ForeignKey("dbo.ToaThuocs", t => t.MaTT)
                .Index(t => t.MaTT)
                .Index(t => t.MaNV);
            
            CreateTable(
                "dbo.LichPhanCongs",
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
                .ForeignKey("dbo.BacSis", t => t.MaBS)
                .ForeignKey("dbo.LichKhams", t => t.MaLK)
                .ForeignKey("dbo.NhanViens", t => t.MaNV)
                .Index(t => t.MaLK)
                .Index(t => t.MaNV)
                .Index(t => t.MaBS);
            
            CreateTable(
                "dbo.NhapThuocs",
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
            DropForeignKey("dbo.LichPhanCongs", "MaNV", "dbo.NhanViens");
            DropForeignKey("dbo.LichPhanCongs", "MaLK", "dbo.LichKhams");
            DropForeignKey("dbo.LichPhanCongs", "MaBS", "dbo.BacSis");
            DropForeignKey("dbo.HoaDonThuocs", "MaTT", "dbo.ToaThuocs");
            DropForeignKey("dbo.HoaDonThuocs", "MaNV", "dbo.NhanViens");
            DropForeignKey("dbo.HoaDonKhamBenhs", "MaPK", "dbo.PhieuKhams");
            DropForeignKey("dbo.HoaDonKhamBenhs", "MaBN", "dbo.BenhNhans");
            DropForeignKey("dbo.HoaDonKhamBenhs", "MaBS", "dbo.BacSis");
            DropForeignKey("dbo.ChiTietToaThuocs", "MaTT", "dbo.ToaThuocs");
            DropForeignKey("dbo.ToaThuocs", "MaPK", "dbo.PhieuKhams");
            DropForeignKey("dbo.PhieuKhams", "MaLK", "dbo.LichKhams");
            DropForeignKey("dbo.PhieuKhams", "MaBN", "dbo.BenhNhans");
            DropForeignKey("dbo.PhieuKhams", "MaBS", "dbo.BacSis");
            DropForeignKey("dbo.ToaThuocs", "MaLK", "dbo.LichKhams");
            DropForeignKey("dbo.LichKhams", "MaNV", "dbo.NhanViens");
            DropForeignKey("dbo.NhanViens", "MaUser", "dbo.Users");
            DropForeignKey("dbo.LichKhams", "MaBN", "dbo.BenhNhans");
            DropForeignKey("dbo.LichKhams", "MaBS", "dbo.BacSis");
            DropForeignKey("dbo.ToaThuocs", "MaBN", "dbo.BenhNhans");
            DropForeignKey("dbo.ToaThuocs", "MaBS", "dbo.BacSis");
            DropForeignKey("dbo.ChiTietToaThuocs", "MaThuoc", "dbo.KhoThuocs");
            DropForeignKey("dbo.BenhNhans", "MaUser", "dbo.Users");
            DropForeignKey("dbo.BacSis", "MaUser", "dbo.Users");
            DropForeignKey("dbo.Users", "MaPQ", "dbo.PhanQuyens");
            DropForeignKey("dbo.BacSis", "MaKhoa", "dbo.PhongKhoas");
            DropIndex("dbo.LichPhanCongs", new[] { "MaBS" });
            DropIndex("dbo.LichPhanCongs", new[] { "MaNV" });
            DropIndex("dbo.LichPhanCongs", new[] { "MaLK" });
            DropIndex("dbo.HoaDonThuocs", new[] { "MaNV" });
            DropIndex("dbo.HoaDonThuocs", new[] { "MaTT" });
            DropIndex("dbo.HoaDonKhamBenhs", new[] { "MaPK" });
            DropIndex("dbo.HoaDonKhamBenhs", new[] { "MaBS" });
            DropIndex("dbo.HoaDonKhamBenhs", new[] { "MaBN" });
            DropIndex("dbo.PhieuKhams", new[] { "MaBS" });
            DropIndex("dbo.PhieuKhams", new[] { "MaBN" });
            DropIndex("dbo.PhieuKhams", new[] { "MaLK" });
            DropIndex("dbo.NhanViens", new[] { "MaUser" });
            DropIndex("dbo.LichKhams", new[] { "MaNV" });
            DropIndex("dbo.LichKhams", new[] { "MaBN" });
            DropIndex("dbo.LichKhams", new[] { "MaBS" });
            DropIndex("dbo.ToaThuocs", new[] { "MaPK" });
            DropIndex("dbo.ToaThuocs", new[] { "MaLK" });
            DropIndex("dbo.ToaThuocs", new[] { "MaBS" });
            DropIndex("dbo.ToaThuocs", new[] { "MaBN" });
            DropIndex("dbo.ChiTietToaThuocs", new[] { "MaTT" });
            DropIndex("dbo.ChiTietToaThuocs", new[] { "MaThuoc" });
            DropIndex("dbo.BenhNhans", new[] { "MaUser" });
            DropIndex("dbo.Users", new[] { "MaPQ" });
            DropIndex("dbo.BacSis", new[] { "MaUser" });
            DropIndex("dbo.BacSis", new[] { "MaKhoa" });
            DropTable("dbo.NhapThuocs");
            DropTable("dbo.LichPhanCongs");
            DropTable("dbo.HoaDonThuocs");
            DropTable("dbo.HoaDonKhamBenhs");
            DropTable("dbo.PhieuKhams");
            DropTable("dbo.NhanViens");
            DropTable("dbo.LichKhams");
            DropTable("dbo.ToaThuocs");
            DropTable("dbo.KhoThuocs");
            DropTable("dbo.ChiTietToaThuocs");
            DropTable("dbo.BenhNhans");
            DropTable("dbo.PhanQuyens");
            DropTable("dbo.Users");
            DropTable("dbo.PhongKhoas");
            DropTable("dbo.BacSis");
        }
    }
}
