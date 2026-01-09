namespace chess.Piece
{
    internal class Roi : PieceBase
    {
        public Roi(string name, (int, int) pos, Color color, bool life = true) : base(name, pos, color, life)
        {
        }

        private List<(int, int)> mouvement()
        {
            List<(int, int)> list = new List<(int, int)>();

            int row = position.row;
            int col = position.col;

            int[] index = { -1, 0, 1 };

            foreach (int i in index)
            {
                foreach (int j in index)
                {
                    if (i != 0 || j != 0)
                    {
                        int nx = i + row;
                        int ny = j + col;

                        if ((0 <= nx && nx < 8) && (0 <= ny && ny < 8))
                        {

                            list.Add((nx, ny));
                        }
                    }
                }
            }

            return list;
        }

        public override List<(int, int)> generateMove(GameState state)
        {
            List<(int, int)> list = new List<(int, int)>();


            foreach (var (i, j) in mouvement())
            {
                if (state.board.grid[i, j].empty()) { list.Add((i, j)); }
                if (!state.board.grid[i, j].empty())
                {
                    if (state.board.grid[i, j].piece.color != color)
                    {
                        list.Add((i, j));
                    }
                }
            }
            return list;
        }
        public override PieceBase cloneWith(Move move)
        {
            (int row, int col) pos = move.To;
            return new Roi(name, pos, color, alive);
        }

        public override PieceBase clone()
        {
            return new Roi(name, position, color, alive);
        }
    }
}
