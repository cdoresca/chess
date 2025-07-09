using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal class Case
    {
        char column;
        int row;
        int[] index;
        PieceBase piece;
        int[] posCurseur = new int[2];
        bool allume;
        bool allumeSecondaire;

       

        public Case(int rows,char columns,int x,int y) { 
            this.column = columns;
            this.row = rows;
            calculIndex();
            posCurseur=[x,y];
            allume = false;
            allumeSecondaire = false;
        }
        public override string ToString()
        {
            Console.SetCursorPosition(posCurseur[0], posCurseur[1]);
            return empty() ? "   ":" "+piece.ToString()+" ";
        }

        public void setPiece(PieceBase piece) {  this.piece = piece; }

        public bool empty() {  return piece == null; }

        private  void calculIndex() { index=new int[2] { row-1, column - 65 }; }

        public int getRow() { return row; }
        public int getColumn() { return column; }
        public int[] getIndex() { return index; }
        public PieceBase getPiece() { return piece; }
            
        public int[] getCurseur() {  return posCurseur; }

        public void selectionner() 
        { 
            allume=true;
            Console.BackgroundColor=ConsoleColor.DarkGreen;
            Console.Write(this);
            Console.BackgroundColor = ConsoleColor.DarkGray;
        }

        public void sousSelection() {

            allumeSecondaire = true;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write(this);
            Console.BackgroundColor = ConsoleColor.DarkGray;

        }

        public void clear() {
            allume=false;
            allumeSecondaire = false;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write(this);
        }

        public bool getAllume() { return allume; }

        public bool getAllumeSecondare() { return allumeSecondaire; }
        public void setAllumeSecondare(bool value) { allumeSecondaire=value; }
        
    }
}
