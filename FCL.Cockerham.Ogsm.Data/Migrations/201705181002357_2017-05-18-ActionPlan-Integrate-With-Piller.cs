namespace FCL.Cockerham.Ogsm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170518ActionPlanIntegrateWithPiller : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ActionPlan", name: "GoalCategoryId", newName: "GoalCategory_GoalCategoryId");
            RenameIndex(table: "dbo.ActionPlan", name: "IX_GoalCategoryId", newName: "IX_GoalCategory_GoalCategoryId");
            AddColumn("dbo.ActionPlan", "PillarId", c => c.Long());
            CreateIndex("dbo.ActionPlan", "PillarId");
            AddForeignKey("dbo.ActionPlan", "PillarId", "dbo.Pillar", "PillarId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActionPlan", "PillarId", "dbo.Pillar");
            DropIndex("dbo.ActionPlan", new[] { "PillarId" });
            DropColumn("dbo.ActionPlan", "PillarId");
            RenameIndex(table: "dbo.ActionPlan", name: "IX_GoalCategory_GoalCategoryId", newName: "IX_GoalCategoryId");
            RenameColumn(table: "dbo.ActionPlan", name: "GoalCategory_GoalCategoryId", newName: "GoalCategoryId");
        }
    }
}
