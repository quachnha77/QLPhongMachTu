namespace QLPhongMachTu_DOAN_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLichPhanCong2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LichPhanCongs", "NgayPhanCong", c => c.DateTime(nullable: false));
            DropColumn("dbo.LichPhanCongs", "NgayLam");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LichPhanCongs", "NgayLam", c => c.String());
            DropColumn("dbo.LichPhanCongs", "NgayPhanCong");
        }
    }
}
