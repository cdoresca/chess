using chess.UI.pieceUI;

namespace chess.UI
{
    internal class ConsoleUI
    {
        public BoardUI board { get; }


        public ConsoleUI() 
        {
            board = new BoardUI();
            
    

            MakeAndPlacePieceWhite();
            MakeAndPlacePieceBlack();
            board.afficherPiece();
        }

        public void MakeAndPlacePieceWhite()
        {
            for (int i = 0; i < 8; i++)
            {
                board[6,i].piece =new PionUI("PionBlanc"+i, board[6, i], Color.WHITE);
            }

            board[7, 0].piece = new TourUI("TourBlanc0", board[7, 0], Color.WHITE);
            board[7, 7].piece = new TourUI("TourBlanc1", board[7, 7], Color.WHITE);

            board[7, 1].piece = new FouUI("FouBlanc0", board[7, 1], Color.WHITE);
            board[7, 6].piece = new FouUI("FouBlanc1", board[7, 6], Color.WHITE);

            board[7, 2].piece = new ChevalUI("ChevalBlanc0", board[7, 2], Color.WHITE);
            board[7, 5].piece = new ChevalUI("ChevalBlanc1", board[7, 5], Color.WHITE);

            board[7, 3].piece = new RoiUI("RoiBlanc", board[7, 3], Color.WHITE);

            board[7, 4].piece = new ReineUI("ReineBlanc", board[7, 4], Color.WHITE);
        }

        public void MakeAndPlacePieceBlack()
        {
            // Pions noirs (rangée 1)
            for (int i = 0; i < 8; i++)
            {
                board[1, i].piece = new PionUI("PionNoir" + i, board[1, i], Color.BLACK);
            }

            // Tours noires
            board[0, 0].piece = new TourUI("TourNoir0", board[0, 0], Color.BLACK);
            board[0, 7].piece = new TourUI("TourNoir1", board[0, 7], Color.BLACK);

            // Fous noirs
            board[0, 1].piece = new FouUI("FouNoir0", board[0, 1], Color.BLACK);
            board[0, 6].piece = new FouUI("FouNoir1", board[0, 6], Color.BLACK);

            // Cavaliers noirs
            board[0, 2].piece = new ChevalUI("ChevalNoir0", board[0, 2], Color.BLACK);
            board[0, 5].piece = new ChevalUI("ChevalNoir1", board[0, 5], Color.BLACK);

            // Roi noir
            board[0, 3].piece = new RoiUI("RoiNoir", board[0, 3], Color.BLACK);

            // Reine noire
            board[0, 4].piece = new ReineUI("ReineNoir", board[0, 4], Color.BLACK);
        }

        public void afficherMouvement(List<Move> moves)
        {
            foreach (var move in moves)
            {
                (int row,int col) to = move.To;
                board[to.row, to.col].sousSelection();
            }
        }

        public PieceBase isLegalPiece(List<PieceBase> pieces,PieceUI pieceUI)
        {
            foreach(var piece in pieces)
            {
                if(piece.name == pieceUI.name) return piece;
            }
            return null;
        }
    }
}
