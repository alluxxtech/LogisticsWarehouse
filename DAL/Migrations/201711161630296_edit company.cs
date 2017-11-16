namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editcompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Address", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "Address");
        }
    }
}
