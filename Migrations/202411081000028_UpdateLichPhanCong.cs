namespace QLPhongMachTu_DOAN_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLichPhanCong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LichPhanCongs", "NgayLam", c => c.String());
            DropColumn("dbo.LichPhanCongs", "workingDays");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LichPhanCongs", "workingDays", c => c.Int(nullable: false));
            DropColumn("dbo.LichPhanCongs", "NgayLam");
        }
    }
}
