using System;

namespace chess.UI
{
    internal  class PieceUI
    {
        public String name { get; }
        protected String symbole;
        CaseUI position;
        public Color color { get; }
        bool alive {  get; set; }
        public PieceUI(String name, CaseUI pos,Color color,bool life = true) 
        {
            position = pos;
            this.color = color;
            this.name = name;
        }

        public override string ToString() { 
            Game.colorFront(color); 
            return symbole; 
        }
        public void move(CaseUI next, BoardUI grid)
        {
            position.setPiece(null);
            Console.Write(position);

            if (!next.empty()) { next.piece.alive = false; }

            next.setPiece(this);

            position = next;
        }

        

    }
}
