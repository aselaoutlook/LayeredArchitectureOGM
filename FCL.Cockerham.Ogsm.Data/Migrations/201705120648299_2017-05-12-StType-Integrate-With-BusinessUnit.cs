namespace FCL.Cockerham.Ogsm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170512StTypeIntegrateWithBusinessUnit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StType", "BusinessUnitId", c => c.Long());
            CreateIndex("dbo.StType", "BusinessUnitId");
            AddForeignKey("dbo.StType", "BusinessUnitId", "dbo.BusinessUnit", "BusinessUnitId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StType", "BusinessUnitId", "dbo.BusinessUnit");
            DropIndex("dbo.StType", new[] { "BusinessUnitId" });
            DropColumn("dbo.StType", "BusinessUnitId");
        }
    }
}
