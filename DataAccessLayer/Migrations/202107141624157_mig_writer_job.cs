﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writer_job : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterJob", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterJob");
        }
    }
}
