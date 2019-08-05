namespace checkers_bot
{
    public class PossibleMoves
    {
        public CellPoint InitialPoint { get; set; }

        public CheckerMove[] Moves { get; set; }

        public int Weight { get; set; }
    }
}
