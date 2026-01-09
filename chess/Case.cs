namespace chess
{
    internal class Case
    {
        public int column { get; }
        public int row { get; }

        public PieceBase piece { get; set; }

        public Case(int col, int row, PieceBase p = null)
        {
            this.column = col;
            this.row = row;
            this.piece = p;
        }

        public bool empty() { return piece == null; }



        public Case cloneWithPiece(PieceBase p)
        {
            return new Case(column, row, p);
        }
    }

}
