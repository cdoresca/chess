namespace chess.Piece
{
    internal class Pion : PieceBase
    {
        int dir;

    
        public Pion(string name, (int row, int col) pos, Color color, bool life = true) : base(name, pos, color, life)
        {
            dir = color == Color.WHITE ? -1 : 1;
            
        }


        public override List<(int, int)> generateMove(GameState state)
        {
            List<(int, int)> list = new List<(int, int)>();
            foreach ((int row, int col) pos in straight())
            {
                if (state.board.grid[pos.row, pos.col].empty())
                    list.Add((pos.row, pos.col));

                if (!state.board.grid[pos.row, pos.col].empty()) break;

            }

            foreach ((int row, int col) pos in kill())
            {
                if (!state.board.grid[pos.row, pos.col].empty() && color != state.board.grid[pos.row, pos.col].piece.color)
                    list.Add((pos.row, pos.col));
            }

            return list;
        }

        private List<(int, int)> straight()
        {
            List<(int, int)> list = new List<(int, int)>();

            int row = position.row;
            int col = position.col;


            int oneStep = row + dir;
            if (oneStep >= 0 && oneStep < 8) list.Add((oneStep, col));

            int start = color == Color.WHITE ? 6 : 1;
            if (start != row) return list;
            int twoStep = row + 2 * dir;
            list.Add((twoStep, col));



            return list;
        }

        private List<(int, int)> kill()
        {
            List<(int, int)> list = new List<(int, int)>();

            int row = position.row;
            int col = position.col;

            int nextRow = row + dir;

            if (nextRow < 0 || nextRow > 7)
                return list;

            if (col > 0)
            {
                list.Add((nextRow, col - 1));
            }
            if (col < 7)
            {
                list.Add((nextRow, col + 1));
            }


            return list;
        }

        public override PieceBase cloneWith(Move move)
        {
            (int row, int col) pos = move.To;

            int rowEnd = color == Color.WHITE ? 0 : 7;

            if(rowEnd == pos.row) return new Reine(name, pos, color);

            return new Pion(name, pos, color, alive);
        }

        public override PieceBase clone()
        {
            return new Pion(name, position, color, alive);
        }
    }
}
