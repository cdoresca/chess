using chess.IA;
using chess.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal class Agent : Player
    {
        Mode mode;
        public Agent(Color c, ConsoleUI console, Mode m) : base(c, console)
        {
            mode = m;
        }

        public override Move play(GameState state)
        {
            Move move = mode.decision(state);
            control.agentMove(state,move);
            return move;    
        }
    }
}
