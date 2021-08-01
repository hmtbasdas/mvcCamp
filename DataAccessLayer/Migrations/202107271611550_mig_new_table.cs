namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_new_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MySkills",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        SkillName = c.String(maxLength: 50),
                        SkillPoint = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MySkills");
        }
    }
}
