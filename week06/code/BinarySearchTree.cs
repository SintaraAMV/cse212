using System;
using System.Collections.Generic;

namespace Trees
{
    public class BinarySearchTree
    {
        public Node Root { get; private set; }

        public void Insert(int value)
        {
            if (Root == null)
                Root = new Node(value);
            else
                Root.Insert(value);
        }

        public bool Contains(int value)
        {
            return Root != null && Root.Contains(value);
        }

        /// #############
        /// # Problem 3 #
        /// #############
        public void TraverseBackward(Action<int> action)
        {
            TraverseBackwardHelper(Root, action);
        }

        private void TraverseBackwardHelper(Node node, Action<int> action)
        {
            if (node == null)
                return;

            // Right -> Visit -> Left (for reverse order)
            TraverseBackwardHelper(node.Right, action);
            action(node.Data);
            TraverseBackwardHelper(node.Left, action);
        }

        public IEnumerable<int> Reversed()
        {
            var list = new List<int>();
            TraverseBackward(value => list.Add(value));
            return list;
        }

        public IEnumerable<int> TraverseForward()
        {
            var list = new List<int>();
            TraverseForwardHelper(Root, value => list.Add(value));
            return list;
        }

        private void TraverseForwardHelper(Node node, Action<int> action)
        {
            if (node == null) return;
            TraverseForwardHelper(node.Left, action);
            action(node.Data);
            TraverseForwardHelper(node.Right, action);
        }

        public int GetHeight()
        {
            return Root?.GetHeight() ?? 0;
        }
    }
}