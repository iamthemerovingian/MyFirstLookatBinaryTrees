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
            myFirstBinaryTree.Add(9);
            myFirstBinaryTree.Add(7);

            Console.WriteLine(myFirstBinaryTree.ContainsWithMatched(10));
            Console.WriteLine(myFirstBinaryTree.ContainsWithMatched(11));
            Console.WriteLine(myFirstBinaryTree.ContainsWithMatched(5));
            Console.WriteLine(myFirstBinaryTree.ContainsWithMatched(8));
            Console.WriteLine(myFirstBinaryTree.ContainsWithMatched(135));

            //myFirstBinaryTree.RemoveWithMatched(10);
            //myFirstBinaryTree.RemoveWithMatched(5);
            //myFirstBinaryTree.RemoveWithMatched(2);
            //myFirstBinaryTree.RemoveWithMatched(4);
            //myFirstBinaryTree.RemoveWithMatched(9);
            //myFirstBinaryTree.RemoveWithMatched(7);

            myFirstBinaryTree.PreOrderTraversal(a => Console.WriteLine(a));
            Console.WriteLine();
            myFirstBinaryTree.PostOrderTraversal(a => Console.WriteLine(a));
            Console.WriteLine();
            myFirstBinaryTree.InOrderTraversal(a => Console.WriteLine(a));

            myFirstBinaryTree.Remove(10);
            myFirstBinaryTree.Remove(5);
            myFirstBinaryTree.Remove(2);
            myFirstBinaryTree.Remove(4);
            myFirstBinaryTree.Remove(9);
            myFirstBinaryTree.Remove(7);
        }
    }
}
