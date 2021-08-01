namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_message_messageRead : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ReadMessage", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "ReadMessage");
        }
    }
}
