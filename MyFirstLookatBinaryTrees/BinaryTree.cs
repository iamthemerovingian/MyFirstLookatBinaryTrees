

using System;

namespace MyFirstLookatBinaryTrees 
{
    public class BinaryTree<T> : System.Collections.Generic.IEnumerable<T> where T: System.IComparable<T>
    {
        private BinaryTreeNode<T> _head;
        private int _count = 0;

        public void Remove(T value)
        {
            BinaryTreeNode<T> parent;
            BinaryTreeNode<T> matched = FindWithParent(value, out parent);

            //Case 1. Value does not exist.
            if (matched == null)
            {
                return;
            }

            _count--;

            //Case 3.1
            //Node to replace has no right child, so the left child replaces the current child.
            if (matched.Right == null)
            {
                if (parent == null)
                {
                    _head = matched.Left;
                }
                else
                {
                    if (parent.CompareTo(matched.Value) > 0)
                    {
                        parent.Left = matched.Left;
                    }
                    else
                    {
                        parent.Right = matched.Left;
                    }
                }
                return;
            }

            //3.2 Node has a right child which has no left child. So right child replaces node.
            if (matched.Right.Left == null)
            {
                matched.Right.Left = matched.Left;

                if (parent == null)
                {
                    _head = matched.Right;
                }
                else
                {
                    if (parent.CompareTo(matched.Value) > 0)
                    {
                        parent.Left = matched.Right;
                    }
                    else
                    {
                        parent.Right = matched.Right;
                    }
                }

                return;
            }

            //Case 3.3 Node has a right child who has a left child. The left most child will replace the removed node.
            if (matched.Right.Left != null)
            {
                BinaryTreeNode<T> leftMostParent = matched.Right;
                BinaryTreeNode<T> leftMostChild = matched.Right.Left;

                while (leftMostChild.Left != null)
                {
                    leftMostParent = leftMostChild;
                    leftMostChild = leftMostChild.Left;
                }

                leftMostParent.Left = leftMostChild.Right;

                leftMostChild.Left = matched.Left;
                leftMostChild.Right = matched.Right;

                if (parent == null)
                {
                    _head = leftMostChild;
                }
                else
                {
                    if (parent.CompareTo(matched.Value) > 0)
                    {
                        parent.Left = leftMostChild;
                    }
                    else
                    {
                        parent.Right = leftMostChild;
                    }
                }

                return;
            }

        }
        public void RemoveWithMatched(T value)
        {
            BinaryTreeNode<T> matchingNode;

            FindWithMatched(_head, value, out matchingNode);


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

            //Case 3, Value Exists but node has children.

            //3.1 Node has no right child.
            if (matchingNode.Right == null && matchingNode.Left != null)
            {
                matchingNode = matchingNode.Left;
                return;
            }

            //3.2 Node has a right child which has no left child.
            if (matchingNode.Right.Left == null)
            {
                BinaryTreeNode<T> temp = matchingNode;
                matchingNode = matchingNode.Right;
                matchingNode.Left = temp.Left;
                return;
            }

            //Case 3.3 Node has a right child who has a left child. The left most child will replace the removed node.
            if (matchingNode.Right.Left != null)
            {
                BinaryTreeNode<T> temp = matchingNode;
                BinaryTreeNode<T> current = matchingNode.Right;

                while (current.Left != null)
                {
                    current = current.Left;
                }

                matchingNode = current;
                matchingNode.Right = temp.Right;
                matchingNode.Left = temp.Left;

                return;
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

        public bool ContainsWithMatched(T Value)
        {
            BinaryTreeNode<T> node;

            if (_head == null)
            {
                return false;
            }
            else
            {
                return FindWithMatched(_head, Value, out node) ?? false;
            }
        }

        public bool Contains(T value)
        {
            BinaryTreeNode<T> parentNode;
            return FindWithParent(value, out parentNode) != null;
        }

        private bool? FindWithMatched(BinaryTreeNode<T> current, T value, out BinaryTreeNode<T> matchedNode)
        {
            matchedNode = null;
            if (current == null)
            {
                return false;
            }

            if (current.Value.Equals(value))
            {
                matchedNode = current;
                return true;
            }

            var result = current.Value.CompareTo(value);

            if (result > 0) //Current is greater than the value, so value is smaller than current, so go left!
            {
                return FindWithMatched(current.Left, value, out matchedNode);
            }
            return FindWithMatched(current.Right, value, out matchedNode);
        }

        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parentNode)
        {
            BinaryTreeNode<T> currentNode = _head;
            parentNode = null;

            while (currentNode != null)
            {

                var result = currentNode.Value.CompareTo(value);

                if (result == 0) //We've found the node and its parent!
                {
                    break;
                }
                
                if (result > 0) //Value is smaller, go left!
                {
                    parentNode = currentNode;
                    currentNode = currentNode.Left;
                    continue;
                }

                if (result < 0) //Value is bigger, go right!
                {
                    parentNode = currentNode;
                    currentNode = currentNode.Right;
                    continue;
                }
            }

            return currentNode;
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

        public void PreOrderTraversal(System.Action<T> action)
        {
            PreOrderTraversal(action, _head);
        }
        private void PreOrderTraversal(System.Action<T> action, BinaryTreeNode<T> current)
        {
            if (current != null)
            {
                action(current.Value);
                PreOrderTraversal(action, current.Left);
                PreOrderTraversal(action, current.Right);
            }
        }

        public void InOrderTraversal(System.Action<T> action)
        {
            InOrderTraversal(action, _head);
        }

        private void InOrderTraversal(Action<T> action, BinaryTreeNode<T> current)
        {
            if (current != null)
            {
                InOrderTraversal(action, current.Left);
                action(current.Value);
                InOrderTraversal(action, current.Right);
            }
        }
        public void PostOrderTraversal(System.Action<T> action)
        {
            PostOrderTraversal(action, _head);
        }

        private void PostOrderTraversal(Action<T> action, BinaryTreeNode<T> current)
        {
            if (current != null)
            {
                PostOrderTraversal(action, current.Left);
                PostOrderTraversal(action, current.Right);
                action(current.Value);
            }
        }



        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
