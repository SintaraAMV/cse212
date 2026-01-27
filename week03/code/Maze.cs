using System;
using System.Collections.Generic;

namespace Mase
{
    public class Maze
    {
        private Dictionary<(int, int), bool[]> _map;
        private (int x, int y) _currentPosition;
        
        public Maze(Dictionary<(int, int), bool[]> map)
        {
            _map = map;
            _currentPosition = (1, 1);
        }
        
        public string GetStatus()
        {
            return $"Current location (x={_currentPosition.x}, y={_currentPosition.y})";
        }
        
        public void MoveUp()
        {
            var (x, y) = _currentPosition;
            // Asumiendo que bool[] contiene [left, right, up, down]
            if (!_map.ContainsKey((x, y)) || !_map[(x, y)][2])
                throw new InvalidOperationException();
            _currentPosition = (x, y - 1);
        }
        
        public void MoveDown()
        {
            var (x, y) = _currentPosition;
            if (!_map.ContainsKey((x, y)) || !_map[(x, y)][3])
                throw new InvalidOperationException();
            _currentPosition = (x, y + 1);
        }
        
        public void MoveLeft()
        {
            var (x, y) = _currentPosition;
            if (!_map.ContainsKey((x, y)) || !_map[(x, y)][0])
                throw new InvalidOperationException();
            _currentPosition = (x - 1, y);
        }
        
        public void MoveRight()
        {
            var (x, y) = _currentPosition;
            if (!_map.ContainsKey((x, y)) || !_map[(x, y)][1])
                throw new InvalidOperationException();
            _currentPosition = (x + 1, y);
        }
    }
}