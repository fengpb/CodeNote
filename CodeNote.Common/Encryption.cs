using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.IO;
using log4net;
using System.Web.Security;

namespace CodeNote.Common
{
    public class Encryption
    {
        public static ILog log = LogManager.GetLogger(typeof(Exception));

        public static string Base64_Decode(string str)
        {
            if (str == null || str.Length == 0)
            {
                return "";
            }
            byte[] bytes = Convert.FromBase64String(str);
            return Encoding.GetEncoding("GB2312").GetString(bytes);
        }
        public static string Base64_Encode(string str)
        {
            if (str != null && str.Length != 0)
            {
                return Convert.ToBase64String(new ASCIIEncoding().GetBytes(str));
            }
            return "";
        }
        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="md5str">要加密的字符串</param>
        /// <returns></returns>
        public static string MD5(string md5str)
        {
            if (string.IsNullOrEmpty(md5str))
                return string.Empty;
            return FormsAuthentication.HashPasswordForStoringInConfigFile(md5str, "md5").ToLower();
        }

        /// <summary>
        /// 16位MD5加密
        /// </summary>
        /// <param name="ConvertString">要加密的字符串</param>
        /// <returns></returns>
        public static string GetMd5Str(string ConvertString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(ConvertString)), 4, 8).Replace("-", "");
        }

        public static string StrMD5(string md5str, string mkey)
        {
            md5str = md5str + mkey;
            byte[] mydata = Encoding.UTF8.GetBytes(md5str.ToCharArray());
            byte[] myresult = new MD5CryptoServiceProvider().ComputeHash(mydata);
            return Encoding.UTF8.GetString(myresult);
        }
        /// <summary>
        /// 随机码
        /// </summary>
        /// <param name="n">随机码的位数</param>
        /// <returns></returns>
        public static string RandCode(int n)
        {
            char[] ArrChar = new char[] { 
             'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 
             'q', 'r', 's', 'u', 'v', 'w', 'x', 'y', '0', '1', '2', '3', '5', '6', '7', '8', 
             '9'
              };
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < n; i++)
            {
                sb.Append(ArrChar[rnd.Next(0, ArrChar.Length)].ToString());
            }
            return sb.ToString();
        }



        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="pToEncrypt">需要加密字符串</param>
        /// <param name="sKey">密钥</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string pToEncrypt, string sKey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                //把字符串放到byte数组中
                //原来使用的UTF8编码，我改成Unicode编码了，不行
                byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
                //建立加密对象的密钥和偏移量
                //使得输入密码必须输入英文文本
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                ret.ToString();
                return ret.ToString();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message + ex.StackTrace);
            }
            return "";
        }


        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="pToDecrypt">需要解密的字符串</param>
        /// <param name="sKey">密匙</param>
        /// <returns>解密后的字符串</returns>
        public static string Decrypt(string pToDecrypt, string sKey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
                for (int x = 0; x < pToDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }
                //建立加密对象的密钥和偏移量，此值重要，不能修改
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                //建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象
                StringBuilder ret = new StringBuilder();
                return System.Text.Encoding.Default.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                log.Error(ex.Message + ex.StackTrace);
            }
            return "";
        }


    }
}
