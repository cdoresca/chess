namespace chess.Piece
{
    internal class Reine : PieceBase
    {

        public Reine(string name, (int, int) pos, Color color, bool life = true) : base(name, pos, color, life)
        {

        }

        public override PieceBase clone()
        {
            return new Reine(name, position, color, alive);
        }

        public override PieceBase cloneWith(Move move)
        {
            (int row, int col) pos = move.To;
            return new Reine(name, pos, color, alive);
        }

        public override List<(int, int)> generateMove(GameState state)
        {
            List<(int, int)> list = new List<(int, int)>();
            int row = position.row;
            int col = position.col;

            int[,] index = new int[,] { { 1, 1 }, { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            int nx;
            int ny;

            for (int j = 0; j < 8; j++)
            {
                nx = index[j, 0] + row;
                ny = index[j, 1] + col;

                while ((0 <= nx && nx < 8) && (0 <= ny && ny < 8))
                {

                    if (!state.board.grid[nx, ny].empty())
                    {
                        if (state.board.grid[nx, ny].piece.color != color) { list.Add((nx, ny)); }

                        break;
                    }
                    list.Add((nx, ny));
                    nx += index[j, 0];
                    ny += index[j, 1];

                }
            }
            return list;
        }

    }
}
