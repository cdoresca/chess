using chess.Piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess.IA
{
    internal abstract class Mode
    {
       protected  Color color;

        public Mode(Color color) { this.color = color; }
        protected bool terminal(GameState state,int depth)
        {
            if (depth == 0)
                return true;

            return state.checkmate(color) ||
                state.stalemate(color) ||
                state.checkmate(Game.opponent(color))||
                state.GenerateLegalMove().Count == 0;

        }

        protected int utilityScore(GameState state)
        {
            if (state.checkmate(color)) return -1;
            if (state.checkmate(Game.opponent(color))) return 1;
            return 0;

        }

        public abstract Move decision(GameState state);
        
    }

}

