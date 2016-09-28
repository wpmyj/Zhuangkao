using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Share.Module.Login
{
      public class MD5
        {
            // ��ʽ��md5 hash �ֽ��������õĸ�ʽ����λСд16�������֣�   
            private static readonly string m_strHexFormat = "x2";

            /// <summary>   
            /// ʹ�õ�ǰȱʡ���ַ�������ַ������м���   
            /// </summary>   
            /// <param name="str">��Ҫ����md5������ַ���</param>   
            /// <returns>��Сд��ĸ��ʾ��32λ16���������ַ���</returns>   
            public static string md5(string str)
            {
                return (string)md5(str, false, Encoding.Default);
            }
            /// <summary>   
            /// ���ַ�������md5 hash����   
            /// </summary>   
            /// <param name="str">��Ҫ����md5������ַ���</param>   
            /// <param name="raw_output">   
            /// false�򷵻ؾ�����ʽ���ļ����ַ���(��ͬ�� string md5(string) )   
            /// true�򷵻�ԭʼ��md5 hash ����16 �� byte[] ����   
            /// </param>   
            /// <returns>   
            /// byte[] ������߾�����ʽ���� string �ַ���   
            /// </returns>   
            public static object md5(string str, bool raw_output)
            {
                return md5(str, raw_output, Encoding.Default);
            }
            /// <summary>   
            /// ���ַ�������md5 hash����   
            /// </summary>   
            /// <param name="str">��Ҫ����md5������ַ���</param>   
            /// <param name="raw_output">   
            /// false�򷵻ؾ�����ʽ���ļ����ַ���(��ͬ�� string md5(string) )   
            /// true�򷵻�ԭʼ��md5 hash ����16 �� byte[] ����   
            /// </param>   
            /// <param name="charEncoder">   
            /// ����ָ���������ַ������б����� Encoding ���ͣ�   
            /// �������ַ����а������ֽ����֣��������ģ���ʱ��   
            /// ���뱣֤����ƥ��� md5 hash ��ʹ�õ��ַ�������ͬ��   
            /// ������������ md5 ����ƥ�䡣   
            /// </param>   
            /// <returns>   
            /// byte[] ������߾�����ʽ���� string �ַ���   
            /// </returns>   
            public static object md5(string str, bool raw_output,
                                                        Encoding charEncoder)
            {
                if (!raw_output)
                    return md5str(str, charEncoder);
                else
                    return md5raw(str, charEncoder);
            }

            /// <summary>   
            /// ʹ�õ�ǰȱʡ���ַ�������ַ������м���   
            /// </summary>   
            /// <param name="str">��Ҫ����md5������ַ���</param>   
            /// <returns>��Сд��ĸ��ʾ��32λ16���������ַ���</returns>   
            protected static string md5str(string str)
            {
                return md5str(str, Encoding.Default);
            }
            /// <summary>   
            /// ���ַ�������md5����   
            /// </summary>   
            /// <param name="str">��Ҫ����md5������ַ���</param>   
            /// <param name="charEncoder">   
            /// ָ���������ַ������б����� Encoding ����   
            /// </param>   
            /// <returns>��Сд��ĸ��ʾ��32λ16���������ַ���</returns>   
            protected static string md5str(string str, Encoding charEncoder)
            {
                byte[] bytesOfStr = md5raw(str, charEncoder);
                int bLen = bytesOfStr.Length;
                StringBuilder pwdBuilder = new StringBuilder(32);
                for (int i = 0; i < bLen; i++)
                {
                    pwdBuilder.Append(bytesOfStr[i].ToString(m_strHexFormat));
                }
                return pwdBuilder.ToString();
            }
            /// <summary>   
            /// ʹ�õ�ǰȱʡ���ַ�������ַ������м���   
            /// </summary>   
            /// <param name="str">��Ҫ����md5������ַ���</param>   
            /// <returns>����16 �� byte[] ����</returns>   
            protected static byte[] md5raw(string str)
            {
                return md5raw(str, Encoding.Default);
            }
            /// <summary>   
            /// ���ַ�������md5����   
            /// </summary>   
            /// <param name="str">��Ҫ����md5������ַ���</param>   
            /// <param name="charEncoder">   
            /// ָ���������ַ������б����� Encoding ����   
            /// </param>   
            /// <returns>����16 �� byte[] ����</returns>   
            protected static byte[] md5raw(string str, Encoding charEncoder)
            {
                System.Security.Cryptography.MD5 md5 =
                    System.Security.Cryptography.MD5.Create();
                return md5.ComputeHash(charEncoder.GetBytes(str));
            }
        }   

}
