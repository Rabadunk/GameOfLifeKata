using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class World
    {
        private readonly Dictionary<Cell, int> _cells = new Dictionary<Cell, int>();
        private readonly WorldRules _worldRules = new WorldRules();
        public Dictionary<Cell, int> Cells => _cells;
        public int Height { get;  }
        public int Width { get;  }

        public World(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public void InsertCell(Cell cell)
        {
            if (!_cells.Any(c => c.Key.Row == cell.Row & c.Key.Col == cell.Col))
            {
                _cells.Add(cell, 0);
            }
            
            UpdateNeighborCounts();
        }

        public void RemoveCell(Cell cell)
        {
            if (_cells.Keys.ToList().Contains(cell))
            {
                _cells.Remove(cell);
            }
            
            UpdateNeighborCounts();
        }

        private void UpdateNeighborCounts()
        {
            
            foreach (var cell in _cells.Keys.ToList())
            {
                _cells[cell] = CountNeighbors(cell);
            }
        }

        private int FixForOverlap(int position, bool isCol)
        {
            var max = isCol ? Width : Height;           
            if (position < 1) return max;
            return position > max ? 1 : position;
        }

        public int CountNeighbors(Cell cell)
        {
            var neighbors = 0;
            
            for (var row = cell.Row - 1; row <= cell.Row + 1; row++)
            {
                for (var col = cell.Col - 1; col <= cell.Col + 1; col++)
                {
                    var colCheck = FixForOverlap(col, true);
                    var rowCheck = FixForOverlap(row, false);
                    
                    if (_cells.Any(c => c.Key.Row == rowCheck & c.Key.Col == colCheck))
                    {
                        neighbors += 1;
                    } 
                }
            }

            return _cells.Keys.ToList().Contains(cell) ? neighbors - 1 : neighbors;
        }

        public void UpdateWorld()
        {  
            _worldRules.DecideDead(this);
            _worldRules.DecideNewLife(this);
            
            _worldRules.Eradicate(this);
            _worldRules.Populate(this);
        }

    }
}