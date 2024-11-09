namespace QLPhongMachTu_DOAN_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LichKhams", "TrangThai", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LichKhams", "TrangThai");
        }
    }
}
