using System.Collections.Generic;

namespace GameOfLife
{
    public class Cell
    {
        public int Row { get; }
        public int Col { get;  }

        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
        }
        
    }
}