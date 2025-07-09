using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal class Grid
    {
        int width, height;
        Case[,] grid;
        public Grid(int width = 8, int height = 8)
        {
            this.width = width;
            this.height = height;

            board();
            Console.WriteLine(this);
        }

        public Case[,] getGrid() {  return grid; }
        private void board()
        {
            grid = new Case[height,width];

            char col = 'A';
            int x = 2;
            int y = 2;

            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    grid[i,j] = new Case(i+1,col,x,y);
                    col++;
                    x += 4;
                }
                col = 'A';
                x = 2;
                y++; 
            }
        }

        public override string ToString()
        {
            string draw = entete_row(width);
            draw += entete(width);

            for (int i = 0; i < height; i++) {
                draw += i+1+"|";
                for(int j = 0; j < width; j++)
                {
                    draw += "   " + "|";
                }
                draw += "\n";
            }
            draw += entete(width);
            return draw;
        }

        private string entete_row(int column)
        {
            string draw = " | ";
            char col = 'A';
            for (int i = 0; i < width; i++)
            {
                
                draw +=col+" | ";
                col++;
            }
            draw += "\n";
            return draw;
        }

        private string entete(int column)
        {
            string draw = "  ";
            
            for (int i = 0; i < width; i++)
            {

                draw += " -- ";
                
            }
            draw += "\n";
            return draw;
        }
        public void afficherPion()
        {
            foreach (Case i in grid)
            {
                 Console.SetCursorPosition(i.getCurseur()[0], i.getCurseur()[1]);
                Console.Write(i.ToString());
            }
        }

        public void clear()
        {
            foreach (Case i in grid)
            {
                if (i.getAllume()||i.getAllumeSecondare())
                {
                    i.clear();
                }
            }
        }


    }
}
