using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess.Piece;
using chess;
using chess.piece;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace chess
{
    internal class Game
    {
        Grid board;
       
        Windows windows;
        

        Control controlWhite;
        Control controlBlack;

        Dictionary<char,List<PieceBase>> whitePiece;
        Dictionary<char,List<PieceBase>> blackPiece;

        RuleGame rule;
        


        public Game() {

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();

            board = new Grid();

            windows = new Windows("Message", 0, 11);
          
            

            

            whitePiece = new Dictionary<char, List<PieceBase>>();
            blackPiece = new Dictionary<char, List<PieceBase>>();

            MakePieceWhite();
            MakePieceBlack();

            rule = new RuleGame(board,windows,blackPiece,whitePiece);

            controlWhite = new Control(board, Color.WHITE,rule);
            controlBlack = new Control(board, Color.BLACK,rule);

            board.afficherPion();
        }
        public void MakePieceWhite()
        {
            whitePiece['P'] =new List<PieceBase>();
            whitePiece['T'] =new List<PieceBase>();
            whitePiece['F'] =new List<PieceBase>();
            whitePiece['C'] =new List<PieceBase>();
            whitePiece['K'] =new List<PieceBase>();
            whitePiece['Q'] =new List<PieceBase>();


            for (int i = 0; i < 8; i++)
            {

                board.getGrid()[6, i]
                    .setPiece(new Pion("P", board.getGrid()[6, i], Color.WHITE));
                whitePiece['P'].Add(board.getGrid()[6, i].getPiece());
            }

            board.getGrid()[7, 0].setPiece(new Tour("T", board.getGrid()[7, 0], Color.WHITE));
            board.getGrid()[7, 7].setPiece(new Tour("T", board.getGrid()[7, 7], Color.WHITE));

            whitePiece['T'].Add(board.getGrid()[7, 0].getPiece());
            whitePiece['T'].Add(board.getGrid()[7, 7].getPiece());


            board.getGrid()[7, 1].setPiece(new Fou("F", board.getGrid()[7, 1], Color.WHITE));
            board.getGrid()[7, 6].setPiece(new Fou("F", board.getGrid()[7, 6], Color.WHITE));

            whitePiece['F'].Add(board.getGrid()[7, 1].getPiece());
            whitePiece['F'].Add(board.getGrid()[7, 6].getPiece());

            board.getGrid()[7, 2].setPiece(new Cheval("C", board.getGrid()[7, 2], Color.WHITE));
            board.getGrid()[7, 5].setPiece(new Cheval("C", board.getGrid()[7, 5], Color.WHITE));

            whitePiece['C'].Add(board.getGrid()[7, 2].getPiece());
            whitePiece['C'].Add(board.getGrid()[7, 5].getPiece());

            board.getGrid()[7, 3].setPiece(new Roi("K", board.getGrid()[7, 3], Color.WHITE));
            whitePiece['K'].Add(board.getGrid()[7, 3].getPiece());

            board.getGrid()[7, 4].setPiece(new Reine("Q", board.getGrid()[7, 4], Color.WHITE));
            whitePiece['Q'].Add(board.getGrid()[7,4].getPiece());




        }

        public void MakePieceBlack()
        {
            blackPiece['P'] = new List<PieceBase>();
            blackPiece['T'] = new List<PieceBase>();
            blackPiece['F'] = new List<PieceBase>();
            blackPiece['C'] = new List<PieceBase>();
            blackPiece['K'] = new List<PieceBase>();
            blackPiece['Q'] = new List<PieceBase>();

            for (int i = 0; i < 8; i++)
            {

                board.getGrid()[1, i]
                    .setPiece(new Pion("P", board.getGrid()[1, i], Color.BLACK));
                blackPiece['P'].Add(board.getGrid()[1, i].getPiece());
            }

            board.getGrid()[0, 0].setPiece(new Tour("T", board.getGrid()[0, 0], Color.BLACK));
            board.getGrid()[0, 7].setPiece(new Tour("T", board.getGrid()[0, 7], Color.BLACK));

            blackPiece['T'].Add(board.getGrid()[0,0].getPiece());
            blackPiece['T'].Add(board.getGrid()[0,7].getPiece());

            board.getGrid()[0, 1].setPiece(new Fou("F", board.getGrid()[0, 1], Color.BLACK));
            board.getGrid()[0, 6].setPiece(new Fou("F", board.getGrid()[0, 6], Color.BLACK));

            blackPiece['F'].Add(board.getGrid()[0, 1].getPiece());
            blackPiece['F'].Add(board.getGrid()[0, 6].getPiece());

            board.getGrid()[0, 2].setPiece(new Cheval("C", board.getGrid()[0, 2], Color.BLACK));
            board.getGrid()[0, 5].setPiece(new Cheval("C", board.getGrid()[0, 5], Color.BLACK));

            blackPiece['C'].Add(board.getGrid()[0, 2].getPiece());
            blackPiece['C'].Add(board.getGrid()[0, 5].getPiece());

            board.getGrid()[0, 3].setPiece(new Roi("K", board.getGrid()[0, 3], Color.BLACK));
            blackPiece['K'].Add(board.getGrid()[0, 3].getPiece());

            board.getGrid()[0, 4].setPiece(new Reine("Q", board.getGrid()[0, 4], Color.BLACK));
            blackPiece['Q'].Add(board.getGrid()[0, 4].getPiece());



        }
        


        public void run()
        {
            while (true)
            {
                controlWhite.keyboard();
               

               
                if (rule.stalemate(Color.WHITE) || rule.win(Color.WHITE)) { break; }
                if(rule.check(Color.WHITE).Count>0) 
                { 
                    foreach(PieceBase piece in rule.check(Color.WHITE)) { piece.afficherMouvement(board, blackPiece['K'][0].getPosition()); }
                    windows.write("Échec Noir"); 
                }

                controlBlack.keyboard();
                
                if (rule.stalemate(Color.BLACK) || rule.win(Color.BLACK)) { break; }
                if (rule.check(Color.BLACK).Count > 0)
                {
                    foreach (PieceBase piece in rule.check(Color.BLACK)) { piece.afficherMouvement(board, whitePiece['K'][0].getPosition()); }
                    windows.write("Échec Blanc");
                }
            }
        }
    

        public static void colorFront(Color color)
        {

            if (color == Color.BLACK) { Console.ForegroundColor = ConsoleColor.Black; }
            else { Console.ForegroundColor = ConsoleColor.White; }

        } 
    }
}
