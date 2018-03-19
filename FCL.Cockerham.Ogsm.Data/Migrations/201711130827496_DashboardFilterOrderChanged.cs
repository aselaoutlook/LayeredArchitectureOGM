namespace FCL.Cockerham.Ogsm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DashboardFilterOrderChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StType", "BusinessUnitId", "dbo.BusinessUnit");
            DropIndex("dbo.StType", new[] { "BusinessUnitId" });
            AddColumn("dbo.BusinessUnit", "StTypeId", c => c.Long());
            CreateIndex("dbo.BusinessUnit", "StTypeId");
            AddForeignKey("dbo.BusinessUnit", "StTypeId", "dbo.StType", "StTypeId");
            DropColumn("dbo.StType", "BusinessUnitId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StType", "BusinessUnitId", c => c.Long());
            DropForeignKey("dbo.BusinessUnit", "StTypeId", "dbo.StType");
            DropIndex("dbo.BusinessUnit", new[] { "StTypeId" });
            DropColumn("dbo.BusinessUnit", "StTypeId");
            CreateIndex("dbo.StType", "BusinessUnitId");
            AddForeignKey("dbo.StType", "BusinessUnitId", "dbo.BusinessUnit", "BusinessUnitId");
        }
    }
}
