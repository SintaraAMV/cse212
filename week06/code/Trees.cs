using System.Collections.Generic;

namespace Trees
{
    public static class Trees
    {
        /// #############
        /// # Problem 5 #
        /// #############
        public static void InsertMiddle(List<int> values, int first, int last, BinarySearchTree tree)
        {
            if (first > last)
                return;

            int middle = (first + last) / 2;

            tree.Insert(values[middle]);

            InsertMiddle(values, first, middle - 1, tree);
            InsertMiddle(values, middle + 1, last, tree);
        }

        public static BinarySearchTree CreateTreeFromSortedList(List<int> values)
        {
            var tree = new BinarySearchTree();
            if (values.Count > 0)
                InsertMiddle(values, 0, values.Count - 1, tree);
            return tree;
        }
    }
}