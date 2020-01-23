namespace PetGrooming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class good : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "GoodBoyorGirl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pets", "GoodBoyorGirl");
        }
    }
}
