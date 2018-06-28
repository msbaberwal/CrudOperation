namespace ContactInformation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddforeignkeytoContactsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Contacts", new[] { "User_Id" });
            RenameColumn(table: "dbo.Contacts", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Contacts", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Contacts", "UserId");
            AddForeignKey("dbo.Contacts", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Contacts", new[] { "UserId" });
            AlterColumn("dbo.Contacts", "UserId", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Contacts", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Contacts", "User_Id");
            AddForeignKey("dbo.Contacts", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
