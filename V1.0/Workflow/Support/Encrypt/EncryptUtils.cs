using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Workflow.Support.Encrypt
{
    /// <summary>
    /// ��    ��: 
    /// ���ܸ�Ҫ: �ַ����ӽ���
    /// ��    ��: ��ǿ
    /// ����ʱ��: 2008-11-4
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    public sealed class EncryptUtils
    {
        #region ���������
        /// <summary>
        /// ����SHA��ʽ����
        /// </summary>
        /// <param name="primaryString"></param>
        /// <returns></returns>
        public static string HexSHA(string primaryString)
        {
            return EncryptTemplate(SHA1.Create(), primaryString);
        }
        /// <summary>
        /// ����MD5��ʽ����
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

        #region �������
        //�������Keyֵ
        private static byte[] keys ={ 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        /// <summary>
        /// DES����
        /// </summary>
        /// <param name="encryptString">Ҫ���ܵ��ַ���</param>
        /// <param name="encryptKey">������Կ</param>
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
        /// DES����
        /// </summary>
        /// <param name="decryptString">Ҫ���ܵ��ַ���</param>
        /// <param name="decryptKey">������Կ</param>
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
