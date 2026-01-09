using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess.UI.pieceUI
{
    internal class RoiUI : PieceUI
    {
        public RoiUI(String name, CaseUI pos, Color color) : base(name, pos, color)
        {
            symbole = "K";
        }
    }
}
