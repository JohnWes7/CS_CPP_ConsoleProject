using System;
using System.Collections.Generic;
using System.Text;

namespace 虚方法
{
    class Monster
    {
        protected string name;

        protected Monster(string name)
        {
            this.name = name;
        }

        public virtual void Attack()//在父类要重写的方法前加上virtual关键字
        {
            Console.WriteLine("{0}攻击了(父类)", name);
        }
    }

    class Boss : Monster
    {


        public Boss(string name) : base(name)
        {

        }

        public void DeadHit()
        {
            Console.WriteLine("{0},发动了致命打击技能", name);
        }
        public override void Attack()//子通过override关键字去重写attack方法
        {
            Console.WriteLine("This is {0} attack", name);
        }

    }

    class Goblin : Monster
    {
        public Goblin(string name) : base(name)
        {

        }

        public override void Attack()
        {
            Console.WriteLine("This is {0} Attack", name);
        }
    }

    class FireGoblin : Goblin
    {
        public FireGoblin(string name) : base(name)
        {

        }

        public override void Attack()
        {
            base.Attack();
        }
    }
}
