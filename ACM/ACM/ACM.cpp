#include<iostream>
#include<string>
#include<algorithm>
using namespace std;

struct Player {
	string Name;
	int Rank;
	bool operator<(Player p)const 
	{
		return Name < p.Name;
	}
}P[500010];

int main()
{
	int N, M, t;
	char temp[30];
	string s;
	while (~scanf("%d%d", &N, &M)) 
	{
		for (int i = 0; i < N; i++) 
		{
			scanf("%s%d", temp, t);
			P[i].Name = temp;
			P[i].Rank = t;
		}
		sort(P, P + N);
		for (int i = 0; i < N; i++) 
		{
			scanf("%s", temp);
			s = temp;
			// 二分查找
		}
	}
	return 0;
}