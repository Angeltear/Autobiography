namespace Autobiography.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentsFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Projects_ID", "dbo.Projects");
            DropIndex("dbo.Comments", new[] { "Projects_ID" });
            DropColumn("dbo.Comments", "ProjectID");
            RenameColumn(table: "dbo.Comments", name: "Projects_ID", newName: "ProjectID");
            AlterColumn("dbo.Comments", "ProjectID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "ProjectID");
            AddForeignKey("dbo.Comments", "ProjectID", "dbo.Projects", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ProjectID", "dbo.Projects");
            DropIndex("dbo.Comments", new[] { "ProjectID" });
            AlterColumn("dbo.Comments", "ProjectID", c => c.Int());
            RenameColumn(table: "dbo.Comments", name: "ProjectID", newName: "Projects_ID");
            AddColumn("dbo.Comments", "ProjectID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "Projects_ID");
            AddForeignKey("dbo.Comments", "Projects_ID", "dbo.Projects", "ID");
        }
    }
}
