using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess.Piece
{
    internal class Fou : PieceBase
    {
        public Fou(string name, Case pos, Color color) : base(name, pos, color)
        {
        }

        
        public override List<(int, int)> mouvement()
        {
            List<(int,int)> list = new List<(int, int)>();

            int x = position.getIndex()[0];
            int y = position.getIndex()[1];

            for (int i = 1; i < 8; i++) {
                int[,] index = new int[,] { {-i,-i},{-i,i},{ i,-i},{ i,i} };

                for(int j=0; j<4;j++)
                {
                    int nx=index[j,0]+x;
                    int ny=index[j,1]+y;

                    if ((0 <= nx && nx<8)&& (0 <= ny && ny < 8)) {

                        list.Add((nx,ny));
                    }
                }
            }

            return list;
        }

        public override List<(int, int)> mouvementGrid(Grid grid)
        {
            List<(int, int)> list = new List<(int, int)>();
            int x = position.getIndex()[0];
            int y = position.getIndex()[1];
            
            int[,] index = new int[,] { { 1, 1 }, { -1, -1 }, { -1, 1 }, { 1, -1 } };
            int nx;
            int ny;

            for (int j = 0; j < 4; j++)
            {
                nx = index[j, 0] + x;
                ny = index[j, 1] + y;

                while ((0 <= nx && nx < 8) && (0 <= ny && ny < 8))
                {

                    if (!grid.getGrid()[nx, ny].empty())
                    {
                        if (grid.getGrid()[nx, ny].getPiece().GetColor() != color) { list.Add((nx, ny)); }

                        break;
                    }
                    list.Add((nx, ny));
                    nx += index[j, 0];
                    ny += index[j, 1];

                }
            }
            return list;
        }

        public override List<(int, int)> MouvementToCase(Case next, Grid grid)
        {
          

            List<(int, int)> list = new List<(int, int)>();
            int x = position.getIndex()[0];
            int y = position.getIndex()[1];

            int[,] index = new int[,] { { 1, 1 }, { -1, -1 }, { -1, 1 }, { 1, -1 } };
            int nx;
            int ny;

            for (int j = 0; j < 4; j++)
            {
                nx = index[j, 0] + x;
                ny = index[j, 1] + y;

                while ((0 <= nx && nx < 8) && (0 <= ny && ny < 8))
                {

                    if (!grid.getGrid()[nx, ny].empty())
                    {
                        if (grid.getGrid()[nx, ny].getPiece().GetColor() != color) { list.Add((nx, ny)); }

                        if (next == grid.getGrid()[nx, ny])
                        {
                            return list;
                        }
                    }
                    list.Add((nx, ny));

                    if (next == grid.getGrid()[nx, ny])
                    {
                        return list;
                    }
                    nx += index[j, 0];
                    ny += index[j, 1];

                }
                list.Clear();
            }

            return null;

        }
    }
    
}
