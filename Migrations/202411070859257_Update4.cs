namespace QLPhongMachTu_DOAN_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LichKhams", "TrieuChung", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LichKhams", "TrieuChung");
        }
    }
}
