using System;

namespace chess.UI
{
    internal class Control
    {
        Stack<CaseUI> cases;
        Color color;
        int[] origin;

        
        BoardUI board;
        ConsoleUI console;
        public Control(ConsoleUI console,Color c)
        {
            color = c;
            origin = new int[]{ 0, 0 };
            cases = new Stack<CaseUI>();
           
            this.board = console.board;
            this.console = console;
        }

        public void selectionner()
        {
            if (!cases.First().allumeSecondaire) { cases.First().clear(); }
            else { cases.First().sousSelection(); }


            board[origin[0], origin[1]].selectionner();
            cases.Push(board[origin[0], origin[1]]);

        }

        public Move keyboard(GameState state)
        {
            CaseUI select = null;
            cases.Push(board[origin[0], origin[1]]);

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.UpArrow)
                {

                    if (origin[0] > 0) { origin[0]--; }

                    selectionner();
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {

                    if (origin[0] < 7) { origin[0]++; }

                    selectionner();
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {

                    if (origin[1] > 0) { origin[1]--; }
                    selectionner();
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {

                    if (origin[1] < 7) { origin[1]++; }
                    selectionner();
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                   
                    if(select == null)
                    {
                        if(board[origin[0], origin[1]].empty()) { continue; }
                        if(board[origin[0], origin[1]].piece.color != color) { continue; }

                        cases.Pop();

                        select = board[origin[0], origin[1]];
                        List<PieceBase> pieces = state.GenerateLegalPiece();
                        PieceBase piece = console.isLegalPiece(pieces, select.piece);
                        if(piece != null)
                        {
                            console.afficherMouvement(state.GenerateLegalMoveWithPiece(piece));
                        }
                            
                    }

                    else if(select == board[origin[0], origin[1]])
                    {
                        select = null;
                        board.clear();
                        cases.Push(board[origin[0], origin[1]]);
                        
                    }
                    else if(state.isLegalMove(new Move((select.row,select.col),(origin[0], origin[1]))))
                    {
                        select.piece.move(board[origin[0], origin[1]]);
                        board.clear();

                        return new Move((select.row, select.col), (origin[0], origin[1]));
                    }


                }
            }

        }

        public void agentMove(GameState state,Move move)
        {
            (int row, int col) from = move.From;
            (int row, int col) to = move.To;
            board[from.row, from.col].piece.move(board[to.row, to.col]);
            Console.Write(board[to.row,to.col]);
        }

        public void mouse()
        {

        }
    }
}
