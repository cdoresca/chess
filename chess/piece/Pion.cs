using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess;

namespace chess.Piece
{
    internal class Pion : PieceBase
    {
        public Pion(string name, Case pos,Color color) : base(name, pos,color)
        {
        }

        public override List<(int, int)> mouvementGrid(Grid box)
        {
            List<(int, int)> list = new List<(int, int)>();
            int x = position.getIndex()[0];
            int y = position.getIndex()[1];

            foreach(var (i,j) in mouvement()){

                if ((i == x-1 || i == x + 1) && j==y && box.getGrid()[i,j].empty())
                {
                    list.Add((i,j));
                }
                else if (j!=y && !box.getGrid()[i, j].empty()) { 

                    if(box.getGrid()[i, j].getPiece().GetColor()!=color){ 
                        list.Add((i, j)); }
                }
                else if ((i == x - 2 || i == x + 2) && box.getGrid()[i, j].empty())
                {
                    list.Add((i, j));
                }
            }
            return list;
        }

        public override List<(int, int)> mouvement()
        {
            List < (int,int) > list = new List<(int, int)>();

            int x = position.getIndex()[0];
            int y = position.getIndex()[1];

            if (color == Color.WHITE)
            {
                if(x< 7) {

                    list.Add((x-1,y));

                    if (x == 6) { list.Add(( x - 2, y )); }
                }

                if (y>0) { 
                    list.Add(( x - 1, y-1 ));
                }
                if(y<7)
                {
                    list.Add(( x - 1, y + 1));
                }
            } 
            if (color == Color.BLACK)
            {
                if(x > 0) {

                    list.Add((x+1,y));

                    if (x == 1) { list.Add( (x + 2, y) ); }
                }

                if (y>0) { 
                    list.Add( (x + 1, y-1 ));
                }
                if(y<7)
                {
                    list.Add( (x + 1, y + 1));
                }
            }
           
            return list;
        }

        

        public override List<(int, int)> MouvementToCase(Case next,Grid box)
        {
           
            int x = position.getIndex()[0];
            int y = position.getIndex()[1];

            foreach (var (i, j) in mouvement())
            {

                if ((i == x - 1 || i == x + 1) && j == y && box.getGrid()[i, j].empty())
                {
                   return [(i, j)];
                }
                else if (j != y && !box.getGrid()[i, j].empty())
                {

                    if (box.getGrid()[i, j].getPiece().GetColor() != color)
                    {
                        return[(i, j)];
                    }
                }
                else if ((i == x - 2 || i == x + 2) && box.getGrid()[i, j].empty())
                {
                    return i == x - 2?[(i-1,j),(i, j)]: [(i + 1, j), (i, j)];
                }
            }

            return null;

        }
    }
}
