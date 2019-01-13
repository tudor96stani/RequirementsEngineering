namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedIsOrganization : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "IsOrganization");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IsOrganization", c => c.Boolean(nullable: false));
        }
    }
}
