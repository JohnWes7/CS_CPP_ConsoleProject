using System;
using System.Collections.Generic;
using System.Text;

namespace 接口
{
    interface IRegister
    {
        void Register();
    }

    class Car : IRegister
    {
        public void Register()
        {
            Console.WriteLine("车子登记了");
        }
    }

    class House : IRegister
    {
        public void Register()
        {
            Console.WriteLine("房子登记了");
        }
    }
    
}
