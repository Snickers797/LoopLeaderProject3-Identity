namespace LoopLeader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityChanges2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentID = c.String(nullable: false, maxLength: 128),
                        CurrentText = c.String(),
                        NewText = c.String(),
                    })
                .PrimaryKey(t => t.ContentID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InStock = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Contents");
        }
    }
}
