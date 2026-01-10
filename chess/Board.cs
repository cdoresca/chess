using chess.Piece;


namespace chess
{
    internal class Board
    {
        int width, height;
        public Case[,] grid { get; }
        public Board()
        {
            this.width = 8;
            this.height = 8;
            grid = new Case[this.height, this.width];
            CreateInitial();
        }

        public Board(Case[,] board)
        {
            this.width = 8;
            this.height = 8;
            this.grid = board;
        }

        private Case[,] CloneCells()
        {
            Case[,] newCells = new Case[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Case oldCase = grid[i, j];


                    newCells[i, j] = new Case(
                        oldCase.column,
                        oldCase.row,
                        oldCase.piece?.clone()

                    );
                }
            }

            return newCells;
        }
        public void CreateInitial()
        {
            

            // 1. Initialiser toutes les cases vides
            for (int r = 0; r < 8; r++)
                for (int c = 0; c < 8; c++)
                    grid[r, c] = new Case(r, c, null);

            // -----------------------------
            // 2. Pièces BLANCHES
            // -----------------------------

            // Pions blancs (ligne 6)
            for (int i = 0; i < 8; i++)
                grid[6, i].piece = new Pion("PionBlanc" + i, (6, i), Color.WHITE, true);

            // Tours blanches
            grid[7, 0].piece = new Tour("TourBlanc0", (7, 0), Color.WHITE, true);
            grid[7, 7].piece = new Tour("TourBlanc1", (7, 7), Color.WHITE, true);

            // Cavaliers blancs
            grid[7, 2].piece = new Cheval("ChevalBlanc0", (7, 2), Color.WHITE, true);
            grid[7, 5].piece = new Cheval("ChevalBlanc1", (7, 5), Color.WHITE, true);

            // Fous blancs
            grid[7, 1].piece = new Fou("FouBlanc0", (7, 1), Color.WHITE, true);
            grid[7, 6].piece = new Fou("FouBlanc1", (7, 6), Color.WHITE, true);

            // Roi blanc
            grid[7, 3].piece = new Roi("RoiBlanc", (7, 3), Color.WHITE, true);

            // Reine blanche
            grid[7, 4].piece = new Reine("ReineBlanc", (7, 4), Color.WHITE, true);

            // -----------------------------
            // 3. Pièces NOIRES
            // -----------------------------

            // Pions noirs (ligne 1)
            for (int i = 0; i < 8; i++)
                grid[1, i].piece = new Pion("PionNoir" + i, (1, i), Color.BLACK, true);

            // Tours noires
            grid[0, 0].piece = new Tour("TourNoir0", (0, 0), Color.BLACK, true);
            grid[0, 7].piece = new Tour("TourNoir1", (0, 7), Color.BLACK, true);

            // Cavaliers noirs
            grid[0, 2].piece = new Cheval("ChevalNoir0", (0, 2), Color.BLACK, true);
            grid[0, 5].piece = new Cheval("ChevalNoir1", (0, 5), Color.BLACK, true);

            // Fous noirs
            grid[0, 1].piece = new Fou("FouNoir0", (0, 1), Color.BLACK, true);
            grid[0, 6].piece = new Fou("FouNoir1", (0, 6), Color.BLACK, true);

            // Roi noir
            grid[0, 3].piece = new Roi("RoiNoir", (0, 3), Color.BLACK, true);

            // Reine noire
            grid[0, 4].piece = new Reine("ReineNoir", (0, 4), Color.BLACK, true);

            // -----------------------------
            // 4. Retourner le board immuable
            // -----------------------------
            
        }

        public Board CloneWithMove(Move move, PieceBase piece)
        {
            Case[,] newBoard = CloneCells();

            (int row, int col) from = move.From;
            (int row, int col) to = move.To;

            newBoard[from.row, from.col] = newBoard[from.row, from.col].cloneWithPiece(null);
            newBoard[to.row, to.col] = newBoard[to.row, to.col].cloneWithPiece(piece);

            return new Board(newBoard);
        }
        public Board clone()
        {
            return new Board(CloneCells());
        }
    }
}
