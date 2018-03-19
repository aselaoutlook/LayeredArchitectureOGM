#region Header
///-------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Web.Framework.Core.Common.Contracts
///MODULE        :         
///SUB MODULE    :    
///Class         : IGeneralFunctions
///AUTHOR        : Asela Chamara      
///CREATED       : 12/08/2015        
///DESCRIPTION   : Purpose is to provide interface to FCL.Web.Framework.Core.Common.General.GeneralFunctions
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------
#endregion

using System;

namespace FCL.Web.Framework.Core.Common.Contracts
{
    public interface IGeneralFunctions
    {
        string GetRandomNumberUsingGUID(int length);
        int GetRandomNumber();
        string ReadConfigValue(string key, string defaultValue);
        string ReadConfigValue(string key);
    }
}
