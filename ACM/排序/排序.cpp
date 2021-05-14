//#include <bits/stdc++.h>
#include <iostream>
#include <string>
#include <vector>
#include <sstream>
#include <iomanip>
using namespace std;

int MAXLen[1000000];

int main()
{
	ios::sync_with_stdio(false);//加快cin cout速度
	vector<string> Line[1001];
	string temp;
	int LastLine = 0;
	while (getline(cin, temp)) 
	{
		stringstream TInput(temp);
		int Top = 0;
		while (TInput >> temp) 
		{
			if (temp.size() > MAXLen[Top])
			{
				MAXLen[Top] = temp.size();
			}
			Line[LastLine].push_back(temp);//存在vector line里面
			Top++;
		}
		LastLine++;
	}
	cout.setf(ios::left);//设置左对齐
	for (int i = 0; i < LastLine; i++) 
	{
		int Len = Line[i].size();
		for (int j = 0; j < Len; j++) 
		{
			cout << setw(MAXLen[j]) << Line[i][j];
			if (j + 1 != Len)
				cout << " ";
		}
		cout << endl;
	}

	// system("pause");
	return 0;
}