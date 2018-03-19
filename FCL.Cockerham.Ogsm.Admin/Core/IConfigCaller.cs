#region Header
///-------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Cockerham.Ogsm.Admin.Core
///MODULE        :         
///SUB MODULE    :    
///Class         : IConfigCaller
///AUTHOR        : Asela Chamara      
///CREATED       : 12/08/2015        
///DESCRIPTION   : Purpose is to provide an interface for 
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------
#endregion

using System;
namespace FCL.Cockerham.Ogsm.Admin.Core
{
    interface IConfigCaller
    {
        string CopyEmail { get; }
        string FromAddress { get; }
        string IsStaging { get; }
        int LogoMaxHeight { get; }
        int LogoMaxWidth { get; }
        int MaxCommentLength { get; }
        string PageSize { get; }
        string RedirectPath { get; }
        string SiteAddress { get; }
        string SiteName { get; }
        string SMTPPass { get; }
        string SMTPPort { get; }
        string SMTPServer { get; }
        bool SMTPSsl { get; }
        string SMTPUser { get; }
        int ThumbImageHeight { get; }
        int ThumbImageWidth { get; }
    }
}
