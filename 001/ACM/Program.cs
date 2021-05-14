using System;

namespace ACM
{
    class Program
    {
        static void Main(string[] args)
        {


            //https://vjudge.net/problem/Gym-257485D
            //一天，在宿舍睡觉的你，突然梦到了游戏之神，他说：去玩《极限脱出》吧，这部作品的剧情和世界观绝对会带来很大的震撼，值得一玩。

            //对了，这部作品的第一代发布在nds上，所以要想在电脑上玩，你需要游戏模拟器：推荐desmume，也可以选择nogba，前者虽然优化差一些，但自带了模拟器的即使存档功能，且可以全屏。

            //............但由于你没有吃安利，游戏之神很愤怒（这么好的游戏不玩，暴殄天物啊！），决定对你进行惩罚。

            //现在，游戏之神给了你n个非负整数，分别记为第1个数字至第n个数字，游戏之神还会向你提出q个问题，询问你第f个数到第t个数之间所有数字的和，请你正确回答游戏之神的所有提问，否则你以后打游戏必掉线。

            // 输入的第一行包含两个整数n,q(1≤n, q≤105)，含义如题面所示；

            //第二行包含n个非负整数，每个数字均不超过109；

            //下面q行，每行包括两个数字f,t（1≤f≤t≤n），含义如题面所示。

            //对于这q行中的每一行，请你输出一个数字，回答游戏之神的提问。

            //input
            //9 4
            //1 3 4 6 2 5 1000000000 1000000000 1000000000
            //1 6
            //7 9
            //3 5
            //4 4

            // Output
            //21
            //3000000000
            //12
            //6

            string[] numQuestion = Console.ReadLine().Split(' ');
            string[] number = Console.ReadLine().Split(' ');
            long[] sum = new long[long.Parse(numQuestion[0])];

            //预处理得到和
            sum[0] = long.Parse(number[0]);
            for (int i = 1; i < int.Parse(numQuestion[0]); i++)
            {
                sum[i] = sum[i - 1] + long.Parse(number[i]);
            }

            //处理问题
            for (int i = 0; i < int.Parse(numQuestion[1]); i++)
            {
                string[] quest = Console.ReadLine().Split(' ');
                if (int.Parse(quest[0]) == 1)
                {
                    Console.WriteLine(sum[int.Parse(quest[1]) - 1]);
                }
                else
                {
                    Console.WriteLine(sum[int.Parse(quest[1]) - 1] - sum[int.Parse(quest[0]) - 2]);

                }
            }


        }
    }
}
