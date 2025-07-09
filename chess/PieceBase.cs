using chess.Piece;
using static System.Net.Mime.MediaTypeNames;

namespace chess
{
    enum Color {WHITE, BLACK }
    internal abstract class PieceBase
    {
        protected string name;
        protected Case position;

        protected Color color;

        bool alive;
       
        public PieceBase(string name, Case pos, Color color)
        {
            this.name = name;
            position = pos;
            this.color = color;
            alive = true;
        }

        public  override string ToString() { Game.colorFront(color); return name; }

        public abstract List<(int, int)> mouvement();

        public virtual bool  move(Case next,Grid grid)
        {
            if (contains(next, grid))
            {
                position.setPiece(null);
                Console.Write(position);

                if (!next.empty()) { next.getPiece().setAlive(false); }

                next.setPiece(this);

                position = next;
                Console.Write(position);
               
                   return true;
            }
            return false;
            
        }

      

        public abstract List<(int, int)> mouvementGrid(Grid grid);

        public Color GetColor() { return color; }

        public bool contains(Case next,Grid grid)
        {
            foreach (var (i, j) in mouvementGrid(grid))
            {

                if (next == grid.getGrid()[i, j]) {
                    return true; }
            }
            return false;

        }

        public bool contains(PieceBase piece, Grid grid)
        {
            List<(int,int)>pos = piece.mouvementGrid(grid);
            pos.Add((piece.getPosition().getIndex()[0], piece.getPosition().getIndex()[1]));
            foreach (var (i, j) in mouvementGrid(grid))
            {
                foreach(var (x, y) in pos) {
                    if (grid.getGrid()[x, y] == grid.getGrid()[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        public bool contains(PieceBase piece,Case next ,Grid grid)
        {
            List<(int, int)> pos = piece.MouvementToCase(next,grid);
            pos.Add((piece.getPosition().getIndex()[0], piece.getPosition().getIndex()[1]));
            foreach (var (i, j) in mouvementGrid(grid))
            {
                foreach (var (x, y) in pos)
                {
                    if (grid.getGrid()[x, y] == grid.getGrid()[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        public void afficherMouvement(Grid grid,Case next=null)
        {

            if (next == null)
            {
                foreach (var (i, j) in mouvementGrid(grid))
                {
                    grid.getGrid()[i, j].sousSelection();
                }
            }
            else
            {
                foreach (var (i, j) in MouvementToCase(next, grid))
                {
                    grid.getGrid()[i, j].sousSelection();
                }
            }
        }

        public bool getAlive() {  return alive; }

        public void setAlive(bool alive) { this.alive = alive; }

        public Case getPosition() { return position; }

        public void setPosition(Case next) {  this.position = next; }

        public abstract List<(int,int)> MouvementToCase(Case next,Grid grid);
        

        
    }
}
