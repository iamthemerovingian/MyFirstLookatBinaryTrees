

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

        public bool Contains(T Value)
        {
            BinaryTreeNode<T> node;

            if (_head == null)
            {
                return false;
            }
            else
            {
                return HasValue(_head, Value, out node) ?? false;
            }
        }

        private bool? HasValue(BinaryTreeNode<T> current, T value, out BinaryTreeNode<T> node)
        {
            node = null;
            if (current == null)
            {
                return false;
            }

            if (current.Value.Equals(value))
            {
                node = current;
                return true;
            }

            var result = current.Value.CompareTo(value);

            if (result > 0) //Current is greater than the value, so value is smaller than current, so go left!
            {
                return HasValue(current.Left, value, out node);
            }

            return HasValue(current.Right, value, out node);
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
            else if (result <= 0)// Current is less or equal to the value, (value is more than or equal to the current) so add to the right
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
