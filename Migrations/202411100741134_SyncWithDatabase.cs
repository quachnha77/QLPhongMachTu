namespace QLPhongMachTu_DOAN_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SyncWithDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhieuKhamDichVus",
                c => new
                    {
                        MaPK = c.Long(nullable: false),
                        MaDV = c.Long(nullable: false),
                        Gia = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaPK, t.MaDV });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhieuKhamDichVus");
        }
    }
}
