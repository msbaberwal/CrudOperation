namespace ContactInformation.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateContact : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "PhoneNumber", c => c.String(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Contacts", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}
