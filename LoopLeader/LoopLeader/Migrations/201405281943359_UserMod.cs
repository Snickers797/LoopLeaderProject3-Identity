namespace LoopLeader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserMod : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "EmailAddress", c => c.String(maxLength: 50));
            AlterColumn("dbo.Members", "StreetAddress", c => c.String(maxLength: 100));
            AlterColumn("dbo.Members", "City", c => c.String(maxLength: 50));
            AlterColumn("dbo.Members", "State", c => c.String(maxLength: 20));
            AlterColumn("dbo.Members", "Country", c => c.String(maxLength: 65));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Country", c => c.String());
            AlterColumn("dbo.Members", "State", c => c.String());
            AlterColumn("dbo.Members", "City", c => c.String());
            AlterColumn("dbo.Members", "StreetAddress", c => c.String());
            AlterColumn("dbo.Members", "EmailAddress", c => c.String());
        }
    }
}
