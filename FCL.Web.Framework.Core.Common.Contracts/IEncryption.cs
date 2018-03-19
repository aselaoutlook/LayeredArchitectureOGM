#region Header
///-------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Web.Framework.Core.Common.Contracts
///MODULE        :         
///SUB MODULE    :    
///Class         : IEncryption
///AUTHOR        : Asela Chamara      
///CREATED       : 12/08/2015        
///DESCRIPTION   : Purpose is to provide interface FCL.Web.Framework.Core.Common.Encryption.Encryption
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------
#endregion

namespace FCL.Web.Framework.Core.Common.Contracts
{
    public interface IEncryption
    {
        string DoEncrypt(string sValue);
        string DoDecrypt(string sValue);
        string Decrypt(string sValue, string sEncryptionKey);
        string DoEncrypt(string sValue, string sEncryptionKey);
    }
}
