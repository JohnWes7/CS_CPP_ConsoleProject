using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

//=================================================
//        created by JohnWes7
//        https://github.com/JohnWes7
//=================================================

namespace txt_reader
{
    class Tool
    {
        /// <summary>
        /// 流写入
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="str">写入的字符串</param>
        /// <param name="encoding">编码格式</param>
        public static bool write(Stream stream, string str, Encoding encoding)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(stream, encoding))
                {
                    streamWriter.Write(str);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        public static bool write(string path, string str, Encoding encoding)
        {
            FileStream fileStream;
            try
            {
                fileStream = File.OpenWrite(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return write(fileStream, str, Encoding.UTF8);
        }

        /// <summary>
        /// 流读取
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static bool reader(Stream stream, out string str, Encoding encoding)
        {
            str = null;
            try
            {
                using (StreamReader streamReader = new StreamReader(stream, encoding))
                {
                    str = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }
    }
    

}
