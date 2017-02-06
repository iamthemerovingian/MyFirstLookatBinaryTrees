namespace MyFirstLookatBinaryTrees
{
    public class BinaryTreeNode<T> : System.IComparable<T>
        where T: System.IComparable<T>
    {
        public BinaryTreeNode(T value)
        {
            Value = value;
        }

        public BinaryTreeNode<T> Right { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public T Value { get; private set; }

        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }
    }
}