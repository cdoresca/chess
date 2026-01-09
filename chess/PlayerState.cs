using chess.Piece;

namespace chess
{
    internal class PlayerState
    {
        public List<PieceBase> pieces { get; }
        public Roi roi { get; }

        public PlayerState(List<PieceBase> p)
        {
            pieces = p;
            roi = pieces.OfType<Roi>().First();
        }
        public PlayerState clone()
        {
            List<PieceBase> newPieces = new List<PieceBase>();

            for (int i = 0; i < pieces.Count; i++)
            {
                newPieces.Add(pieces[i].clone());
            }
            return new PlayerState(newPieces);
        }


        public void UpdatePiece(PieceBase updated)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                if (pieces[i].name == updated.name)
                {
                    pieces[i] = updated;
                    return;
                }
            }

        }
    }

}
