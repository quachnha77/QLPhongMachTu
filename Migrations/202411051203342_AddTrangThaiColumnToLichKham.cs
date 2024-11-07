namespace QLPhongMachTu_DOAN_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrangThaiColumnToLichKham : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LichKhams", "TrangThai", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LichKhams", "TrangThai");
        }
    }
}
