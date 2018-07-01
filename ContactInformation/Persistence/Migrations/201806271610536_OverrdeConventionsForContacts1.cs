namespace ContactInformation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class OverrdeConventionsForContacts1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Contacts", "User_Id");
            AddForeignKey("dbo.Contacts", "User_Id", "dbo.AspNetUsers", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Contacts", new[] {"User_Id"});
            DropColumn("dbo.Contacts", "User_Id");
        }
    }
}