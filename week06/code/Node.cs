using System;

namespace Trees
{
    public class Node
    {
        public int Data { get; private set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int data)
        {
            Data = data;
        }

        /// #############
        /// # Problem 1 #
        /// #############
        public void Insert(int value)
        {
            if (value == Data)
                return; // No duplicates - unique values only

            if (value < Data)
            {
                if (Left == null)
                    Left = new Node(value);
                else
                    Left.Insert(value);
            }
            else
            {
                if (Right == null)
                    Right = new Node(value);
                else
                    Right.Insert(value);
            }
        }

        /// #############
        /// # Problem 2 #
        /// #############
        public bool Contains(int value)
        {
            if (value == Data)
                return true;

            if (value < Data)
                return Left != null && Left.Contains(value);
            else
                return Right != null && Right.Contains(value);
        }

        /// #############
        /// # Problem 4 #
        /// #############
        public int GetHeight()
        {
            if (Left == null && Right == null)
                return 1; // Only root node

            int leftHeight = Left?.GetHeight() ?? 0;
            int rightHeight = Right?.GetHeight() ?? 0;

            return 1 + Math.Max(leftHeight, rightHeight);
        }
    }
}