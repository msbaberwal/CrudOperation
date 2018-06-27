namespace ContactInformation.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateContact1 : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO CONTACTS (FIRSTNAME,LASTNAME,EMAILID,PHONENUMBER,STATUS) VALUES ('JOHN','BARNETT','JOHNB@GMAIL.COM','8989898989','TRUE')");
        }

        public override void Down()
        {
            Sql("DELETE FROM CONTACTS WHERE ID = 1");
        }
    }
}
