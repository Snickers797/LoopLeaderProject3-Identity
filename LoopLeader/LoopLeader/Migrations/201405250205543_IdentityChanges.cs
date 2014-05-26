namespace LoopLeader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityChanges : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "Members");
            AddColumn("dbo.Members", "FirstName", c => c.String());
            AddColumn("dbo.Members", "LastName", c => c.String());
            AddColumn("dbo.Members", "EmailAddress", c => c.String());
            AddColumn("dbo.Members", "StreetAddress", c => c.String());
            AddColumn("dbo.Members", "City", c => c.String());
            AddColumn("dbo.Members", "State", c => c.String());
            AddColumn("dbo.Members", "ZipCode", c => c.String());
            AddColumn("dbo.Members", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Country");
            DropColumn("dbo.Members", "ZipCode");
            DropColumn("dbo.Members", "State");
            DropColumn("dbo.Members", "City");
            DropColumn("dbo.Members", "StreetAddress");
            DropColumn("dbo.Members", "EmailAddress");
            DropColumn("dbo.Members", "LastName");
            DropColumn("dbo.Members", "FirstName");
            RenameTable(name: "dbo.Members", newName: "AspNetUsers");
        }
    }
}
