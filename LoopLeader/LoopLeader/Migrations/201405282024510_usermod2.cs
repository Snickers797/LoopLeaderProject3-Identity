namespace LoopLeader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usermod2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "PagingInfo_TotalItems", c => c.Int());
            AddColumn("dbo.Members", "PagingInfo_ItemsPerPage", c => c.Int());
            AddColumn("dbo.Members", "PagingInfo_CurrentPage", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "PagingInfo_CurrentPage");
            DropColumn("dbo.Members", "PagingInfo_ItemsPerPage");
            DropColumn("dbo.Members", "PagingInfo_TotalItems");
        }
    }
}
