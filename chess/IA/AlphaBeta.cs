using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace chess.IA
{
    internal class AlphaBeta : Mode
    {
        public AlphaBeta(Color color):base(color) { }
        public override Move decision(GameState state)
        {
            return maxValue(state, int.MinValue, int.MaxValue,3).Item2;
        }

        (int, Move) maxValue(GameState state, int alpha, int beta,int depth)
        {
            Move best = null;
            if (terminal(state, depth))
                return (utilityScore(state), best);
      

            int score = int.MinValue;

            foreach ((Move move, GameState nextState) in state.Successors())
            {
                int value = minValue(nextState, alpha, beta, depth-1).Item1;
                if (value > score)
                {
                    score = value;
                    best = move;
                }
                if (score > beta) return (score, best);
                alpha = Math.Max(alpha, score);
            }
            return (score, best);
        }

        (int, Move) minValue(GameState state, int alpha, int beta,int depth)
        {
            Move best = null;
            if (terminal(state, depth))
                return (utilityScore(state), best);
            



            int score = int.MaxValue;

            foreach ((Move move, GameState nextState) in state.Successors())
            {
                int value = maxValue(nextState, alpha, beta,depth-1).Item1;
                if (value < score)
                {
                    score = value;
                    best = move;
                }
                if (score < alpha) return (score, best);
                beta = Math.Min(beta, score);
            }
            return (score, best);
        }
    }
}
