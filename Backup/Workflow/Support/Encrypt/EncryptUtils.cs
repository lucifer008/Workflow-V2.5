using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Workflow.Support.Encrypt
{
    /// <summary>
    /// 名    称: 
    /// 功能概要: 字符串加解密
    /// 作    者: 付强
    /// 创建时间: 2008-11-4
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public sealed class EncryptUtils
    {
        #region 不可逆加密
        /// <summary>
        /// 采用SHA方式加密
        /// </summary>
        /// <param name="primaryString"></param>
        /// <returns></returns>
        public static string HexSHA(string primaryString)
        {
            return EncryptTemplate(SHA1.Create(), primaryString);
        }
        /// <summary>
        /// 采用MD5方式加密
        /// </summary>
        /// <param name="primaryString"></param>
        /// <returns></returns>
        public static string HexMD5(string primaryString)
        {
            return EncryptTemplate(MD5.Create(), primaryString);
        }

        private static string EncryptTemplate(HashAlgorithm algo, string primaryString)
        {
            byte[] data = algo.ComputeHash(ASCIIEncoding.ASCII.GetBytes(primaryString));

            StringBuilder codes = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                codes.Append(data[i].ToString("x2"));
            }
            return codes.ToString();
        }
        #endregion

        #region 可逆加密
        //可逆加密Key值
        private static byte[] keys ={ 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="encryptString">要加密的字符串</param>
        /// <param name="encryptKey">加密密钥</param>
        /// <returns></returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0,8));
                byte[] rgbIV = keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);

                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch (System.Exception)
            {
                return encryptString;
                
            }
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="decryptString">要解密的字符串</param>
        /// <param name="decryptKey">解密密钥</param>
        /// <returns></returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0,8));
                byte[] rgbIV = keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);

                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());

            }
            catch (System.Exception)
            {
                return decryptString;
            }
        }
        #endregion
    }
}
