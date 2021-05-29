namespace Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInvite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "InviteCode", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "InvitedBy_Id", c => c.Int());
            CreateIndex("dbo.Users", "InvitedBy_Id");
            AddForeignKey("dbo.Users", "InvitedBy_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "InvitedBy_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "InvitedBy_Id" });
            DropColumn("dbo.Users", "InvitedBy_Id");
            DropColumn("dbo.Users", "InviteCode");
        }
    }
}
