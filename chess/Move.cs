namespace chess
{
    internal class Move
    {
        public (int row, int col) From { get; }
        public (int row, int col) To { get; }

        public Move((int row, int col) from, (int row, int col) to)
        {
            From = from;
            To = to;

        }

        public override bool Equals(object? obj)
        {
            if (obj is Move other)
                return From == other.From && To == other.To;

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(From, To);
        }

    }
}
