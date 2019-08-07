using System.Linq;

namespace checkers_bot
{
    public class PossibleMoves
    {
        public CellPoint InitialPoint { get; set; }

        public CheckerMove[] Moves { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return Moves.Aggregate(" ",
                (x, y) => $"{x} -> ({y.FromPoint.X},{y.FromPoint.Y}) -> ({y.ToPoint.X},{y.ToPoint.Y}) ");
        }
    }
}
