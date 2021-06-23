using System;
using System.Collections.Generic;
using System.Collections;

namespace Binarytree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr  = { 63, 55, 90, 42, 58, 70, 10, 45, 67, 83 };
            BinaryTree binaryTree = BinaryTree.ArrayToTree(arr);
            System.Console.WriteLine(binaryTree.Find(67));
        }
    }

    public class BinaryTree
    {
        public int data;
        public BinaryTree leftChild;
        public BinaryTree rightchild;

        public BinaryTree(int data)
        {
            this.data = data;
        }

        public int Find(int target)
        {
            if (this.data == target)
            {
                return this.GetHashCode();
            }
            else if (this.data > target)
            {
                if (this.leftChild == null)
                {
                    return -1;
                }
                return this.leftChild.Find(target);
            }
            else
            {
                if (this.rightchild == null)
                {
                    return -1;
                }
                return this.rightchild.Find(target);
            }
        }

        public static void Insert(ref BinaryTree tree, int data)
        {
            //如果传入是空tree说明到了最底部了就生成一个新的
            if (tree == null)
            {
                tree = new BinaryTree(data);
                return;
            }

            //如果不是空的，则有值，加入到他的子节点上
            if (data <= tree.data)
            {
                Insert(ref tree.leftChild, data);
            }
            else
            {
                Insert(ref tree.rightchild, data);
            }
        }

        public static BinaryTree ArrayToTree(params int[] arr)
        {
            BinaryTree tree = null;

            for (int i = 0; i < arr.Length; i++)
            {
                Insert(ref tree, arr[i]);
            }

            return tree;
        }
    }
}
