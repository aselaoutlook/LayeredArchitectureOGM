using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FCL.Cockerham.Ogsm.Admin.Core.Util
{
    public class FCLSettings : ConfigurationSection
    {
        public static FCLSettings settings  = ConfigurationManager.GetSection("FCLSettings") as FCLSettings;

        public static FCLSettings Settings
        {
            get
            {
                return settings;
            }
        }

        [ConfigurationProperty("Domain")]
        public string Domain
        {
            get { return (string)this["Domain"]; }
            set { this["Domain"] = value; }
        }

    }
}