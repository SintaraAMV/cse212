// DO NOT MODIFY THIS FILE

using System;
using System.Collections.Generic;

namespace Recursion
{
    public static class Maze
    {
        // DO NOT MODIFY THIS FILE - the helpers are already written for you

        public static void SolveMaze(int[] maze, int size, List<string> results)
        {
            List<(int x, int y)> currPath = new List<(int x, int y)>();
            SolveMazeHelper(maze, size, 0, 0, currPath, results);
        }

        private static void SolveMazeHelper(int[] maze, int size, int x, int y,
            List<(int x, int y)> currPath, List<string> results)
        {
            // Add current position to path
            currPath.Add((x, y));

            if (IsEnd(maze, size, x, y))
            {
                results.Add(currPath.AsString());
            }
            else
            {
                // Try moving right
                if (IsValidMove(maze, size, x + 1, y, currPath))
                    SolveMazeHelper(maze, size, x + 1, y, currPath, results);

                // Try moving down
                if (IsValidMove(maze, size, x, y + 1, currPath))
                    SolveMazeHelper(maze, size, x, y + 1, currPath, results);

                // Try moving left
                if (IsValidMove(maze, size, x - 1, y, currPath))
                    SolveMazeHelper(maze, size, x - 1, y, currPath, results);

                // Try moving up
                if (IsValidMove(maze, size, x, y - 1, currPath))
                    SolveMazeHelper(maze, size, x, y - 1, currPath, results);
            }

            // Backtrack
            currPath.RemoveAt(currPath.Count - 1);
        }

        // The helper methods below are already provided by the course
        private static bool IsEnd(int[] maze, int size, int x, int y)
        {
            return maze[y * size + x] == 2;
        }

        private static bool IsValidMove(int[] maze, int size, int x, int y, List<(int x, int y)> currPath)
        {
            if (x < 0 || x >= size || y < 0 || y >= size)
                return false;

            if (maze[y * size + x] == 0)
                return false;

            foreach (var pos in currPath)
            {
                if (pos.x == x && pos.y == y)
                    return false;
            }
            return true;
        }
    }

    // Extension method used by the tests
    public static class ListExtensions
    {
        public static string AsString(this List<(int x, int y)> list)
        {
            return string.Join(" -> ", list.Select(p => $"({p.x},{p.y})"));
        }
    }
}