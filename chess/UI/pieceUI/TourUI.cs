using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess.UI.pieceUI
{
    internal class TourUI : PieceUI
    {
        public TourUI(String name, CaseUI pos, Color color) : base(name, pos, color)
        {

            symbole = "T";
        }
    }
}
