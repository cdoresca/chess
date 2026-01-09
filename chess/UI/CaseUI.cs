namespace chess.UI
{

    internal class CaseUI
    {
        public int col { get; }
        public int row {get;}
        public int[] posCurseur { get; }
        public PieceUI piece { get; set; }
        public bool allume { get; set; }
        public bool allumeSecondaire { get; set; }
        public CaseUI(int col, int row, int x, int y)
        {
            this.col = col;
            this.row = row;
            posCurseur = new int[]{ x,y};
        }

        public override string ToString()
        {
            Console.SetCursorPosition(posCurseur[0], posCurseur[1]);
            return empty() ? "   " : " " + piece.ToString() + " ";
        }
        public bool empty() { return piece == null; }

        public void setPiece(PieceUI piece) { this.piece = piece; }

        public void selectionner()
        {
            allume = true;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(this);
            Console.BackgroundColor = ConsoleColor.DarkGray;
        }

        public void sousSelection()
        {

            allumeSecondaire = true;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write(this);
            Console.BackgroundColor = ConsoleColor.DarkGray;

        }

        public void clear()
        {
            allume = false;
            allumeSecondaire = false;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write(this);
        }
    }
}
