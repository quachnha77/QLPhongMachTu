namespace QLPhongMachTu_DOAN_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2th : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LichPhanCongs", "MaLK", "dbo.LichKhams");
            DropIndex("dbo.LichPhanCongs", new[] { "MaLK" });
            DropColumn("dbo.LichPhanCongs", "MaLK");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LichPhanCongs", "MaLK", c => c.Long(nullable: false));
            CreateIndex("dbo.LichPhanCongs", "MaLK");
            AddForeignKey("dbo.LichPhanCongs", "MaLK", "dbo.LichKhams", "MaLK");
        }
    }
}
