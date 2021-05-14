using System;
using System.Collections.Generic;
using System.Text;

namespace 类
{
    class Ticket
    {
        int distance;
        float price;

        public Ticket(int distance)
        {
            if (distance<0)
            {
                this.distance = 0;
            }
            else
            {
                this.distance = distance;
            }

            GetPrice();
        }

        public float GetPrice()
        {
            if ( this.distance<=100)
            {
                this.price = this.distance;

            }
            else if (this.distance>100&&this.distance<=200)
            {
                price = (float)distance * 0.95f;
            }
            else if (distance>200&&distance<=300)
            {
                price = (float)distance * 0.9f;

            }
            else
            {
                price = (float)distance * 0.8f;
            }

            return price;
        }

        public void TicketInfo()
        {
            Console.WriteLine("这张票的路程为{0}公里，价格为{1}元",distance,price);
        }

    }
}
