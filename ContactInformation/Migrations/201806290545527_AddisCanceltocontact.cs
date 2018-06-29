namespace ContactInformation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddisCanceltocontact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "IsCanceled");
        }
    }
}
