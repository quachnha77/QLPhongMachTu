namespace QLPhongMachTu_DOAN_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class RemoveIdentityFromMaPK : DbMigration
    {
        public override void Up()
        {
            // Tạo một cột tạm để lưu trữ dữ liệu MaPK hiện tại
            AddColumn("dbo.PhongKhoas", "MaPK_Temp", c => c.Long(nullable: false));

            // Sao chép dữ liệu từ cột MaPK hiện có sang MaPK_Temp
            Sql("UPDATE dbo.PhongKhoas SET MaPK_Temp = MaPK");

            // Xóa khóa chính hiện tại và cột MaPK có thuộc tính IDENTITY
            DropPrimaryKey("dbo.PhongKhoas");
            DropColumn("dbo.PhongKhoas", "MaPK");

            // Thêm lại cột MaPK mà không có IDENTITY
            AddColumn("dbo.PhongKhoas", "MaPK", c => c.Long(nullable: false));
            Sql("UPDATE dbo.PhongKhoas SET MaPK = MaPK_Temp");

            // Đặt lại khóa chính cho cột MaPK mới
            AddPrimaryKey("dbo.PhongKhoas", "MaPK");

            // Xóa cột tạm
            DropColumn("dbo.PhongKhoas", "MaPK_Temp");
        }

        public override void Down()
        {
            // Khôi phục cột MaPK về trạng thái ban đầu với IDENTITY nếu rollback
            DropPrimaryKey("dbo.PhongKhoas");
            DropColumn("dbo.PhongKhoas", "MaPK");

            AddColumn("dbo.PhongKhoas", "MaPK", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.PhongKhoas", "MaPK");
        }
    }
}
