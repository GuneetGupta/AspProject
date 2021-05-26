namespace BookEvent.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Invite", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Invite", c => c.String());
        }
    }
}
