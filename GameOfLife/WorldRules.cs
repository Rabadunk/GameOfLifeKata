using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GameOfLife
{
    public class WorldRules
    {
        private readonly List<Cell> _deadCells = new List<Cell>();
        private readonly List<Cell> _newCells = new List<Cell>();
        
        public void DecideDead(World world)
        {
            foreach (var cell in world.Cells.Keys.ToList())
            {
                if (world.Cells[cell] < 2 || 
                    world.Cells[cell] > 3 && 
                    !_deadCells.Contains(cell))
                {
                    _deadCells.Add(cell);
                }
            }
        }

        public void DecideNewLife(World world)
        {
            for(var row = 1; row <= world.Width; row++)
            {
                for (var col = 1; col <= world.Height; col++)
                {
                    var newCell = new Cell(row, col);

                    if (world.CountNeighbors(newCell) == 3)
                    {
                        _newCells.Add(newCell);
                    }
                }
            }
        }

        public void Eradicate(World world)
        {
            foreach (var cell in _deadCells)
            {
                world.RemoveCell(cell);
            }
            
            _deadCells.Clear();
        }

        public void Populate(World world)
        {
            foreach (var cell in _newCells)
            {
                world.InsertCell(cell);
            } 
                       
            _newCells.Clear();
        }
    }
}