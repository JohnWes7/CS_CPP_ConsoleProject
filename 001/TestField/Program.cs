using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TestField
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Collections.IList list = new List<int>();

            //test<string> a = new test<string>();

            //Console.ReadKey();

            //Console.WriteLine(IsValid("}"));

            string text1 = "114", text2;
            string password = "1145141919810114";
            byte[] temp;

            temp = AESEncrypt(text1, password);
            for (int i = 0; i < temp.Length; i++)
            {
                Console.Write(temp[i]);
            }
            Console.WriteLine();
            text2 = AESDecrypt(temp, password);
            Console.WriteLine(text2);
        }

        public static byte[] AESEncrypt(string text, string password)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 128;
            rijndaelCipher.BlockSize = 128;
            byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] keyBytes = new byte[16];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length) len = keyBytes.Length;
            System.Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            // byte[] ivBytes = System.Text.Encoding.UTF8.GetBytes(iv);
            rijndaelCipher.IV = new byte[16];
            ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(text);
            byte[] cipherBytes = transform.TransformFinalBlock(plainText, 0, plainText.Length);
            return cipherBytes;
        }
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="text"></param>
        /// <param name="password"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static string AESDecrypt(byte[] text, string password)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 128;
            rijndaelCipher.BlockSize = 128;
            byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] keyBytes = new byte[16];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length) len = keyBytes.Length;
            System.Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            // byte[] ivBytes = System.Text.Encoding.UTF8.GetBytes(iv);
            rijndaelCipher.IV = new byte[16];
            ICryptoTransform transform = rijndaelCipher.CreateDecryptor();
            byte[] plainText = transform.TransformFinalBlock(text, 0, text.Length);
            return Encoding.UTF8.GetString(plainText);
        }


        static void teststr()
        {
            string name = "johnwest";
            test_str_is_class(name);
            Console.WriteLine(name);
        }

        static void test_str_is_class(string name)
        {
            name += "dawdwa";
            Console.WriteLine(name);
        }

        public static bool IsValid(string s)
        {
            Stack<char> sta = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Equals('(') || s[i].Equals('[') || s[i].Equals('{'))
                {
                    sta.Push(s[i]);
                }
                else if (sta.Count > 0)
                {
                    char temp = sta.Pop();
                    if ((s[i] == ')' && temp != '(') || (s[i] == ']' && temp != '[') || s[i] == '}' && temp != '{')
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            if (sta.Count > 0)
            {
                return false;
            }
            return true;
        }
    }

    class test<T>
    {
        T[] array;

        public test()
        {
            array = new T[10];
        }

        public void Add(T value)
        {
            Add((object)value);
        }

        public void Add(object value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T value)
        {
            return false;
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }
    }

    interface myIlist<T>
    {
#nullable enable
        public void Add(object? value);
        public bool Contains(object? value);
#nullable disable
    }
}
