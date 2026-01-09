namespace chess.Piece
{
    internal class Cheval : PieceBase
    {
        public Cheval(string name, (int, int) pos, Color color, bool life = true) : base(name, pos, color, life)
        {
        }

        public override PieceBase clone()
        {
            return new Cheval(name, position, color, alive);
        }

        public override PieceBase cloneWith(Move move)
        {
            (int row, int col) pos = move.To;
            return new Cheval(name, pos, color, alive);
        }

        public override List<(int, int)> generateMove(GameState state)
        {
            List<(int, int)> list = new List<(int, int)>();
            foreach ((int row, int col) pos in mouvement())
            {
                if (state.board.grid[pos.row, pos.col].empty() ||
                    (!state.board.grid[pos.row, pos.col].empty()
                    && color != state.board.grid[pos.row, pos.col].piece.color))
                    list.Add((pos.row, pos.col));
            }
            return list;
        }

        private List<(int, int)> mouvement()
        {
            List<(int, int)> list = new List<(int, int)>();

            int row = position.row;
            int col = position.col;

            int[,] index = { { 2, 1 }, { 2, -1 }, { -2, 1 }, { -2, -1 }, { 1, 2 }, { 1, -2 }, { -1, 2 }, { -1, -2 } };
            int nx;
            int ny;

            for (int j = 0; j < 8; j++)
            {
                nx = index[j, 0] + row;
                ny = index[j, 1] + col;

                if ((0 <= nx && nx < 8) && (0 <= ny && ny < 8))
                {

                    list.Add((nx, ny));
                }

            }
            return list;
        }

    }
}
