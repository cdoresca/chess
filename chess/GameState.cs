namespace chess
{
    internal class GameState
    {
        public Board board { get; set; }
        public PlayerState white { get; set; }
        public PlayerState black { get; set; }
        public Color turn { get; set; }
        public GameState(Board board, PlayerState white, PlayerState black, Color turn)
        {
            this.board = board;
            this.white = white;
            this.black = black;
            this.turn = turn;
        }

        public GameState ApplyMove(Move move)
        {
            (int row, int col) from = move.From;
            (int row, int col) to = move.To;

            GameState newState = clone();
           

            PieceBase newPiece = newState.board.grid[from.row, from.col].piece.cloneWith(move);

            newState.board = newState.board.CloneWithMove(move, newPiece);
            

            newState.turn = turn == Color.WHITE ? Color.BLACK : Color.WHITE;

            newState.getPlayer(turn).UpdatePiece(newPiece);
            newState.getPlayer(Game.opponent(turn)).RemovePiece(newPiece);

            return newState;
        }

        public GameState clone()
        {

            return new GameState(board.clone(), white.clone(), black.clone(), turn);
        }

        public bool check(Color color)
        {
            PlayerState defense = color == Color.WHITE ? white : black;
            PlayerState attack = color == Color.WHITE ? black : white;

            foreach (PieceBase piece in attack.pieces)
            {
                if (!piece.alive)
                    continue;

                foreach ((int row, int col) pos in piece.generateMove(this))
                {
                    if (pos == defense.roi.position) return true;

                }
            }
            return false;
        }

        public List<PieceBase> GenerateLegalPiece()
        {
            PlayerState player = getPlayer(turn);

            List<PieceBase> pieces = new List<PieceBase>();

            foreach (PieceBase piece in player.pieces)
            {
                bool hasLegalMove = false;

                if (!piece.alive) continue;
                foreach ((int row, int col) to in piece.generateMove(this))
                {
                    Move move = new Move(piece.position, to);

                    GameState newState = this.ApplyMove(move);
                    if (!newState.check(turn))
                    {
                        hasLegalMove = true;
                        break;
                    }
                }
                if (hasLegalMove) pieces.Add(piece);
            }
            return pieces;
        }

        public bool checkmate(Color color)
        {
            if (!check(color))
                return false;

            PlayerState defense = getPlayer(color);

            foreach (var piece in defense.pieces)
            {
                if (!piece.alive)
                    continue;

                foreach (var move in piece.generateMove(this))
                {
                    GameState newState = this.ApplyMove(new Move(piece.position, move));

                    if (!newState.check(color))
                        return false;
                }

            }
            return true;
        }

        public bool stalemate(Color color)
        {
            if (check(color))
                return false;

            PlayerState defense = getPlayer(color);

            foreach (var piece in defense.pieces)
            {
                if (!piece.alive)
                    continue;

                foreach (var move in piece.generateMove(this))
                {
                    GameState newState = this.ApplyMove(new Move(piece.position, move));

                    if (!newState.check(color))
                        return false;
                }

            }
            return true;

        }

        public List<Move> GenerateLegalMove()
        {

            PlayerState player = getPlayer(turn);

            List<Move> moves = new List<Move>();

            foreach (PieceBase piece in player.pieces)
            {
                if (!piece.alive) continue;
                foreach ((int row, int col) to in piece.generateMove(this))
                {
                    Move move = new Move(piece.position, to);

                    GameState newState = this.ApplyMove(move);
                    if (!newState.check(turn))
                    {
                        moves.Add(move);
                        
                    }
                }
            }
            return moves;
        }
        public List<Move> GenerateLegalMove(Color color)
        {

            PlayerState player = getPlayer(color);

            List<Move> moves = new List<Move>();

            foreach (PieceBase piece in player.pieces)
            {
                if (!piece.alive) continue;
                foreach ((int row, int col) to in piece.generateMove(this))
                {
                    Move move = new Move(piece.position, to);

                    GameState newState = this.ApplyMove(move);
                    if (!newState.check(color))
                    {
                        moves.Add(move);

                    }
                }
            }
            return moves;
        }
        public List<Move> GenerateLegalMoveWithPiece(PieceBase piece)
        {
            List<Move> moves = new List<Move>();

            foreach ((int row, int col) to in piece.generateMove(this))
            {
                Move move = new Move(piece.position, to);

                GameState newState = this.ApplyMove(move);
                if (!newState.check(turn))
                {
                    moves.Add(move);
                    
                }
            }
            return moves;
        }

        public List<(Move,GameState)> Successors()
        {
            List<(Move, GameState)> nextState = new List<(Move, GameState)>();

            foreach(var move in GenerateLegalMove())
            {
                nextState.Add((move,ApplyMove(move)));
            }
            return nextState;
        }

        public bool isLegalMove(Move move) { return GenerateLegalMove().Contains(move); }
        public PlayerState getPlayer(Color color) { return color == Color.WHITE ? white : black; }
    }
}
