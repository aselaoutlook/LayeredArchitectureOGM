using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.ReportObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.Reporting.WebForms;
using FCL.Cockerham.Ogsm.Admin.Core;

namespace FCL.Cockerham.Ogsm.Admin.Reports
{
    public partial class ViewReport : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IUserRepository UserService = DataRepositoryFactory.GetUserRepository();
            List<UserRoles> rptUsr = new List<UserRoles>();
            ICollection<User> AllUsers = new List<User>();
            AllUsers = UserService.GetAll();

            foreach (User user in AllUsers)
            {
                UserRoles tmpUser = new UserRoles();
                tmpUser.UserID = user.UserId;
                tmpUser.UserName = user.UserName;
                tmpUser.FirstName = user.FirstName;
                tmpUser.LastName = user.LastName;
                tmpUser.RoleName = "Roles";
                tmpUser.RoleDescription = "Test 321";

                rptUsr.Add(tmpUser);
            }

            rptReports.LocalReport.ReportPath = Server.MapPath("~/Reports/rptUserDetails.rdlc");
            rptReports.LocalReport.DataSources.Clear();
            ReportDataSource rdc = new ReportDataSource("dsUserDetails", rptUsr);
            rptReports.LocalReport.DataSources.Add(rdc);
            rptReports.LocalReport.Refresh();
        }
    }
}