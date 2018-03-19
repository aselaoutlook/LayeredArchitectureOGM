#region Header
///-------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Cockerham.Ogsm.Admin.Core.Util
///MODULE        :         
///SUB MODULE    :    
///Class         : Constants
///AUTHOR        : Asela Chamara      
///CREATED       : 12/08/2015        
///DESCRIPTION   : Purpose is to hold constant value of the application
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCL.Cockerham.Ogsm.ClientSite.Core.Util
{
    public class Constants
    {
        //field lenght
        public const int MIDDLEINITAL_LENGTH = 1;
        public const int FIRSTNAME_LENGTH = 200;
        public const int LASTNAME_LENGTH = 200;
        public const int USERNAME_LENGTH = 50;
        public const int EMAIL_LENGTH = 50;
        public const int PASSWORD_LENGTH = 100;
        public const int MOBILE_LENGTH = 15;
        public const int NOTES_LENGTH = 2500;
        public const int ZIP_LENGTH = 10;
        public const int HOMEPHONE_LENGTH = 15;
        public const int FAX_LENGTH = 15;
        public const int COUNTRY_LENGTH = 200;
        public const int CITY_LENGTH = 200;
        public const int BUSINESSPHONE_LENGTH = 15;
        public const int ADDRESSLINE1_LENGTH = 300;
        public const int ADDRESSLINE2_LENGTH = 300;

        //Active inactive
        public const string Active = "1";
        public const string Inactive = "0";

        //Sub User Types
        public const string SESSION_ADMIN = "Admin";
        public const string SESSION_USER = "Standard User";
        public const string SESSION_SUPER_ADMIN = "Super Admin";
        public const string SESSION_CONSULTANT = "Consultant";
        public const string SESSION_CLIENT_ADMIN = "Client Admin";
        public const string SESSION_REGIONAL_ADMIN = "Regional Admin";
        public const string SESSION_GROUP_ADMIN = "Group Admin";
        public const string SESSION_STRATEGY_OWNER = "Strategy Owner";
        public const string SESSION_LEADERSHIP_TEAM = "Leadership Team Member";
        public const string SESSION_ACTION_OWNER = "Action Owner";
        public const string SESSION_EMPLOYEE = "Employee";
    }
}