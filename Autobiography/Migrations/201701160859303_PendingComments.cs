namespace Autobiography.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PendingComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PendingComments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubmittedBy = c.String(),
                        CommentContent = c.String(),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PendingComments");
        }
    }
}
