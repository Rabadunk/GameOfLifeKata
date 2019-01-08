using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Grid
    {
        private readonly List<Cell> _livingCells = new List<Cell>();
        public IEnumerable<Cell> LivingCells => _livingCells;

        public void InsertCell(Cell cell)
        {
            if (!_livingCells.Any(c => c.Row == cell.Row & c.Col == cell.Col))
            {
                _livingCells.Add(cell);
            }
        }

        public void RemoveCell(Cell cell)
        {
            if (_livingCells.Any(c => c.Row == cell.Row & c.Col == cell.Col))
            {
                _livingCells.Remove(cell);
            }
        }

    }
}