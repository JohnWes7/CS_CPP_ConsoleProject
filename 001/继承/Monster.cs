using System;
using System.Collections.Generic;
using System.Text;

namespace 继承
{
    class Monster
    {
        protected string name;
        
        protected Monster(string name)
        {
            this.name = name;
        }

        public void Attack()
        {
            Console.WriteLine("{0}攻击了",name);
        }
    }

    class Boss : Monster
    {


        public Boss(string name) : base(name)
        {

        }

        public void DeadHit()
        {
            Console.WriteLine("{0},发动了致命打击技能",name);
        }
        public void Attack()
        {
            Console.WriteLine("{0},is heavy attacking",name);
        }
        
    }

    class Goblin : Monster
    {
        public Goblin(string name) : base(name)
        {

        }

        public void Attack()
        {
            Console.WriteLine("{0},is attack",name);
        }
    }


}
