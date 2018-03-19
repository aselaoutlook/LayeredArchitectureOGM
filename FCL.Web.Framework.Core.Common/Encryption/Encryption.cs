#region Header
///-------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Web.Framework.Core.Common.Encryption
///MODULE        :         
///SUB MODULE    :    
///Class         : Encryption
///AUTHOR        : Asela Chamara      
///CREATED       : 12/08/2015        
///DESCRIPTION   : Purpose is to provide methods to encrypt and decrypt sensitive data
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------
#endregion

using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FCL.Web.Framework.Core.Common.Encryption
{
    [Export(typeof(IEncryption))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class Encryption : IEncryption
    {
        private Byte[] KEY_64 = { 1, 2, 3, 4, 5, 6, 7, 8 };
        private Byte[] IV_64 = { 8, 7, 6, 5, 4, 3, 2, 1 };

        private Byte[] key = { };
        private Byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
        private Byte[] inputByteArray; //Convert.ToByte(stringToEncrypt.Length)

        private ILogger _logger = new Logger.Logger();

        /// <summary>
        /// This constructor will create a new instance of the Encryption class
        /// </summary>
        public Encryption()
        {
        }



        /// <summary>
        /// This method will encrypt a string value
        /// </summary>
        /// <param name="value">The string value to encrypt</param>
        /// <returns>Returns DES encrypted string</returns>
        public string DoEncrypt(string sValue)
        {
            try
            {
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_64, IV_64), CryptoStreamMode.Write);
                StreamWriter sw = new StreamWriter(cs);

                sw.Write(sValue);
                sw.Flush();
                cs.FlushFinalBlock();
                ms.Flush();

                // convert back to a string
                return Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
            }
            catch (NullReferenceException e)
            {
                // log the error
                _logger.Error("A null reference error occurred while Encrypting value.", e);
            }
            catch (System.Exception e)
            {
                // log the error
                _logger.Error("An error occurred while Encrypting value.", e);
            }

            return string.Empty;
        }

        /// <summary>
        /// This method will encrypt a string value
        /// </summary>
        /// <param name="sValue">The string value to encrypt</param>
        /// <param name="sEncryptionKey">The string key to encrypt for more secure code</param>
        /// <returns></returns>
        public string DoEncrypt(string sValue, string sEncryptionKey)
        {
            try
            {
                key = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Encoding.UTF8.GetBytes(sValue);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (NullReferenceException e)
            {
                // log the error
                _logger.Error("A null reference error occurred while Encrypting value.", e);
            }
            catch (System.Exception e)
            {
                // log the error
                _logger.Error("An error occurred while Encrypting value.", e);
            }
            return string.Empty;
        }

        /// <summary>
        /// This method will decrypt a DES encrypted string value
        /// </summary>
        /// <param name="strValue">The encrypted string value to decrypt</param>
        /// <returns>Returns DES decrypted string</returns>
        public string DoDecrypt(string sValue)
        {
            try
            {
                sValue = sValue.Replace(' ', '+');
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                Byte[] buffer = Convert.FromBase64String(sValue);
                MemoryStream ms = new MemoryStream(buffer);
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_64, IV_64), CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cs);

                return sr.ReadToEnd();
            }
            catch (NullReferenceException e)
            {
                // log the error
                _logger.Error("A null reference error occurred while Decrypting value.", e);
            }
            catch (System.Exception e)
            {
                // log the error
                _logger.Error("An error occurred while Decrypting value.", e);
            }

            return string.Empty;
        }

        /// <summary>
        /// This method will decrypt a DES encrypted string value
        /// </summary>
        /// <param name="sValue">The encrypted string value to decrypt</param>
        /// <param name="sEncryptionKey">The key used to encrypt the original string</param>
        /// <returns></returns>
        public string Decrypt(string sValue, string sEncryptionKey)
        {
            try
            {
                key = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(sValue);

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                Encoding encoding = Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (NullReferenceException e)
            {
                // log the error
                _logger.Error("A null reference error occurred while Decrypting value.", e);
            }
            catch (System.Exception e)
            {
                // log the error
                _logger.Error("An error occurred while Decrypting value.", e);
            }

            return string.Empty;
        }
    }
}
