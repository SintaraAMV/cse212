using System;
using System.Collections.Generic;

namespace Recursion
{
    public static class Recursion
    {
        /// #############
        /// # Problem 1 #
        /// #############
        public static int SumSquaresRecursive(int n)
        {
            if (n <= 0)
                return 0;
            return (n * n) + SumSquaresRecursive(n - 1);
        }

        /// #############
        /// # Problem 2 #
        /// #############
        public static void PermutationsChoose(char[] letters, int size, List<string> results)
        {
            PermutationsChooseHelper(letters, size, "", results);
        }

        private static void PermutationsChooseHelper(char[] letters, int size, string current, List<string> results)
        {
            if (current.Length == size)
            {
                results.Add(current);
                return;
            }

            for (int i = 0; i < letters.Length; i++)
            {
                PermutationsChooseHelper(letters, size, current + letters[i], results);
            }
        }

        /// #############
        /// # Problem 3 #
        /// #############
        public static int CountWaysToClimb(int s, Dictionary<int, int> remember = null)
        {
            if (remember == null)
                remember = new Dictionary<int, int>();

            if (s < 0) return 0;
            if (s == 0) return 1;

            if (remember.ContainsKey(s))
                return remember[s];

            int result = CountWaysToClimb(s - 1, remember) +
                         CountWaysToClimb(s - 2, remember) +
                         CountWaysToClimb(s - 3, remember);

            remember[s] = result;
            return result;
        }

        /// #############
        /// # Problem 4 #
        /// #############
        public static void WildcardBinary(string pattern, List<string> results)
        {
            WildcardBinaryHelper(pattern, "", results);
        }

        private static void WildcardBinaryHelper(string pattern, string current, List<string> results)
        {
            if (current.Length == pattern.Length)
            {
                results.Add(current);
                return;
            }

            int index = current.Length;
            if (pattern[index] == '*')
            {
                WildcardBinaryHelper(pattern, current + "0", results);
                WildcardBinaryHelper(pattern, current + "1", results);
            }
            else
            {
                WildcardBinaryHelper(pattern, current + pattern[index], results);
            }
        }
    }
}