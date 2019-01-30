using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class WorldRules
    {
        public readonly List<Cell> _cellsToBeDestroyed = new List<Cell>();
        public readonly List<Cell> _cellsToBeCreated = new List<Cell>();
        
        public void DecideDead(World world)
        {
            foreach (var cell in world.Cells.Keys.ToList())
            {
                if (world.Cells[cell] < 2 || 
                    world.Cells[cell] > 3 && 
                    !_cellsToBeDestroyed.Contains(cell))
                {
                    _cellsToBeDestroyed.Add(cell);
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
                        _cellsToBeCreated.Add(newCell);
                    }
                }
            }
        }

        public void Eradicate(World world)
        {
            foreach (var cell in _cellsToBeDestroyed)
            {
                world.RemoveCell(cell);
            }
            
            _cellsToBeDestroyed.Clear();
        }

        public void Populate(World world)
        {
            foreach (var cell in _cellsToBeCreated)
            {
                world.InsertCell(cell);
            } 
                       
            _cellsToBeCreated.Clear();
        }
    }
}