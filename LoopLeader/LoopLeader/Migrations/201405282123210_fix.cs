namespace LoopLeader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Members", "PagingInfo_TotalItems");
            DropColumn("dbo.Members", "PagingInfo_ItemsPerPage");
            DropColumn("dbo.Members", "PagingInfo_CurrentPage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "PagingInfo_CurrentPage", c => c.Int());
            AddColumn("dbo.Members", "PagingInfo_ItemsPerPage", c => c.Int());
            AddColumn("dbo.Members", "PagingInfo_TotalItems", c => c.Int());
        }
    }
}
