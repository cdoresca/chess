namespace chess.UI
{
    internal class Player
    {
        Color color;
        Control control;
        public Player(Color c,  ConsoleUI console)
        {
            color = c;
            control = new Control(console, c);
        }

        public Move play(GameState state) 
        { 
            return control.keyboard(state);
        }
    }
}
