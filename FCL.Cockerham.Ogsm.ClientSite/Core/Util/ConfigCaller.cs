#region Header
///-------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Cockerham.Ogsm.Admin.Core.Util
///MODULE        :         
///SUB MODULE    :    
///Class         : ConfigCaller
///AUTHOR        : Asela Chamara      
///CREATED       : 12/08/2015        
///DESCRIPTION   : Purpose is to reduce the Configuration values (in web. config or App. settings) calling methods in each page
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------
#endregion

using FCL.Web.Framework.Core.Common.Contracts;
using System;
using System.ComponentModel.Composition;

namespace FCL.Cockerham.Ogsm.ClientSite.Core.Util
{
    [Export(typeof(IConfigCaller))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ConfigCaller : IConfigCaller
    {
        [Import]
        INullHandler NullHandler { get; set; }

        [Import]
        IGeneralFunctions Utility { get; set; }

        public int MaxCommentLength
        {
            get { return NullHandler.ConvertToInt(Utility.ReadConfigValue("MaxCommentLength", "20")); }
        }
        public int ThumbImageWidth
        {
            get { return NullHandler.ConvertToInt(Utility.ReadConfigValue("ThumbImageWidth", "150")); }
        }
        public int ThumbImageHeight
        {
            get { return NullHandler.ConvertToInt(Utility.ReadConfigValue("ThumbImageHeight", "159")); }
        }
        public string IsStaging
        {
            get { return Utility.ReadConfigValue("IsStaging", "0"); }
        }

        public string ApplicationEnviorment
        {
            get { return Utility.ReadConfigValue("ApplicationEnviorment", "production"); }
        }

        public string PageSize
        {
            get { return Utility.ReadConfigValue("PAGE_SIZE", "10"); }
        }
        public string SMTPServer
        {
            get { return Utility.ReadConfigValue("SMTP_SERVER", "smtp.gmail.com"); }
        }
        public string SMTPPort
        {
            get { return Utility.ReadConfigValue("SMTP_PORT", "587"); }
        }
        public string FromAddress
        {
            get { return Utility.ReadConfigValue("FROM_MAIL", "fclanka.info@gmail.com"); }         
        }
        
        public string SMTPUser
        {
            get { return Utility.ReadConfigValue("SMTP_USER", "fclanka.info@gmail.com"); }
        }
        public string SMTPPass
        {
            get { return Utility.ReadConfigValue("FROM_PASS", "4rfv3edc#"); }
        }
        public bool SMTPSsl
        {
            get { return Convert.ToBoolean(Utility.ReadConfigValue("SMTP_SSL", "True")); }
        }        
        public int LogoMaxHeight
        {
            get { return NullHandler.ConvertToInt(Utility.ReadConfigValue("LOGO_MAX_HEIGHT", "105")); }
        }
        public int LogoMaxWidth
        {
            get { return NullHandler.ConvertToInt(Utility.ReadConfigValue("LOGO_MAX_WIDTH", "300")); }
        }
        public string RedirectPath
        {
            get { return Utility.ReadConfigValue("REDIRECT_PATH", "/Admin"); }
        }
        public string SiteAddress
        {
            get { return Utility.ReadConfigValue("SITE_ADDRESS", "https://www.fclanka.com"); }
        }
        public string SiteName
        {
            get { return Utility.ReadConfigValue("SITE_NAME", "Four Corners Lanka Pte Ltd"); }
        }
        public string CopyEmail
        {
            get { return Utility.ReadConfigValue("COPY_MAIL", "fclanka.info@gmail.com"); }
        }
    }
}