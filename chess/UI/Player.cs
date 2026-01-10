using chess.UI;

namespace chess
{
    internal class Player
    {
        protected Color color;
        protected Control control;
        public Player(Color c,  ConsoleUI console)
        {
            color = c;
            control = new Control(console, c);
        }

        public virtual Move play(GameState state) 
        { 
            return control.keyboard(state);
        }
    }
}
