#region Header
///-------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Cockerham.Ogsm.Admin.Core
///MODULE        :         
///SUB MODULE    :    
///Class         : IEmailSender
///AUTHOR        : Asela Chamara      
///CREATED       : 12/08/2015        
///DESCRIPTION   : Purpose is to provide an interface FCL.Cockerham.Ogsm.Admin.Core.Util.EmailSender
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------
#endregion

using FCL.Cockerham.Ogsm.Entities.CustomObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCL.Cockerham.Ogsm.Admin.Core
{
    public interface IEmailSender
    {
        bool SendEmail(EmailMessage email);

        bool SendEmail(EmailMessage email, string attachment);
    }
}
