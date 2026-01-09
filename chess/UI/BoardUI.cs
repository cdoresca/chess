namespace chess.UI
{
    internal class BoardUI
    {
        public CaseUI[,] board { get; }
        int col, row;
        public BoardUI(int row = 8, int col = 8)
        {
            this.row = row;
            this.col = col;
            board = new CaseUI[row, col];
            CreateBoard();
            Console.WriteLine(this);
            
        }

        private void CreateBoard()
        {
            int x = 2;
            int y = 2;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    board[i, j] = new CaseUI(j, i, x, y);
                    x += 4;
                }
                x = 2;
                y++;
            }
        }

        private string entete_row(int column)
        {
            string draw = " | ";
            char col = 'A';
            for (int i = 0; i < this.col; i++)
            {

                draw += col + " | ";
                col++;
            }
            draw += "\n";
            return draw;
        }

        private string entete(int column)
        {
            string draw = "  ";

            for (int i = 0; i < this.col; i++)
            {

                draw += " -- ";

            }
            draw += "\n";
            return draw;
        }
        public override string ToString()
        {
            string draw = entete_row(col);
            draw += entete(col);

            for (int i = 0; i < row; i++)
            {
                draw += i + 1 + "|";
                for (int j = 0; j < col; j++)
                {
                    draw += "   " + "|";
                }
                draw += "\n";
            }
            draw += entete(col);
            return draw;
        }
        public void afficherPiece()
        {
            foreach (CaseUI i in board)
            {
                
                Console.Write(i.ToString());
            }
        }

        public void clear()
        {
            foreach (CaseUI i in board)
            {
                if (i.allume || i.allumeSecondaire)
                {
                    i.clear();
                }
            }
        }
    }
}
