
using System;

namespace MyFirstLookatBinaryTrees 
{
    public class BinaryTree<T> : System.Collections.Generic.IEnumerable<T> where T: System.IComparable<T>
    {
        private BinaryTreeNode<T> _head;
        private int _count = 0;

        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new BinaryTreeNode<T>(value);
            }
            else
            {
                AddTo(_head, value);
            }

            _count++;
        }

        private void AddTo(BinaryTreeNode<T> current, T value)
        {
            var result = current.CompareTo(value);

            if (result > 0)// Current is Greater than Value (Value is less than current) so add to the left.
            {
                if (current.Left == null)
                {
                    current.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddTo(current.Left, value);
                }
            }
            else if (result < 0)// Current is less than the value, (value is more than the current) so add to the right
            {
                if (current.Right == null)
                {
                    current.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddTo(current.Right, value);
                }
            }
            else // Values are equal, so add to the right of the current node.
            {
                if (current.Right == null)
                {
                    current.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddTo(current.Right, value);
                }
            }
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
