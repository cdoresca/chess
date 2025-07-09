using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess.Piece;

namespace chess.piece
{
    internal class Cheval : PieceBase
    {
        public Cheval(string name, Case pos, Color color) : base(name, pos, color)
        {
        }

        public override List<(int, int)> mouvement()
        {
            List<(int, int)> list = new List<(int, int)>();

            int x = position.getIndex()[0];
            int y = position.getIndex()[1];

            int[,] index = new int[,] { { 2, 1 }, { 2, -1 }, { -2, 1 }, { -2, -1 }, { 1, 2 }, { 1, -2 }, { -1, 2 }, { -1, -2 } };
            int nx;
            int ny;

            for (int j = 0; j < 8; j++)
            {
                 nx = index[j, 0] + x;
                ny = index[j, 1] + y;

                if ((0 <= nx && nx < 8) && (0 <= ny && ny < 8))
                {

                    list.Add((nx, ny));
                }

            }
            return list;
        }

        public override List<(int, int)> mouvementGrid(Grid grid)
        {
            List<(int, int)> list = new List<(int, int)>();
            int x = position.getIndex()[0];
            int y = position.getIndex()[1];

            foreach (var (i, j) in mouvement())
            {
                if (grid.getGrid()[i, j].empty()) { list.Add((i, j)); }

                else if (grid.getGrid()[i, j].getPiece().GetColor() != color) { list.Add((i, j)); }

            }
            return list;

        }

        public override List<(int, int)> MouvementToCase(Case next, Grid grid)
        {
            List<(int, int)> list = new List<(int, int)>();
            int x = position.getIndex()[0];
            int y = position.getIndex()[1];

            foreach (var (i, j) in mouvementGrid(grid))
            {
                if (grid.getGrid()[i, j]==next) { list.Add((i, j)); return list; }

            }
            return null;
        }
    }
}
