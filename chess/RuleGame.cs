using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess.Piece;

namespace chess
{
    internal class RuleGame
    {
        Grid board;

        Dictionary<char, List<PieceBase>> white;
        Dictionary<char, List<PieceBase>> black;

        Windows windows;

        public RuleGame(Grid grid,Windows windows, Dictionary<char, List<PieceBase>> black, Dictionary<char, List<PieceBase>> white) { 
            this.board = grid;
            this.windows=windows;
            this.white = white;
            this.black = black;
        }

        public HashSet<PieceBase> check(Color color) 
        {
            Dictionary<char, List<PieceBase>> attack = color == Color.WHITE ? white : black;
            Dictionary<char, List<PieceBase>>  defense = color == Color.WHITE ? black : white;
            HashSet<PieceBase> enemy = new HashSet<PieceBase>();    

            foreach(List<PieceBase> pieces in attack.Values )
            {
                foreach (PieceBase piece in pieces) {
                    if (piece.contains(defense['K'][0].getPosition(), board) && piece.getAlive()) 
                    {
                        
                       
                        enemy.Add(piece);
                    }
                }
            }


            return enemy;
           
        }

        public bool win(Color color)
        {
            if(check(color).Count > 0 && mate(color) && legalPiece(color).Count == 0) 
            {
                windows.write("Échec et Mat");
                return true;
            }
          return false;
        }

       

        public bool stalemate(Color color)
        {
            
            if (mate(color) && legalPiece(color).Count==0) 
            {
                windows.write("stalemate");
                return true;
            }
            return false;
        } 
        
        public bool mate(Color color)
        {
            Dictionary<char, List<PieceBase>> attack = color == Color.WHITE ? white : black;
            Dictionary<char, List<PieceBase>> defense = color == Color.WHITE ? black : white;

            List<(int, int)> casesRoi = defense['K'][0].mouvementGrid(board);

            bool[] tmp = new bool[casesRoi.Count];
            

           
            int cpt = 0;
           
            
            foreach (List<PieceBase> pieces in attack.Values)
            {
                foreach (PieceBase piece in pieces)
                {
                    if (piece.contains(defense['K'][0], board))
                    {
                        tmp[cpt] = true;
                           
                    }
                }
            }
            cpt++;
            


            

            return tmp.All(x => x);  
        }

        public HashSet<PieceBase> legalPiece(Color color) 
        {
            Dictionary<char, List<PieceBase>> attack = color == Color.WHITE ? white : black;
            Dictionary<char, List<PieceBase>> defense = color == Color.WHITE ? black : white;
            HashSet<PieceBase> action = new HashSet<PieceBase>();

            HashSet<PieceBase> tmp=check(color);

            bool[] oth = new bool[tmp.Count];
            Case posRoi;
            Case pos;

            if (tmp.Count > 0)
            {
                posRoi = defense['K'][0].getPosition();
                int cpt=0;
                
                foreach (PieceBase enemy in tmp)
                {
                    foreach (List<PieceBase> pieces in defense.Values)
                    {
                        foreach (PieceBase piece in pieces)
                        {
                            if (piece.contains(enemy, posRoi,board) && piece.getAlive()) 
                            { 
                                action.Add(piece); 
                            }
                        }
                    }
                    
                    foreach (var (i,j) in defense['K'][0].mouvementGrid(board))
                    {

                        defense['K'][0].setPosition(board.getGrid()[i,j]);
                        if (check(color).Count == 0) { oth[cpt] = true; }
                    }
                    defense['K'][0].setPosition(posRoi);
                    cpt++;
                }
                if (oth.All(x => x)) { action.Add(defense['K'][0]); }
            }
            else
            {
                foreach (List<PieceBase> pieces in defense.Values)
                {
                    foreach (PieceBase piece in pieces)
                    {
                        piece.setAlive(false);
                        if(check(color).Count > 0)
                        {
                            piece.setAlive(true);
                            continue;
                        }

                        piece.setAlive(true); 

                        if (piece.mouvementGrid(board).Count > 0 && piece.getAlive()) action.Add(piece);
                        
                    }
                }
            }
            return action;
        }
    }
}
