namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeUserProfilesdelDepotId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Depots", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Depots", "Address", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Companies", "CorpEmail", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Products", "ProductType", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Sender", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 256));
            DropColumn("dbo.UserProfiles", "DepotId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "DepotId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Sender", c => c.String());
            AlterColumn("dbo.Products", "ProductType", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Companies", "CorpEmail", c => c.String());
            AlterColumn("dbo.Companies", "Name", c => c.String());
            AlterColumn("dbo.Depots", "Address", c => c.String());
            AlterColumn("dbo.Depots", "Name", c => c.String());
            AlterColumn("dbo.Countries", "Name", c => c.String());
            AlterColumn("dbo.Cities", "Name", c => c.String());
        }
    }
}
