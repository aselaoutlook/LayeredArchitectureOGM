namespace FCL.Cockerham.Ogsm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionPlanComment",
                c => new
                    {
                        ActionPlanCommentId = c.Long(nullable: false, identity: true),
                        ActionPlanId = c.Long(nullable: false),
                        Comment = c.String(nullable: false),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Long(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ActionPlanCommentId)
                .ForeignKey("dbo.ActionPlan", t => t.ActionPlanId)
                .Index(t => t.ActionPlanId);
            
            CreateTable(
                "dbo.ActionPlan",
                c => new
                    {
                        ActionPlanId = c.Long(nullable: false, identity: true),
                        GoalId = c.Long(),
                        GoalCategoryId = c.Long(),
                        StrategicDriverId = c.Long(),
                        OrganizationId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1500),
                        ActionPlanOwnerId = c.Long(),
                        IsEvent = c.Boolean(nullable: false),
                        IsCalendarEvent = c.Boolean(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        PlannedCost = c.Decimal(precision: 18, scale: 2),
                        ActualCost = c.Decimal(precision: 18, scale: 2),
                        Impact = c.Decimal(precision: 18, scale: 2),
                        ActionStatusId = c.Long(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Long(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ActionPlanId)
                .ForeignKey("dbo.StrategicDriver", t => t.StrategicDriverId)
                .ForeignKey("dbo.Goal", t => t.GoalId)
                .ForeignKey("dbo.GoalCategory", t => t.GoalCategoryId)
                .ForeignKey("dbo.User", t => t.ActionPlanOwnerId)
                .ForeignKey("dbo.ActionStatus", t => t.ActionStatusId)
                .Index(t => t.GoalId)
                .Index(t => t.GoalCategoryId)
                .Index(t => t.StrategicDriverId)
                .Index(t => t.ActionPlanOwnerId)
                .Index(t => t.ActionStatusId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        OrganizationId = c.Long(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        MiddleInitial = c.String(maxLength: 1),
                        LastName = c.String(nullable: false, maxLength: 100),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        Salt = c.String(maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        Mobile = c.String(maxLength: 15),
                        Image = c.String(maxLength: 100),
                        LastLoggedOn = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        LanguageCode = c.String(maxLength: 5),
                        TimeZone = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        OrganizationId = c.Long(nullable: false),
                        BusinessPhone = c.String(maxLength: 15),
                        Fax = c.String(maxLength: 15),
                        HomePhone = c.String(maxLength: 15),
                        AddressOne = c.String(maxLength: 100),
                        AddressTwo = c.String(maxLength: 100),
                        City = c.String(maxLength: 50),
                        State = c.String(maxLength: 50),
                        Zip = c.String(maxLength: 10),
                        Country = c.String(maxLength: 50),
                        IsBusinessUnitLead = c.Boolean(),
                        IsGoalOwner = c.Boolean(),
                        IsStrategicDriverOwner = c.Boolean(),
                        IsActionPlanOwner = c.Boolean(),
                        IsViewOnly = c.Boolean(),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Long(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.EmployeeStrategy",
                c => new
                    {
                        EmployeeStrategyId = c.Long(nullable: false, identity: true),
                        EmployeeId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        OrganizationId = c.Long(nullable: false),
                        StrategicDriverId = c.Long(),
                        IsBusinessUnitLead = c.Boolean(),
                        IsGoalOwner = c.Boolean(),
                        IsStrategicDriverOwner = c.Boolean(),
                        IsActionPlanOwner = c.Boolean(),
                        IsViewOnly = c.Boolean(),
                        IsActive = c.Boolean(),
                        Notes = c.String(maxLength: 1500, unicode: false),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Long(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.EmployeeStrategyId)
                .ForeignKey("dbo.StrategicDriver", t => t.StrategicDriverId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.EmployeeId)
                .Index(t => t.UserId)
                .Index(t => t.StrategicDriverId);
            
            CreateTable(
                "dbo.StrategicDriver",
                c => new
                    {
                        StrategicDriverId = c.Long(nullable: false, identity: true),
                        DepartmentId = c.Long(),
                        GoalId = c.Long(),
                        GoalCategoryId = c.Long(),
                        FiscalYearId = c.Long(),
                        OrganizationId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1500),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Metric = c.String(nullable: false, maxLength: 300),
                        MetricTarget = c.Decimal(precision: 18, scale: 2),
                        IsMetricDefault = c.Boolean(nullable: false),
                        IsIndexed = c.Boolean(nullable: false),
                        WeightActionPlan = c.Decimal(precision: 18, scale: 2),
                        WeightMetric = c.Decimal(precision: 18, scale: 2),
                        OwnerId = c.Long(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Long(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.StrategicDriverId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.GoalCategory", t => t.GoalCategoryId)
                .ForeignKey("dbo.Goal", t => t.GoalId)
                .ForeignKey("dbo.FiscalYear", t => t.FiscalYearId)
                .ForeignKey("dbo.User", t => t.OwnerId)
                .Index(t => t.DepartmentId)
                .Index(t => t.GoalId)
                .Index(t => t.GoalCategoryId)
                .Index(t => t.FiscalYearId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.CalendarEvent",
                c => new
                    {
                        CalendarEventId = c.Long(nullable: false, identity: true),
                        GoalId = c.Long(),
                        GoalCategoryId = c.Long(),
                        StrategicDriverId = c.Long(),
                        ActionPlanId = c.Long(),
                        OrganizationId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 300),
                        Description = c.String(maxLength: 1500),
                        DueDate = c.DateTime(nullable: false),
                        Location = c.String(maxLength: 300),
                        BgColor = c.String(maxLength: 10),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Long(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CalendarEventId)
                .ForeignKey("dbo.ActionPlan", t => t.ActionPlanId)
                .ForeignKey("dbo.Goal", t => t.GoalId)
                .ForeignKey("dbo.GoalCategory", t => t.GoalCategoryId)
                .ForeignKey("dbo.StrategicDriver", t => t.StrategicDriverId)
                .Index(t => t.GoalId)
                .Index(t => t.GoalCategoryId)
                .Index(t => t.StrategicDriverId)
                .Index(t => t.ActionPlanId);
            
            CreateTable(
                "dbo.Goal",
                c => new
                    {
                        GoalId = c.Long(nullable: false, identity: true),
                        GoalCategoryId = c.Long(),
                        OrganizationId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1500),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        PrimaryOwnerId = c.Long(),
                        SecondryOwnerId = c.Long(),
                        RationaleNotes = c.String(maxLength: 1500),
                        Target = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TargetDesc = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GoalYears = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Long(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.GoalId)
                .ForeignKey("dbo.GoalCategory", t => t.GoalCategoryId)
                .ForeignKey("dbo.User", t => t.PrimaryOwnerId)
                .ForeignKey("dbo.User", t => t.SecondryOwnerId)
                .Index(t => t.GoalCategoryId)
                .Index(t => t.PrimaryOwnerId)
                .Index(t => t.SecondryOwnerId);
            
            CreateTable(
                "dbo.GoalCategory",
                c => new
                    {
                        GoalCategoryId = c.Long(nullable: false, identity: true),
                        DepartmentId = c.Long(),
                        OrganizationId = c.Long(nullable: false),
                        Name = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.GoalCategoryId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
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
            
            CreateTable(
                "dbo.GoalTarget",
                c => new
                    {
                        GoalTargetId = c.Long(nullable: false, identity: true),
                        GoalId = c.Long(nullable: false),
                        OrganizationId = c.Long(nullable: false),
                        YearName = c.String(nullable: false, maxLength: 10),
                        YearValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Results = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Long(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.GoalTargetId)
                .ForeignKey("dbo.Goal", t => t.GoalId)
                .Index(t => t.GoalId);
            
            CreateTable(
                "dbo.FiscalYear",
                c => new
                    {
                        FiscalYearId = c.Long(nullable: false, identity: true),
                        OrganizationId = c.Long(nullable: false),
                        StartYear = c.DateTime(nullable: false),
                        EndYear = c.DateTime(nullable: false),
                        EvaluationLength = c.Int(nullable: false),
                        Description = c.String(maxLength: 1500),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Long(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.FiscalYearId);
            
            CreateTable(
                "dbo.StrategicDriverTarget",
                c => new
                    {
                        StrategicDriverTargetId = c.Long(nullable: false, identity: true),
                        StrategicDriverId = c.Long(nullable: false),
                        OrganizationId = c.Long(nullable: false),
                        QuaterName = c.String(nullable: false, maxLength: 10),
                        QuaterValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Long(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.StrategicDriverTargetId)
                .ForeignKey("dbo.StrategicDriver", t => t.StrategicDriverId)
                .Index(t => t.StrategicDriverId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        OrganizationId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        AddressOne = c.String(maxLength: 100),
                        AddressTwo = c.String(maxLength: 100),
                        City = c.String(maxLength: 50),
                        State = c.String(maxLength: 50),
                        Zip = c.String(maxLength: 10),
                        Phone = c.String(maxLength: 15),
                        Logo = c.String(maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Long(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Long(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 20),
                        RoleDescription = c.String(maxLength: 1500),
                        IsSysAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        PermissionId = c.Long(nullable: false, identity: true),
                        PermissionDescription = c.String(nullable: false, maxLength: 1500),
                    })
                .PrimaryKey(t => t.PermissionId);
            
            CreateTable(
                "dbo.ActionStatus",
                c => new
                    {
                        ActionStatusId = c.Long(nullable: false, identity: true),
                        Status = c.String(nullable: false, maxLength: 200, unicode: false),
                        Factor = c.Int(nullable: false),
                        colorcode = c.String(maxLength: 7, unicode: false),
                        Operator = c.Long(),
                        RangeStart = c.Decimal(precision: 18, scale: 2),
                        RangeEnd = c.Decimal(precision: 18, scale: 2),
                        IsGlobal = c.Boolean(nullable: false),
                        ChartStatus = c.String(nullable: false, maxLength: 200, unicode: false),
                        IsApproveStatus = c.Boolean(),
                    })
                .PrimaryKey(t => t.ActionStatusId)
                .ForeignKey("dbo.ActionOperator", t => t.Operator)
                .Index(t => t.Operator);
            
            CreateTable(
                "dbo.ActionOperator",
                c => new
                    {
                        ActionOperatorId = c.Long(nullable: false, identity: true),
                        Operator = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ActionOperatorId);
            
            CreateTable(
                "dbo.AppSettingBase",
                c => new
                    {
                        AppSettingBaseId = c.Long(nullable: false, identity: true),
                        SettingValue = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AppSettingBaseId);
            
            CreateTable(
                "dbo.AppSetting",
                c => new
                    {
                        AppSettingId = c.Long(nullable: false, identity: true),
                        OrganizationId = c.Long(nullable: false),
                        AppSettingBaseId = c.Long(nullable: false),
                        AppSettingValue = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AppSettingId)
                .ForeignKey("dbo.AppSettingBase", t => t.AppSettingBaseId)
                .Index(t => t.AppSettingBaseId);
            
            CreateTable(
                "dbo.Audit",
                c => new
                    {
                        AuditId = c.Long(nullable: false, identity: true),
                        EventDateUTC = c.DateTime(nullable: false),
                        Action = c.String(),
                        TableName = c.String(),
                        UserName = c.String(),
                        RecordID = c.String(),
                        OldData = c.String(),
                        NewData = c.String(),
                    })
                .PrimaryKey(t => t.AuditId);
            
            CreateTable(
                "dbo.BusinessUnit",
                c => new
                    {
                        BusinessUnitId = c.Long(nullable: false, identity: true),
                        OrganizationId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 300),
                        Description = c.String(maxLength: 1500),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Long(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.BusinessUnitId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryId = c.Long(nullable: false, identity: true),
                        OrganizationId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        GlobalRegionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId)
                .ForeignKey("dbo.GlobalRegion", t => t.GlobalRegionId)
                .Index(t => t.GlobalRegionId);
            
            CreateTable(
                "dbo.GlobalRegion",
                c => new
                    {
                        GlobalRegionId = c.Long(nullable: false, identity: true),
                        OrganizationId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GlobalRegionId);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationId = c.Long(nullable: false, identity: true),
                        OrganizationId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 300),
                        IsGlobal = c.Boolean(nullable: false),
                        StateId = c.Long(nullable: false),
                        CountryId = c.Long(nullable: false),
                        GlobalRegionId = c.Long(nullable: false),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Long(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.LocationId)
                .ForeignKey("dbo.State", t => t.StateId)
                .ForeignKey("dbo.GlobalRegion", t => t.GlobalRegionId)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.StateId)
                .Index(t => t.CountryId)
                .Index(t => t.GlobalRegionId);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateId = c.Long(nullable: false, identity: true),
                        CountryId = c.Long(nullable: false),
                        OrganizationId = c.Long(nullable: false),
                        StateName = c.String(nullable: false, maxLength: 50),
                        StateCode = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.StateId)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Csf",
                c => new
                    {
                        CsfId = c.Long(nullable: false, identity: true),
                        OrganizationId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 300),
                        Description = c.String(maxLength: 1500),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Long(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CsfId);
            
            CreateTable(
                "dbo.DisplayBase",
                c => new
                    {
                        DisplayBaseId = c.Long(nullable: false, identity: true),
                        DisplayValue = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.DisplayBaseId);
            
            CreateTable(
                "dbo.DisplayName",
                c => new
                    {
                        DisplayNameId = c.Long(nullable: false, identity: true),
                        OrganizationId = c.Long(nullable: false),
                        DisplayBaseId = c.Long(nullable: false),
                        DisplayValue = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.DisplayNameId)
                .ForeignKey("dbo.DisplayBase", t => t.DisplayBaseId)
                .Index(t => t.DisplayBaseId);
            
            CreateTable(
                "dbo.Pillar",
                c => new
                    {
                        PillarId = c.Long(nullable: false, identity: true),
                        OrganizationId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 300),
                        Description = c.String(maxLength: 1500),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Long(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PillarId);
            
            CreateTable(
                "dbo.ScorecardPerspective",
                c => new
                    {
                        ScorecardPerspectiveId = c.Long(nullable: false, identity: true),
                        OrganizationId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 300),
                        Description = c.String(maxLength: 1500),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Long(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ScorecardPerspectiveId);
            
            CreateTable(
                "dbo.RolePermission",
                c => new
                    {
                        PermissionId = c.Long(nullable: false),
                        RoleID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.PermissionId, t.RoleID })
                .ForeignKey("dbo.Permission", t => t.PermissionId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.PermissionId)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        RoleId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateStoredProcedure(
                "dbo.Audit_Insert",
                p => new
                    {
                        EventDateUTC = p.DateTime(),
                        Action = p.String(),
                        TableName = p.String(),
                        UserName = p.String(),
                        RecordID = p.String(),
                        OldData = p.String(),
                        NewData = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Audit]([EventDateUTC], [Action], [TableName], [UserName], [RecordID], [OldData], [NewData])
                      VALUES (@EventDateUTC, @Action, @TableName, @UserName, @RecordID, @OldData, @NewData)
                      
                      DECLARE @AuditId bigint
                      SELECT @AuditId = [AuditId]
                      FROM [dbo].[Audit]
                      WHERE @@ROWCOUNT > 0 AND [AuditId] = scope_identity()
                      
                      SELECT t0.[AuditId]
                      FROM [dbo].[Audit] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[AuditId] = @AuditId"
            );
            
            CreateStoredProcedure(
                "dbo.Audit_Update",
                p => new
                    {
                        AuditId = p.Long(),
                        EventDateUTC = p.DateTime(),
                        Action = p.String(),
                        TableName = p.String(),
                        UserName = p.String(),
                        RecordID = p.String(),
                        OldData = p.String(),
                        NewData = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Audit]
                      SET [EventDateUTC] = @EventDateUTC, [Action] = @Action, [TableName] = @TableName, [UserName] = @UserName, [RecordID] = @RecordID, [OldData] = @OldData, [NewData] = @NewData
                      WHERE ([AuditId] = @AuditId)"
            );
            
            CreateStoredProcedure(
                "dbo.Audit_Delete",
                p => new
                    {
                        AuditId = p.Long(),
                    },
                body:
                    @"DELETE [dbo].[Audit]
                      WHERE ([AuditId] = @AuditId)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Audit_Delete");
            DropStoredProcedure("dbo.Audit_Update");
            DropStoredProcedure("dbo.Audit_Insert");
            DropForeignKey("dbo.DisplayName", "DisplayBaseId", "dbo.DisplayBase");
            DropForeignKey("dbo.State", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Location", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Location", "GlobalRegionId", "dbo.GlobalRegion");
            DropForeignKey("dbo.Location", "StateId", "dbo.State");
            DropForeignKey("dbo.Country", "GlobalRegionId", "dbo.GlobalRegion");
            DropForeignKey("dbo.AppSetting", "AppSettingBaseId", "dbo.AppSettingBase");
            DropForeignKey("dbo.ActionPlan", "ActionStatusId", "dbo.ActionStatus");
            DropForeignKey("dbo.ActionStatus", "Operator", "dbo.ActionOperator");
            DropForeignKey("dbo.Goal", "SecondryOwnerId", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RolePermission", "RoleID", "dbo.Role");
            DropForeignKey("dbo.RolePermission", "PermissionId", "dbo.Permission");
            DropForeignKey("dbo.Goal", "PrimaryOwnerId", "dbo.User");
            DropForeignKey("dbo.StrategicDriver", "OwnerId", "dbo.User");
            DropForeignKey("dbo.EmployeeStrategy", "UserId", "dbo.User");
            DropForeignKey("dbo.ActionPlan", "ActionPlanOwnerId", "dbo.User");
            DropForeignKey("dbo.User", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Employee", "UserId", "dbo.User");
            DropForeignKey("dbo.EmployeeStrategy", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.StrategicDriverTarget", "StrategicDriverId", "dbo.StrategicDriver");
            DropForeignKey("dbo.StrategicDriver", "FiscalYearId", "dbo.FiscalYear");
            DropForeignKey("dbo.EmployeeStrategy", "StrategicDriverId", "dbo.StrategicDriver");
            DropForeignKey("dbo.CalendarEvent", "StrategicDriverId", "dbo.StrategicDriver");
            DropForeignKey("dbo.StrategicDriver", "GoalId", "dbo.Goal");
            DropForeignKey("dbo.GoalTarget", "GoalId", "dbo.Goal");
            DropForeignKey("dbo.StrategicDriver", "GoalCategoryId", "dbo.GoalCategory");
            DropForeignKey("dbo.Goal", "GoalCategoryId", "dbo.GoalCategory");
            DropForeignKey("dbo.StrategicDriver", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.GoalCategory", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.CalendarEvent", "GoalCategoryId", "dbo.GoalCategory");
            DropForeignKey("dbo.ActionPlan", "GoalCategoryId", "dbo.GoalCategory");
            DropForeignKey("dbo.CalendarEvent", "GoalId", "dbo.Goal");
            DropForeignKey("dbo.ActionPlan", "GoalId", "dbo.Goal");
            DropForeignKey("dbo.CalendarEvent", "ActionPlanId", "dbo.ActionPlan");
            DropForeignKey("dbo.ActionPlan", "StrategicDriverId", "dbo.StrategicDriver");
            DropForeignKey("dbo.ActionPlanComment", "ActionPlanId", "dbo.ActionPlan");
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.RolePermission", new[] { "RoleID" });
            DropIndex("dbo.RolePermission", new[] { "PermissionId" });
            DropIndex("dbo.DisplayName", new[] { "DisplayBaseId" });
            DropIndex("dbo.State", new[] { "CountryId" });
            DropIndex("dbo.Location", new[] { "GlobalRegionId" });
            DropIndex("dbo.Location", new[] { "CountryId" });
            DropIndex("dbo.Location", new[] { "StateId" });
            DropIndex("dbo.Country", new[] { "GlobalRegionId" });
            DropIndex("dbo.AppSetting", new[] { "AppSettingBaseId" });
            DropIndex("dbo.ActionStatus", new[] { "Operator" });
            DropIndex("dbo.StrategicDriverTarget", new[] { "StrategicDriverId" });
            DropIndex("dbo.GoalTarget", new[] { "GoalId" });
            DropIndex("dbo.GoalCategory", new[] { "DepartmentId" });
            DropIndex("dbo.Goal", new[] { "SecondryOwnerId" });
            DropIndex("dbo.Goal", new[] { "PrimaryOwnerId" });
            DropIndex("dbo.Goal", new[] { "GoalCategoryId" });
            DropIndex("dbo.CalendarEvent", new[] { "ActionPlanId" });
            DropIndex("dbo.CalendarEvent", new[] { "StrategicDriverId" });
            DropIndex("dbo.CalendarEvent", new[] { "GoalCategoryId" });
            DropIndex("dbo.CalendarEvent", new[] { "GoalId" });
            DropIndex("dbo.StrategicDriver", new[] { "OwnerId" });
            DropIndex("dbo.StrategicDriver", new[] { "FiscalYearId" });
            DropIndex("dbo.StrategicDriver", new[] { "GoalCategoryId" });
            DropIndex("dbo.StrategicDriver", new[] { "GoalId" });
            DropIndex("dbo.StrategicDriver", new[] { "DepartmentId" });
            DropIndex("dbo.EmployeeStrategy", new[] { "StrategicDriverId" });
            DropIndex("dbo.EmployeeStrategy", new[] { "UserId" });
            DropIndex("dbo.EmployeeStrategy", new[] { "EmployeeId" });
            DropIndex("dbo.Employee", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "OrganizationId" });
            DropIndex("dbo.ActionPlan", new[] { "ActionStatusId" });
            DropIndex("dbo.ActionPlan", new[] { "ActionPlanOwnerId" });
            DropIndex("dbo.ActionPlan", new[] { "StrategicDriverId" });
            DropIndex("dbo.ActionPlan", new[] { "GoalCategoryId" });
            DropIndex("dbo.ActionPlan", new[] { "GoalId" });
            DropIndex("dbo.ActionPlanComment", new[] { "ActionPlanId" });
            DropTable("dbo.UserRole");
            DropTable("dbo.RolePermission");
            DropTable("dbo.ScorecardPerspective");
            DropTable("dbo.Pillar");
            DropTable("dbo.DisplayName");
            DropTable("dbo.DisplayBase");
            DropTable("dbo.Csf");
            DropTable("dbo.State");
            DropTable("dbo.Location");
            DropTable("dbo.GlobalRegion");
            DropTable("dbo.Country");
            DropTable("dbo.BusinessUnit");
            DropTable("dbo.Audit");
            DropTable("dbo.AppSetting");
            DropTable("dbo.AppSettingBase");
            DropTable("dbo.ActionOperator");
            DropTable("dbo.ActionStatus");
            DropTable("dbo.Permission");
            DropTable("dbo.Role");
            DropTable("dbo.Organizations");
            DropTable("dbo.StrategicDriverTarget");
            DropTable("dbo.FiscalYear");
            DropTable("dbo.GoalTarget");
            DropTable("dbo.Department");
            DropTable("dbo.GoalCategory");
            DropTable("dbo.Goal");
            DropTable("dbo.CalendarEvent");
            DropTable("dbo.StrategicDriver");
            DropTable("dbo.EmployeeStrategy");
            DropTable("dbo.Employee");
            DropTable("dbo.User");
            DropTable("dbo.ActionPlan");
            DropTable("dbo.ActionPlanComment");
        }
    }
}
