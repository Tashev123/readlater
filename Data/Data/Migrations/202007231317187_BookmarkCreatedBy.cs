namespace ReadLater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookmarkCreatedBy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookmarks", "CreatedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookmarks", "CreatedBy");
        }
    }
}
