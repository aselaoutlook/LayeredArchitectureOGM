using FCL.Cockerham.Ogsm.Admin.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FCL.Cockerham.Ogsm.ClientSite.Core.Util
{
    [Export(typeof(IFCLSetting))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FCLCustomSettings : IFCLSetting
    {
        public string Domain()
        {
            return FCLSettings.Settings.Domain;
        }

    }
}