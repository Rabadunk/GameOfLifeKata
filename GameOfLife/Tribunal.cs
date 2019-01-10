using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GameOfLife
{
    public class Tribunal
    {
        private readonly List<Cell> _deadCells = new List<Cell>();
        public List<Cell> DeadCells => _deadCells;
        
        public void DecideUnderpopulation(Life life)
        {
            foreach (var cell in life.Cells.Keys.ToList())
            {
                if (life.Cells[cell] < 2)
                {
                    _deadCells.Add(cell);
                }
            }
        }
    }
}