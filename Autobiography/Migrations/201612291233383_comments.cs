namespace Autobiography.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        SubmittedBy = c.String(),
                        CommentContent = c.String(),
                        ProjectID = c.Int(nullable: false),
                        Projects_ID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Projects", t => t.Projects_ID)
                .Index(t => t.Projects_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Projects_ID", "dbo.Projects");
            DropIndex("dbo.Comments", new[] { "Projects_ID" });
            DropTable("dbo.Comments");
        }
    }
}
