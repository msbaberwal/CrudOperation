namespace ContactInformation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddforeignkeytoContactsTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "PhoneNumber", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "PhoneNumber", c => c.String(nullable: false));
        }
    }
}
