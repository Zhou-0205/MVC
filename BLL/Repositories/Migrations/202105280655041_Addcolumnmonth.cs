namespace Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addcolumnmonth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "BirthMonth", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "BirthMonth");
        }
    }
}
