

namespace MyFirstLookatBinaryTrees 
{
    public class BinaryTree<T> : System.Collections.Generic.IEnumerable<T> where T: System.IComparable<T>
    {
        private BinaryTreeNode<T> _head;
        private int _count = 0;

        public void Remove(T value)
        {
            BinaryTreeNode<T> matchingNode;

            HasValue(_head, value, out matchingNode);


            //Case 1, value does not exist inside the tree.
            if (matchingNode == null)
            {
                return;
            }

            //Case 2, Value Exists and is a leaf node (has no children)
            if (matchingNode.Left == null && matchingNode.Right == null)
            {
                BinaryTreeNode<T> currentNode = _head;
                BinaryTreeNode<T> parentNode = null;
                bool goLeft = false;

                while (currentNode != null)
                {

                    var result = currentNode.Value.CompareTo(value);

                    if (result == 0) //We've found the node and its parent!
                    {
                        //Decide Which Child to delete
                        if (goLeft)
                        {
                            parentNode.Left = null;
                        }
                        else
                        {
                            parentNode.Right = null;
                        }
                        break;
                    }
                    else
                    {
                        goLeft = false;
                    }

                    if (result > 0) //Value is smaller, go left!
                    {
                        goLeft = true;
                        parentNode = currentNode;
                        currentNode = currentNode.Left;
                        continue;
                    }

                    if (result < 0) //Value is bigger, go right!
                    {
                        goLeft = false;
                        parentNode = currentNode;
                        currentNode = currentNode.Right;
                        continue;
                    }


                }
            }
        }
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
