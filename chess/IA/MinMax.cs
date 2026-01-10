namespace chess.IA
{
    internal class MinMax:Mode
    {
        
        
        public MinMax(Color color) : base(color){  }

       (int, Move) maxValue(GameState state, int depth) 
        {
            Move best = null;
            if (terminal(state,depth)) 
                return (utilityScore(state),best);
           

            int score = int.MinValue;
            foreach ((Move move, GameState nextState) in state.Successors())
            {
                int value = minValue(nextState,depth-1).Item1;
                if (value > score)
                {
                    score = value;
                    best = move;
                }

            }
            return (score,best);
        }
        (int, Move) minValue(GameState state,int depth)
        {
            Move best = null;
            if (terminal(state,depth)) 
                return  (utilityScore(state), best);
            
            int score = int.MaxValue;
            foreach ((Move move, GameState nextState) in state.Successors())
            {
                int value = maxValue(nextState,depth-1).Item1;
                if (value < score)
                {
                    score = value;
                    best = move;
                }

            }
            return (score, best);
        }


        public override Move decision(GameState state)
        {

            return maxValue(state, 3).Item2;
        }
    }

}
