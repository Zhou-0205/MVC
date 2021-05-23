namespace Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthorId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Articles", name: "Author_Id", newName: "AuthorId");
            RenameIndex(table: "dbo.Articles", name: "IX_Author_Id", newName: "IX_AuthorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Articles", name: "IX_AuthorId", newName: "IX_Author_Id");
            RenameColumn(table: "dbo.Articles", name: "AuthorId", newName: "Author_Id");
        }
    }
}
