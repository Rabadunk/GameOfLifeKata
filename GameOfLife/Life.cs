using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Life
    {
        private readonly Dictionary<Cell, int> _cells = new Dictionary<Cell, int>();
        public Dictionary<Cell, int> Cells => _cells;

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
            if (_cells.Any(c => c.Key.Row == cell.Row & c.Key.Col == cell.Col))
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

        private int CountNeighbors(Cell cell)
        {
            var neighbors = 0;
            
            for (var row = cell.Row - 1; row <= cell.Row + 1; row++)
            {
                for (var col = cell.Col - 1; col <= cell.Col + 1; col++)
                {
                    if (_cells.Any(c => c.Key.Row == row & c.Key.Col == col))
                    {
                        neighbors += 1;
                    } 
                }
            }

            return neighbors - 1;
        }

    }
}