using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstLookatBinaryTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> myFirstBinaryTree = new BinaryTree<int>();

            myFirstBinaryTree.Add(5);
            myFirstBinaryTree.Add(6);
            myFirstBinaryTree.Add(8);
            myFirstBinaryTree.Add(10);
            myFirstBinaryTree.Add(2);
            myFirstBinaryTree.Add(3);
            myFirstBinaryTree.Add(4);
            myFirstBinaryTree.Add(4);
            myFirstBinaryTree.Add(5);
        }
    }
}
