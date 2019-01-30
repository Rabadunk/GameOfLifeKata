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
        
        public override bool Equals(object obj)
        {
            return Equals(obj as Cell);
        }

        public bool Equals(Cell other)
        {
            if (ReferenceEquals(other, null)) return false ;

            if (ReferenceEquals(this, other)) return true;

            if (GetType() != other.GetType()) return false;

            return (Row == other.Row) && (Col == other.Col);
        }
        
    }
}