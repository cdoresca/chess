using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess.UI.pieceUI
{
    internal class FouUI:PieceUI
    {
        public FouUI(String name, CaseUI pos, Color color) : base(name, pos, color)
        {
            symbole = "F";
        }
    }
}
