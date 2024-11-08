namespace QLPhongMachTu_DOAN_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LichKhams", "TrieuChung");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LichKhams", "TrieuChung", c => c.String());
        }
    }
}
