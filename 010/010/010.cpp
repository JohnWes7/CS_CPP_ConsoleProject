// 010.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
#include <string>

using namespace std;
#define MAXN 1000010

int person[5010];

int UnionSearch(int a)
{
	int son = a;
	int tmp;

	while (a != person[a])
	{
		 a= person[a];
	}
	while (son != a)
	{
		tmp = person[son];
		person[son] = a;
		son = tmp;
	}
	return a;

}
inline int read() 
{
    register int ans = 0;
    register char c;
    while (c = getchar(), c < '0' || c > '9');
    do {
        ans = (ans << 3) + (ans << 1) + (c ^ '0');
    } while (c = getchar(), '0' <= c && c <= '9');
    return ans;
}

int num[MAXN], LOG[MAXN] = { -1 }, F[MAXN][17];

inline void init(int n) 
{
    for (int i = 1; i <= n; i++) {
        F[i][0] = num[i];
        LOG[i] = LOG[i >> 1] + 1;
    }
}

int main() 
{
    int n, m, x, y;
    n = read(), m = read();
    for (int i = 1; i <= n; i++)
        num[i] = read();
    init(n);
    for (int j = 1; j <= 17; j++)
        for (int i = 1; i + (1 << j) - 1 <= n; i++)
            F[i][j] = max(F[i][j - 1], F[i + (1 << (j - 1))][j - 1]);
    for (int i = 0; i < m; i++) 
    {
        x = read(), y = read();
        int k = LOG[y - x + 1];
        printf("%d\n", max(F[x][k], F[y - (1 << k) + 1][k]));
    }
    return 0;
}


#pragma region 二分
//int main()
//{
//	int personNum;
//	int friendNum;
//	int qNum;
//	cin >> personNum >> friendNum >> qNum;
//	for (size_t i = 0; i <= personNum; i++)
//	{
//		person[i] = i;
//	}
//	for (size_t i = 0; i < friendNum; i++)
//	{
//		int a, b;
//		cin >> a >> b;
//		int bossA = UnionSearch(a);
//		int bossB = UnionSearch(b);
//		if (bossA!=bossB)
//		{
//			person[bossA] = bossB;
//		}
//
//	}
//	for (size_t i = 0; i < qNum; i++)
//	{
//		int a, b;
//		cin >> a >> b;
//		int bossA = UnionSearch(a);
//		int bossB = UnionSearch(b);
//		if (bossA == bossB)
//		{
//			cout << "Yes"<<endl;
//		}
//		else
//		{
//			cout << "No"<<endl;
//		}
//	}
//
//}  
#pragma endregion


#pragma region 题一
//int main()
//{
//	float input;
//	char* ch;
//	cin >> input;
//	ch = (char*)&input;
//
//	for (size_t i = 0; i < 4; i++)
//	{
//		string ans = "";
//		char temp = ch[i];
//
//		for (size_t i = 0; i < 8; i++)
//		{
//			ans.push_back((temp & 1) + '0');
//			temp = temp >> 1;
//		}
//		reverse(ans.begin(), ans.end());
//		if (i)
//		{
//			cout << " " << ans;
//		}
//		else
//		{
//			cout << ans;
//		}
//
//	}
//}
#pragma endregion


// 运行程序: Ctrl + F5 或调试 >“开始执行(不调试)”菜单
// 调试程序: F5 或调试 >“开始调试”菜单

// 入门使用技巧: 
//   1. 使用解决方案资源管理器窗口添加/管理文件
//   2. 使用团队资源管理器窗口连接到源代码管理
//   3. 使用输出窗口查看生成输出和其他消息
//   4. 使用错误列表窗口查看错误
//   5. 转到“项目”>“添加新项”以创建新的代码文件，或转到“项目”>“添加现有项”以将现有代码文件添加到项目
//   6. 将来，若要再次打开此项目，请转到“文件”>“打开”>“项目”并选择 .sln 文件
