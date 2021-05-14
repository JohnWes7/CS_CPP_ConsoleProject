using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace W4数据结构
{
    class MonsterManager
    {
        private static MonsterManager monstermanager;
        public Monster[] monsters;
        public ArrayList ArrayList;
        public List<Monster> monsterList;

        public static MonsterManager Monstermanager
        {
            get
            {
                if (monstermanager == null)
                {
                    monstermanager = new MonsterManager();

                }
                return monstermanager;
            }
            //set => monstermanager = value;
        }

        private MonsterManager()
        {
            monsters = new Monster[1];
            ArrayList = new ArrayList();
            monsterList = new List<Monster>();
        }

        public void Add(Monster monster)
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                if (monsters[i] == null)
                {
                    monsters[i] = monster;
                    return;
                }
            }

            Monster[] temp = new Monster[monsters.Length + 1];
            for (int i = 0; i < monsters.Length; i++)
            {
                temp[i] = monsters[i];
            }
            temp[monsters.Length] = monster;
            monsters = temp;
            return;
        }
        public void AllAttack()
        {
            for (int i = 0; i < monsterList.Count; i++)
            {
                monsterList[i].Attack();
            }
        }
        public void MonsterSort()
        {
            for (int i = 1; i < monsterList.Count; i++)
            {
                for (int j = 0; j < monsterList.Count - i; j++)
                {
                    if (monsterList[j].atk > monsterList[j + 1].atk)
                    {
                        Monster temp = monsterList[j];
                        monsterList[j] = monsterList[j + 1];
                        monsterList[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < monsterList.Count; i++)
            {
                Console.WriteLine(monsterList[i]);
            }
        }

    }

    class Monster : IComparer<Monster>, IComparable<Monster>
    {
        protected string name;
        public int atk;
        public int def;
        public int hp;

        public Monster(string name, int atk, int def, int hp)
        {
            this.name = name;
            this.atk = atk;
            this.def = def;
            this.hp = hp;
            MonsterManager.Monstermanager.monsterList.Add(this);
        }


        public virtual void Attack()
        {
            Console.WriteLine("{0}正在攻击", name);
        }

        public int Compare([AllowNull] Monster x, [AllowNull] Monster y)
        {
            return x.atk - y.atk;
        }
        public int CompareTo([AllowNull] Monster other)
        {
            return this.atk - other.atk;
        }
    }
    class MonsterDefSort : IComparer<Monster>
    {
        public static MonsterDefSort instance = new MonsterDefSort();
        public int Compare([AllowNull] Monster x, [AllowNull] Monster y)
        {
            return x.def - y.def;
        }

    }
    class MonsterHpSort : IComparer<Monster>
    {
        public static MonsterHpSort instance = new MonsterHpSort();
        public int Compare([AllowNull] Monster x, [AllowNull] Monster y)
        {
            return x.hp - y.hp;
        }
    }



    class Goblin : Monster
    {
        public Goblin(string name, int atk, int def, int hp) : base(name, atk, def, hp)
        {
        }

        public override void Attack()
        {
            Console.WriteLine("{0}（哥布林）发出了{1}伤害的攻击", name, atk);
        }
        public override string ToString()
        {
            return name + "Goblin：" + this.atk+"  "+def+"  "+hp ;
        }
    }
    class Boss : Monster
    {
        public Boss(string name, int atk, int def, int hp) : base(name, atk, def, hp)
        {
        }

        public override void Attack()
        {
            Console.WriteLine("{0}（Boss）发出了{1}伤害的致命一击", name, atk);
        }
        public override string ToString()
        {
            return name + "Boss：" + this.atk + "  " + def + "  " + hp;
        }
    }
}
