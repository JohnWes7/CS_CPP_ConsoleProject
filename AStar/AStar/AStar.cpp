#include <iostream>
#include <cstdio>
#include <cstdlib>
#include <string>
#define MAXN 5000               //迷宫的最大大小
#define MAXLength 1000000		//Open表的最大长度
#define INF 0x3f3f3f3f			//定义的无穷大
using namespace std;

/*
Author:徐凌翔
Date:2020-12-29
Topic:迷宫问题
*/

//定义迷宫节点
struct MazeNode
{
	int G, H, F;
	//Visted为0表示为空地，为1表示为墙壁，为2表示已经加入了Open表, 为3表示已经加入Close表
	int Visted, x, y, Fatherx, Fathery;
};

//定义迷宫
struct Maze
{
	MazeNode Map[MAXN][MAXN];
	int m, n, Beginx, Beginy, Endx, Endy;
}M;

//定义栈
struct Stack
{
	MazeNode* Element;
	Stack* Next;
	Stack()
	{
		this->Element = NULL;
		this->Next = NULL;
	}
	//判断栈是否为空
	bool IsEmpty()
	{
		return !this->Next;
	}
	//入栈
	void Push(MazeNode* e)
	{
		Stack* temp = (Stack*)malloc(sizeof(Stack));
		temp->Element = e, temp->Next = this->Next;
		this->Next = temp;
	}
	//出栈
	void Pop()
	{
		Stack* temp = this->Next;
		this->Next = temp->Next;
		free(temp);
	}
	//返回栈顶元素
	MazeNode* Top()
	{
		return this->Next->Element;
	}
};

//Open表(以F为关键值的小根堆)
struct Open
{
	int length;
	MazeNode* Array[MAXLength];
	Open()//初始化Open表
	{
		this->length = 0;
		memset(Array, INF, sizeof(Array));
	}
	//在Open表内发生变动时，进行调整
	void Modify(int Op)
	{
		int Left = Op * 2, Right = Op * 2 + 1;
		if (Left < length && Right < length)
		{
			Left = this->Array[Left]->F < this->Array[Right]->F ? Left : Right;
			if (this->Array[Op]->F > this->Array[Left]->F)
				swap(this->Array[Left], this->Array[Op]);
		}
		else if (Left < length && Right >= length && this->Array[Left]->F < this->Array[Op]->F)
		{
			if (this->Array[Left]->F < this->Array[Op]->F)
				swap(this->Array[Left], this->Array[Op]);
		}
		else if (Left >= length && Right < length && this->Array[Right]->F < this->Array[Op]->F)
		{
			if (this->Array[Right]->F < this->Array[Op]->F)
				swap(this->Array[Right], this->Array[Op]);
		}
		else
			return;
		Modify(Left), Modify(Right);
	}
	void Push(MazeNode* P)//向Open表中添加元素
	{//维护一个小根堆
		this->Array[++length] = P;
		int Op = length;
		while (Op / 2 > 0 && this->Array[Op / 2]->F > this->Array[Op]->F)
			swap(this->Array[Op / 2], this->Array[Op]), Op /= 2;
	}
	bool IsEmpty()//判断Open表是否为空
	{
		return !this->length;
	}
	MazeNode* Top()//返回Open表的首元素
	{
		return this->Array[1];
	}
	void Pop()//弹出Open表中的队首元素
	{
		swap(this->Array[1], this->Array[length]);
		length--;
		int Op = 1;
		while (1)
		{
			int Left = Op * 2, Right = Op * 2 + 1;
			if (Left < length && Right < length)
			{
				Left = this->Array[Left]->F < this->Array[Right]->F ? Left : Right;
				swap(this->Array[Left], this->Array[Op]);
				Op = Left;
			}
			else if (Left < length && Right >= length && this->Array[Left]->F < this->Array[Op]->F)
			{
				swap(this->Array[Left], this->Array[Op]);
				Op = Left;
			}
			else if (Left >= length && Right < length && this->Array[Right]->F < this->Array[Op]->F)
			{
				swap(this->Array[Right], this->Array[Op]);
				Op = Right;
			}
			else
				break;
		}
	}
};

//定义探查的方式
//0:向上, 1:向下, 2:向左, 3:向右
const int Walk[][2] = { {-1, 0}, {1, 0}, {0, -1}, {0, 1} };

//初始化地图
void initMap()
{
	cout << "请输入迷宫的大小" << endl;
	cin >> M.m >> M.n;
	cout << "迷宫的大小为" << M.m << "*" << M.n << endl;
	cout << "请输入迷宫的构造，1为墙壁，0为空地" << endl;
	for (int i = 1; i <= M.m; i++)
		for (int j = 1; j <= M.n; j++)
		{
			cin >> M.Map[i][j].Visted;
			M.Map[i][j].F = M.Map[i][j].G = M.Map[i][j].H = INF;
			M.Map[i][j].Fatherx = M.Map[i][j].x = i;
			M.Map[i][j].Fathery = M.Map[i][j].y = j;
		}
	system("cls");
	cout << "您输入的迷宫展示如下" << endl;
	for (int i = 1; i <= M.m; i++)
	{
		for (int j = 1; j <= M.n; j++)
			cout << (M.Map[i][j].Visted ? "■" : "□");
		cout << endl;
	}
	system("pause");
}

