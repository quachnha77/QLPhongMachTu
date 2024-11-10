namespace QLPhongMachTu_DOAN_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDichVuTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DichVus",
                c => new
                    {
                        MaDV = c.Long(nullable: false, identity: true),
                        TenDichVu = c.String(maxLength: 255),
                        MoTa = c.String(maxLength: 500),
                        DonGia = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MaDV);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DichVus");
        }
    }
}
