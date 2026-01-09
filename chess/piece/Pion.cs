namespace chess.Piece
{
    internal class Pion : PieceBase
    {
        public Pion(string name, (int row, int col) pos, Color color, bool life = true) : base(name, pos, color, life)
        {
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

            int direction = color == Color.WHITE ? -1 : 1;

            int oneStep = row + direction;
            if (oneStep >= 0 && oneStep < 8) list.Add((oneStep, col));

            int start = color == Color.WHITE ? 6 : 1;
            if (start != row) return list;
            int twoStep = row + 2 * direction;
            list.Add((twoStep, col));



            return list;
        }

        private List<(int, int)> kill()
        {
            List<(int, int)> list = new List<(int, int)>();

            int row = position.row;
            int col = position.col;

            int direction = color == Color.WHITE ? -1 : 1;

            int nextRow = row + direction;

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
            return new Pion(name, pos, color, alive);
        }

        public override PieceBase clone()
        {
            return new Pion(name, position, color, alive);
        }
    }
}
