using System;
using System.Collections.Generic;
using System.Text;


//=================================================
//        created by JohnWes7 at 2021/9/26 10:38:13
//        https://github.com/JohnWes7
//=================================================

namespace txt_reader
{
    class TXTData
    {
        private static TXTData instance;
        public static Encoding CurrentEncoding { get => Instance.currentEncoding; set => Instance.currentEncoding = value; }
        public static string[] DropItem { get => Instance.dropItem; }

        private Encoding currentEncoding = Encoding.UTF8;
        private string[] dropItem;

        public static TXTData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TXTData();
                }

                return instance;
            }
        }

        public TXTData()
        {
            List<string> list = new List<string>();
            EncodingInfo[] encodingInfos = Encoding.GetEncodings();
            for (int i = 0; i < encodingInfos.Length; i++)
            {
                list.Add(encodingInfos[i].Name);
            }

            dropItem = list.ToArray(); 
        }

        public void ChangeEncoding(string str)
        {
            instance.currentEncoding = string2Encoding(str);
        }
        private Encoding int2Encoding(int index)
        {
            return Encoding.GetEncoding(dropItem[index]);
        }
        private Encoding string2Encoding(string str)
        {
            return Encoding.GetEncoding(str);
        }
    }
}

//when run on .NET Core:
//Info.CodePage      Info.Name                      Info.DisplayName
//1200               utf-16                         Unicode
//1201               utf-16BE                       Unicode (Big-Endian)
//12000              utf-32                       Unicode(UTF - 32)
//12001              utf-32BE                     Unicode(UTF-32 Big-Endian)
//20127              us-ascii                     US - ASCII
//28591              iso-8859 - 1                 Western European(ISO)
//65000              utf-7                        Unicode(UTF - 7)
//65001              utf-8                        Unicode(UTF - 8)  