//设定迷宫的起点与终点
void SetBeginAndEnd()
{
	int x, y;
	system("cls");
	cout << "请输入迷宫的起点" << endl;
	do
	{
		cin >> x >> y;
		if (M.Map[x][y].Visted || x > M.m || y > M.n || x <= 0 || y <= 0)
			cout << "起点为不可到达的区域，请重新输入" << endl;
		else
			M.Beginx = x, M.Beginy = y;
	} while (M.Map[x][y].Visted || x > M.m || y > M.n || x <= 0 || y <= 0);
	cout << "请输入迷宫的终点" << endl;
	do
	{
		cin >> x >> y;
		if (M.Map[x][y].Visted || x > M.m || y > M.n || x <= 0 || y <= 0)
			cout << "终点为不可到达的区域，请重新输入" << endl;
		else
			M.Endx = x, M.Endy = y;
	} while (M.Map[x][y].Visted || x > M.m || y > M.n || x <= 0 || y <= 0);
	cout << "设置结束，设置的起点为(" << M.Beginx << ',' << M.Beginy << ')' << endl;
	cout << "设置的终点为" << '(' << M.Endx << ',' << M.Endy << ')' << endl;
	M.Map[M.Beginx][M.Beginy].Visted = 1;
}

//获得A*算法中所需要的H值
int GetH(int x, int y)
{
	return abs(x - M.Endx) + abs(y - M.Endy);
}

//A*算法
void Astar()
{
	Open* op = new Open();
	M.Map[M.Beginx][M.Beginy].F = M.Map[M.Beginx][M.Beginy].G = M.Map[M.Beginx][M.Beginy].H = 0;
	M.Map[M.Beginx][M.Beginy].Visted = 2;											//加入Open表
	op->Push(&M.Map[M.Beginx][M.Beginy]);

	//核心步骤
	while (!op->IsEmpty() && M.Map[M.Endx][M.Endy].Visted != 3)
	{
		MazeNode* top = op->Top(); op->Pop();
		int curx, cury;
		M.Map[top->x][top->y].Visted = 3;												//加入关闭列表
		for (int i = 0; i < 4; i++)														//将周围的四格加入开启列表
		{
			curx = top->x + Walk[i][0], cury = top->y + Walk[i][1];
			if (curx <= 0 || curx > M.m || cury <= 0 || cury > M.n)
				continue;
			if (M.Map[curx][cury].Visted == 0)												//如果是没有访问过的地方
			{
				M.Map[curx][cury].G = M.Map[top->x][top->y].G + 10;						//修改G值
				M.Map[curx][cury].H = GetH(curx, cury) * 10;							//修改H值
				M.Map[curx][cury].F = M.Map[curx][cury].G + M.Map[curx][cury].H;		//修改F值
				M.Map[curx][cury].Fatherx = top->x, M.Map[curx][cury].Fathery = top->y;	//记录父节点
				M.Map[curx][cury].Visted = 2;											//表明已经加入了Open表
				op->Push(&M.Map[curx][cury]);											//将该节点加入Open表中
			}
			else if (M.Map[curx][cury].Visted == 2)
			{
				if (M.Map[top->x][top->y].G + 10 <= M.Map[curx][cury].G)
				{
					M.Map[curx][cury].G = M.Map[top->x][top->y].G + 10;
					M.Map[curx][cury].F = M.Map[curx][cury].G + M.Map[curx][cury].H;
					M.Map[curx][cury].Fatherx = top->x, M.Map[curx][cury].Fathery = top->y;
					op->Modify(1);
				}
			}
		}
	}

	//输出结果
	if (op->IsEmpty() && M.Map[M.Endx][M.Endy].Visted != 3)
		cout << "目标地点不可达" << endl;
	else//保存路径只需要从目标格开始沿着每一格的父节点返回到起始格就得到了路径
	{
		printf("从(%d,%d)到(%d,%d)的路径如下:\n", M.Beginx, M.Beginy, M.Endx, M.Endy);
		printf("0:向上, 1:向下, 2:向左, 3:向右\n");
		for (int i = 1; i <= M.m; i++)
		{
			for (int j = 1; j <= M.n; j++)
				cout << (M.Map[i][j].Visted == 1 ? "■" : "□");
			cout << endl;
		}
		Stack* s = new Stack();
		int curx = M.Endx, cury = M.Endy;
		do
		{
			s->Push(&M.Map[curx][cury]);
			int tempx = M.Map[curx][cury].Fatherx, tempy = M.Map[curx][cury].Fathery;
			curx = tempx, cury = tempy;
		} while (!(curx == M.Beginx && cury == M.Beginy));
		s->Push(&M.Map[M.Beginx][M.Beginy]);
		while (!s->IsEmpty())
		{
			int tempx = s->Top()->x, tempy = s->Top()->y;
			s->Pop();
			printf("(%d,%d,", tempx, tempy);

			if (!s->IsEmpty())
			{
				for (int i = 0; i < 4; i++)
					if (tempx + Walk[i][0] == s->Top()->x && tempy + Walk[i][1] == s->Top()->y)
					{
						printf("%d)", i);
						break;
					}
				printf("->");
			}
			else
				printf(")");
			printf("\n");
		}
	}
}

int main()
{
	string OutSignal;
	char temp;
	do
	{
		system("cls");
		initMap();
		SetBeginAndEnd();

		Astar();

		system("pause");
		system("cls");
		cout << "输入exit以退出程序，任意其他字符以继续" << endl;
		while (temp = getchar(), temp != '\n');
		getline(cin, OutSignal);
	} while (OutSignal != "exit");
	return 0;
}
