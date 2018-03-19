#region Header
///--------------------------------------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Cockerham.Ogsm.Data.Entity_Configurations
///MODULE        :         
///SUB MODULE    :    
///Class         : UserEntityConfiguration
///AUTHOR        : Asela Chamara      
///CREATED       : 03/10/2015 
///DESCRIPTION   : Purpose is to add the configuration details of the FCL.Cockerham.Ogsm.Entities.User entity
///MODIFICATION HISTORY:
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///--------------------------------------------------------------------------------------------------------------------------
#endregion

using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);

            this.HasMany(e => e.OwnedActionPlans)
                .WithOptional(e => e.ActionPlanOwner)
                .HasForeignKey(e => e.ActionPlanOwnerId);

            this.HasMany(e => e.EmployeeUser)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            this.HasMany(e => e.PrimaryOwnerGoals)
               .WithOptional(e => e.PrimaryOwner)
               .HasForeignKey(e => e.PrimaryOwnerId);

            this.HasMany(e => e.SecondryOwnerGoals)
                .WithOptional(e => e.SecondryOwner)
                .HasForeignKey(e => e.SecondryOwnerId);

            this.HasMany(e => e.EmployeeUser)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            this.HasMany(e => e.OwnedEmployeeStrategies)
                .WithRequired(e => e.EmployeeStrategyUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            this.HasMany(e => e.OwnerStrategicDrivers)
               .WithOptional(e => e.Owner)
               .HasForeignKey(e => e.OwnerId);
        }
    }
}

/*
 Refer this how to set entity configurations 
 * Example
 * this.ToTable("StudentInfo");
                
            this.HasKey<int>(s => s.StudentKey);
                
                
            this.Property(p => p.DateOfBirth)
                    .HasColumnName("DoB")
                    .HasColumnOrder(3)
                    .HasColumnType("datetime2");

            this.Property(p => p.StudentName)
                    .HasMaxLength(50);
                        
            this.Property(p => p.StudentName)
                    .IsConcurrencyToken();
                
            this.HasMany<Course>(s => s.Courses)
                .WithMany(c => c.Students)
                .Map(cs =>
                        {
                            cs.MapLeftKey("StudentId");
                            cs.MapRightKey("CourseId");
                            cs.ToTable("StudentCourse");
                        });
 */
