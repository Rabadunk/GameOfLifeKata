using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GameOfLife
{
    public class Tribunal
    {
        private readonly List<Cell> _deadCells = new List<Cell>();
        private readonly List<Cell> _newCells = new List<Cell>();
        public List<Cell> DeadCells => _deadCells;
        public List<Cell> NewCells => _newCells;
        
        public void DecideDead(Grid grid)
        {
            foreach (var cell in grid.Cells.Keys.ToList())
            {
                if (grid.Cells[cell] < 2 || 
                    grid.Cells[cell] > 3 && 
                    !_deadCells.Contains(cell))
                {
                    _deadCells.Add(cell);
                }
            }
        }

        private void DecideNewLife(Grid grid)
        {
            for(var row = 0; row < grid.Width; row++)
            {
                for (var col = 0; col < grid.Height; col++)
                {
                    var newCell = new Cell(row, col);

                    if (grid.CountNeighbors(newCell) == 3)
                    {
                        _newCells.Add(newCell);
                    }
                }
            }
        }

        private void Eradicate(Grid grid)
        {
            foreach (var cell in _deadCells)
            {
                grid.RemoveCell(cell);
            }
            
            _deadCells.Clear();
        }

        private void Populate(Grid grid)
        {
            foreach (var cell in _newCells)
            {
                grid.InsertCell(cell);
            } 
                       
            _newCells.Clear();
        }


        public void UpdateUniverse(Grid grid)
        {  
            DecideDead(grid);
            DecideNewLife(grid);
            
            Eradicate(grid);
            Populate(grid);
        }
    }
}