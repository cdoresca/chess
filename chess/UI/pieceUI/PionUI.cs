using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess.UI.pieceUI
{
    internal class PionUI:PieceUI
    {
        public PionUI(String name, CaseUI pos, Color color) : base(name, pos, color)
        {
            symbole = "P";
        
        }
        public override string ToString()
        {
            int rowEnd = color == Color.WHITE ? 0 : 7;
             if(rowEnd == position.row) symbole = "Q";
            Game.colorFront(color);
            return symbole;
        }
    }
}
