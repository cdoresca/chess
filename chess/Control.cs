using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace chess
{
    internal class Control
    {

        Grid grid;
      
        Stack<Case> cases;

        Color color;

        RuleGame rule;

        int[] origin;

        public Control(Grid grid,Color color,RuleGame rule) 
        { 
            this.grid = grid;
            
            this.rule = rule;

            this.color = color;

            origin = new int[] { 0, 0 };

           
            
            
            cases = new Stack<Case>();  
        }

      

        public void selectionner()
        {
            if (!cases.First().getAllumeSecondare()) { cases.First().clear(); }
            else { cases.First().sousSelection();}
           
                
                grid.getGrid()[origin[0], origin[1]].selectionner();
                cases.Push(grid.getGrid()[origin[0], origin[1]]);
            
        }

        public void keyboard()
        {
            Case select = null;
            cases.Push(grid.getGrid()[origin[0], origin[1]]);

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    
                    if (origin[0] > 0) { origin[0]--; }
                    
                   selectionner();
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    
                    if (origin[0] < 7) { origin[0]++; }

                    selectionner();
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    
                    if (origin[1] > 0) { origin[1]--; }
                    selectionner();
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    
                    if (origin[1] < 7) { origin[1]++; }
                    selectionner();
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    
                    if (select == null)
                    {
                        if(grid.getGrid()[origin[0], origin[1]].empty()) { continue; }
                        if (grid.getGrid()[origin[0], origin[1]].getPiece().GetColor() != color) { continue; }
                       
                        cases.Pop();
                        
                        select = grid.getGrid()[origin[0], origin[1]];
                        if(rule.legalPiece(color==Color.WHITE?Color.BLACK:Color.WHITE).Contains(select.getPiece()))
                            grid.getGrid()[origin[0], origin[1]].getPiece().afficherMouvement(grid);
                    }

                    else if (select == grid.getGrid()[origin[0], origin[1]])
                    {
                        select = null;
                        grid.clear();
                        cases.Push(grid.getGrid()[origin[0], origin[1]]);
                    }
                    else if(select.getPiece().move(grid.getGrid()[origin[0], origin[1]], grid))
                    {
                       
                        select = null;
                        grid.clear();
                        break;
                    }

                    
                }
            }

        }

        public void mouse()
        {

        }
    }
}
