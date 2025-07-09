using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess.util;

namespace chess.Piece
{
    internal class Reine : PieceBase
    {
        Fou fou;
        Tour tour;
        public Reine(string name, Case pos, Color color) : base(name, pos, color)
        {
            fou = new Fou(name, pos, color);
            tour = new Tour(name, pos, color);
        }

        public override List<(int, int)> mouvement()
        {
            List<(int, int)> list = new List<(int, int)>();
            list.AddRange(fou.mouvement());
            list.AddRange(tour.mouvement());
            return list;
        }

        public override List<(int, int)> mouvementGrid(Grid grid)
        {
            List<(int, int)> list = new List<(int, int)>();
            list.AddRange(fou.mouvementGrid(grid));
            list.AddRange(tour.mouvementGrid(grid));
            return list;
        }

        public override List<(int, int)> MouvementToCase(Case next, Grid grid)
        {
            List<(int,int)> fouList = fou.MouvementToCase(next, grid);
            List<(int,int)> tourList = tour.MouvementToCase(next, grid);

            return fouList != null ? fouList : tourList != null ? tourList : null;
        }

        public override bool move(Case next, Grid grid)
        {
            if (contains(next, grid))
            {
                position.setPiece(null);
                Console.Write(position);

                if (!next.empty()) { next.getPiece().setAlive(false); }

                next.setPiece(this);

                position = next;
                Console.Write(position);


                fou.setPosition(next);
                tour.setPosition(next);


                return true;
            }
            return false;
        }
    }
}
