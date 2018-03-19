namespace FCL.Cockerham.Ogsm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170505ExcelChangesAppended : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GoalCategory", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.StrategicDriver", "DepartmentId", "dbo.Department");
            DropIndex("dbo.StrategicDriver", new[] { "DepartmentId" });
            DropIndex("dbo.GoalCategory", new[] { "DepartmentId" });
            CreateTable(
                "dbo.StType",
                c => new
                    {
                        StTypeId = c.Long(nullable: false, identity: true),
                        OrganizationId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 1500),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Long(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.StTypeId);
            
            AddColumn("dbo.ActionPlan", "SequenceNumber", c => c.Int());
            AddColumn("dbo.StrategicDriver", "StTypeId", c => c.Long());
            AddColumn("dbo.StrategicDriver", "PillarId", c => c.Long());
            AddColumn("dbo.StrategicDriver", "Description", c => c.String(maxLength: 1500));
            AddColumn("dbo.StrategicDriver", "SequenceNumber", c => c.Int());
            AddColumn("dbo.StrategicDriver", "UseMultipleMetrics", c => c.Boolean());
            AddColumn("dbo.StrategicDriver", "IsCascade", c => c.Boolean());
            AddColumn("dbo.StrategicDriver", "IsBestPractice", c => c.Boolean());
            AddColumn("dbo.CalendarEvent", "PillarId", c => c.Long());
            AddColumn("dbo.Goal", "PillarId", c => c.Long());
            AddColumn("dbo.Goal", "Description", c => c.String(maxLength: 1500));
            AddColumn("dbo.Goal", "AltDescription", c => c.String(maxLength: 1500));
            AddColumn("dbo.Goal", "NoOfYears", c => c.Int());
            AddColumn("dbo.Goal", "SequenceNumber", c => c.Int());
            AddColumn("dbo.Goal", "BaselineDate", c => c.DateTime());
            AddColumn("dbo.Goal", "BaselineNo", c => c.Int());
            AddColumn("dbo.GoalCategory", "StTypeId", c => c.Long());
            AddColumn("dbo.BusinessUnit", "Location", c => c.String(maxLength: 50));
            AddColumn("dbo.Csf", "StTypeId", c => c.Long());
            AddColumn("dbo.Csf", "SequenceNumber", c => c.Int());
            AddColumn("dbo.Pillar", "StTypeId", c => c.Long());
            AddColumn("dbo.Pillar", "SequenceNumber", c => c.Int());
            CreateIndex("dbo.StrategicDriver", "StTypeId");
            CreateIndex("dbo.StrategicDriver", "PillarId");
            CreateIndex("dbo.CalendarEvent", "PillarId");
            CreateIndex("dbo.Goal", "PillarId");
            CreateIndex("dbo.GoalCategory", "StTypeId");
            CreateIndex("dbo.Pillar", "StTypeId");
            CreateIndex("dbo.Csf", "StTypeId");
            AddForeignKey("dbo.GoalCategory", "StTypeId", "dbo.StType", "StTypeId");
            AddForeignKey("dbo.StrategicDriver", "StTypeId", "dbo.StType", "StTypeId");
            AddForeignKey("dbo.Pillar", "StTypeId", "dbo.StType", "StTypeId");
            AddForeignKey("dbo.Goal", "PillarId", "dbo.Pillar", "PillarId");
            AddForeignKey("dbo.CalendarEvent", "PillarId", "dbo.Pillar", "PillarId");
            AddForeignKey("dbo.StrategicDriver", "PillarId", "dbo.Pillar", "PillarId");
            AddForeignKey("dbo.Csf", "StTypeId", "dbo.StType", "StTypeId");
            DropColumn("dbo.StrategicDriver", "DepartmentId");
            DropColumn("dbo.GoalCategory", "DepartmentId");
            DropTable("dbo.Department");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Long(nullable: false, identity: true),
                        OrganizationId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 1500),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Long(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            AddColumn("dbo.GoalCategory", "DepartmentId", c => c.Long());
            AddColumn("dbo.StrategicDriver", "DepartmentId", c => c.Long());
            DropForeignKey("dbo.Csf", "StTypeId", "dbo.StType");
            DropForeignKey("dbo.StrategicDriver", "PillarId", "dbo.Pillar");
            DropForeignKey("dbo.CalendarEvent", "PillarId", "dbo.Pillar");
            DropForeignKey("dbo.Goal", "PillarId", "dbo.Pillar");
            DropForeignKey("dbo.Pillar", "StTypeId", "dbo.StType");
            DropForeignKey("dbo.StrategicDriver", "StTypeId", "dbo.StType");
            DropForeignKey("dbo.GoalCategory", "StTypeId", "dbo.StType");
            DropIndex("dbo.Csf", new[] { "StTypeId" });
            DropIndex("dbo.Pillar", new[] { "StTypeId" });
            DropIndex("dbo.GoalCategory", new[] { "StTypeId" });
            DropIndex("dbo.Goal", new[] { "PillarId" });
            DropIndex("dbo.CalendarEvent", new[] { "PillarId" });
            DropIndex("dbo.StrategicDriver", new[] { "PillarId" });
            DropIndex("dbo.StrategicDriver", new[] { "StTypeId" });
            DropColumn("dbo.Pillar", "SequenceNumber");
            DropColumn("dbo.Pillar", "StTypeId");
            DropColumn("dbo.Csf", "SequenceNumber");
            DropColumn("dbo.Csf", "StTypeId");
            DropColumn("dbo.BusinessUnit", "Location");
            DropColumn("dbo.GoalCategory", "StTypeId");
            DropColumn("dbo.Goal", "BaselineNo");
            DropColumn("dbo.Goal", "BaselineDate");
            DropColumn("dbo.Goal", "SequenceNumber");
            DropColumn("dbo.Goal", "NoOfYears");
            DropColumn("dbo.Goal", "AltDescription");
            DropColumn("dbo.Goal", "Description");
            DropColumn("dbo.Goal", "PillarId");
            DropColumn("dbo.CalendarEvent", "PillarId");
            DropColumn("dbo.StrategicDriver", "IsBestPractice");
            DropColumn("dbo.StrategicDriver", "IsCascade");
            DropColumn("dbo.StrategicDriver", "UseMultipleMetrics");
            DropColumn("dbo.StrategicDriver", "SequenceNumber");
            DropColumn("dbo.StrategicDriver", "Description");
            DropColumn("dbo.StrategicDriver", "PillarId");
            DropColumn("dbo.StrategicDriver", "StTypeId");
            DropColumn("dbo.ActionPlan", "SequenceNumber");
            DropTable("dbo.StType");
            CreateIndex("dbo.GoalCategory", "DepartmentId");
            CreateIndex("dbo.StrategicDriver", "DepartmentId");
            AddForeignKey("dbo.StrategicDriver", "DepartmentId", "dbo.Department", "DepartmentId");
            AddForeignKey("dbo.GoalCategory", "DepartmentId", "dbo.Department", "DepartmentId");
        }
    }
}
