#region Header
///-------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Web.Framework.Core.Common.General
///MODULE        :         
///SUB MODULE    :    
///Class         : GeneralFunctions
///AUTHOR        : Asela Chamara      
///CREATED       : 12/08/2015        
///DESCRIPTION   : Purpose is to provide methods to general tasks
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------
#endregion

using FCL.Web.Framework.Core.Common.Contracts;
using System;
using System.ComponentModel.Composition;
using System.Configuration;

namespace FCL.Web.Framework.Core.Common.General
{
    [Export(typeof(IGeneralFunctions))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GeneralFunctions : IGeneralFunctions
    {
        public string GetRandomNumberUsingGUID(int length)
        {
            // Get the GUID
            string guidResult = System.Guid.NewGuid().ToString();

            // Remove the hyphens
            guidResult = guidResult.Replace("-", string.Empty);

            // Return the first length bytes
            return guidResult.Substring(0, length);
        }

        public int GetRandomNumber()
        {
            Random random = new Random();
            return random.Next(10000, 100000);
        }

        /// <summary>
        /// Reads the given configuration value from the app.config. 
        /// If the key does not exists then returns the default value.
        /// </summary>
        /// <param name="key">Configuration key to be read.</param>
        /// <param name="defaultValue">Default value of the key.</param>
        /// <returns></returns>
        public string ReadConfigValue(string key, string defaultValue)
        {
            string configValue;

            try
            {
                configValue = ConfigurationManager.AppSettings[key];
                if (configValue == null)
                    configValue = defaultValue;
            }
            catch// (Exception ex)
            {
                configValue = defaultValue;
            }

            return configValue;
        }

        /// <summary>
        /// Reads the value of the given configuration key.
        /// </summary>
        /// <param name="key">Configuration Key to be read.</param>
        /// <returns></returns>
        public string ReadConfigValue(string key)
        {
            return ReadConfigValue(key, string.Empty);
        }
    }
}
