namespace Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addcolumn1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Constellation", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Constellation");
        }
    }
}
