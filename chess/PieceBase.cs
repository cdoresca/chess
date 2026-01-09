namespace chess
{
    enum Color { WHITE, BLACK }
    internal abstract class PieceBase
    {
        public string name { get; }
        public (int row, int col) position { get; }
        public Color color { get; }
        public bool alive { get; }

        public PieceBase(string name, (int row, int col) pos, Color color, bool life = true)
        {
            this.name = name;
            position = pos;
            this.color = color;
            alive = true;
        }

        public abstract PieceBase cloneWith(Move move);
        public abstract PieceBase clone();

        public abstract List<(int, int)> generateMove(GameState state);


    }
}
