using System;
using System.Collections.Generic;
using System.Text;

namespace 接口
{
    interface IUSB
    {
        bool IsConnect
        {
            get;
            set;
        }
        void Connect(Computer computer);
        void ReadData();

    }

    class Computer
    {
        string name;

        public IUSB[] USBs;
        public Computer()
        {
            name = "电脑";
            USBs = new IUSB[3];
        }

        public bool InsertUSB(IUSB usb)
        {
            for (int i = 0; i < USBs.Length; i++)
            {
                if (USBs[i] == null)
                {
                    USBs[i] = usb;
                    Console.WriteLine("连接完成");
                    return true;
                }
            }

            Console.WriteLine("usb接口被占满了，连接失败");
            return false;
        }
    }

    class HardDisk : IUSB
    {
        string name;
        bool isConnect;

        public bool IsConnect { get => isConnect; set => isConnect = value; }

        public HardDisk()
        {
            name = "硬盘";
            IsConnect = false;
        }

        public void Connect(Computer computer)
        {
            if (IsConnect == true)
            {
                Console.WriteLine("已经连接好了");
            }
            else
            {
                Console.WriteLine("{0}正在尝试连接到设备", name);
                IsConnect = computer.InsertUSB(this);

            }
        }

        public void ReadData()
        {
            if (IsConnect == true)
            {
                Console.WriteLine("读到数据了");
            }
            else
            {
                Console.WriteLine("没有连接设备");
            }
        }
    }
    class USB_Drive : IUSB
    {
        string name;
        bool isConnect;
        public bool IsConnect { get => isConnect; set => isConnect = value; }

        public USB_Drive()
        {
            name = "U盘";
            IsConnect = false;
        }
        public void Connect(Computer computer)
        {
            if (IsConnect == true)
            {
                Console.WriteLine("已经连接好了");
            }
            else
            {
                Console.WriteLine("{0}正在尝试连接到设备", name);
                IsConnect = computer.InsertUSB(this);

            }
        }

        public void ReadData()
        {
            if (IsConnect == true)
            {
                Console.WriteLine("读到数据了");
            }
            else
            {
                Console.WriteLine("没有连接设备");
            }
        }
    }
    class MP3 : IUSB
    {
        string name;
        bool isConnect;

        public MP3()
        {
            name = "MP3";
            IsConnect = false;
        }
        public bool IsConnect { get => isConnect; set => isConnect = value; }

        public void Connect(Computer computer)
        {
            if (IsConnect == true)
            {
                Console.WriteLine("已经连接好了");
            }
            else
            {

                Console.WriteLine("{0}正在尝试连接到设备", name);
                IsConnect = computer.InsertUSB(this);

            }
        }

        public void ReadData()
        {
            if (IsConnect == true)
            {
                Console.WriteLine("读到数据了");
            }
            else
            {
                Console.WriteLine("没有连接设备");
            }
        }
    }

}
