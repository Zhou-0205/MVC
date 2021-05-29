namespace Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsMale", c => c.Boolean());
            AddColumn("dbo.Users", "IconPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IconPath");
            DropColumn("dbo.Users", "IsMale");
        }
    }
}
