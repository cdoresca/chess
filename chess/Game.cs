
using chess.Piece;
using chess.UI;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace chess
{
    internal class Game
    {
        Windows windows;

        List<PieceBase> whitePiece;
        List<PieceBase> blackPiece;

        Player white;
        Player black;

        GameState state;

        ConsoleUI console;
        public Game()
        {

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();

            windows = new Windows("Message", 0, 11);

            whitePiece = new List<PieceBase>();
            blackPiece = new List<PieceBase>();

            MakePieceWhite();
            MakePieceBlack();

            state = new GameState(new Board(), new PlayerState(whitePiece), new PlayerState(blackPiece), Color.WHITE);
            console = new ConsoleUI();

            white = new Player(Color.WHITE,console);
            black = new Player(Color.BLACK,console);
        }
        public void MakePieceWhite()
        {
            for (int i = 0; i < 8; i++)
            {
                whitePiece.Add(new Pion("PionBlanc" + i, (6, i), Color.WHITE, true));
            }

            whitePiece.Add(new Cheval("ChevalBlanc0", (7, 2), Color.WHITE, true));
            whitePiece.Add(new Cheval("ChevalBlanc1", (7, 5), Color.WHITE, true));

            whitePiece.Add(new Tour("TourBlanc0", (7, 0), Color.WHITE, true));
            whitePiece.Add(new Tour("TourBlanc1", (7, 7), Color.WHITE, true));

            whitePiece.Add(new Fou("FouBlanc0", (7, 1), Color.WHITE, true));
            whitePiece.Add(new Fou("FouBlanc1", (7, 6), Color.WHITE, true));

            whitePiece.Add(new Roi("RoiBlanc", (7, 3), Color.WHITE, true));

            whitePiece.Add(new Reine("ReineBlanc", (7, 4), Color.WHITE, true));

        }

        public void MakePieceBlack()
        {
            for (int i = 0; i < 8; i++)
            {
                blackPiece.Add(new Pion("PionNoir" + i, (1, i), Color.BLACK, true));
            }

            blackPiece.Add(new Cheval("ChevalNoir0", (0, 2), Color.BLACK, true));
            blackPiece.Add(new Cheval("ChevalNoir1", (0, 5), Color.BLACK, true));

            blackPiece.Add(new Tour("TourNoir0", (0, 0), Color.BLACK, true));
            blackPiece.Add(new Tour("TourNoir1", (0, 7), Color.BLACK, true));

            blackPiece.Add(new Fou("FouNoir0", (0, 1), Color.BLACK, true));
            blackPiece.Add(new Fou("FouNoir1", (0, 6), Color.BLACK, true));

            blackPiece.Add(new Roi("RoiNoir", (0, 3), Color.BLACK, true));

            blackPiece.Add(new Reine("ReineNoir", (0, 4), Color.BLACK, true));
        }
        

        public void run()
        {
            Move whiteMove;
            Move blackMove;

            while (true)
            {
                whiteMove = white.play(state);
                state = state.ApplyMove(whiteMove);

                
                if (state.checkmate(Color.BLACK) || state.stalemate(Color.BLACK))
                    break;

                
                blackMove = black.play(state);
                state = state.ApplyMove(blackMove);

                if (state.checkmate(Color.WHITE) || state.stalemate(Color.WHITE))
                    break;


            }
        }


        public static void colorFront(Color color)
        {

            if (color == Color.BLACK) { Console.ForegroundColor = ConsoleColor.Black; }
            else { Console.ForegroundColor = ConsoleColor.White; }

        }
    }
}
