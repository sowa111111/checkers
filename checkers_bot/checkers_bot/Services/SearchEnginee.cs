using System.Collections.Generic;

namespace checkers_bot.Services
{
    public class SearchEnginee
    {
        public IEnumerable<PossibleMoves> SearchAllPossibleMoves(CheckerPayload data)
        {
            var possibleMoves = new List<PossibleMoves>();

            for (byte x = 0; x < 8; x++)
                for (byte y = 0; y < 8; y++)
                {
                    if (GetCellState(data.Field, x, y) != CellState.EmptyCell
                        && IsOurChecker(data.Team, GetCellState(data.Field, x, y)))
                    {

                    }
                }

            return possibleMoves;
        }

        private static CellState GetCellState(CellState[][] field, int x, int y)
            => field[y][x];

        private void CheckAttackMove(byte x, byte y, CellState[][] field, Team team)
        {
            var possibleDirection = new[]
            {
                (-1, -1),
                (-1, 1),
                (1, -1),
                (1, 1)
            };

            foreach (var direction in possibleDirection)
            {
                
            }
        }

        private void CheckAttackInSpecificDirection(
            byte x,
            byte y,
            int directionX,
            int directionY,
            CellState[][] field,
            Team team,
            List<CheckerMove> moves)
        {
            if (CellPoint.IsValidCellPoint(x + 1 * (directionX), y + 1 * (directionY))
                && CellPoint.IsValidCellPoint(x + 2 * (directionX), y + 2 * (directionY)))
            {
                if (IsEnemyChecker(GetCellState(field, x + 1 * (directionX), y + 1 * (directionY)), team)
                    && IsEmptyCell(GetCellState(field, x + 2 * (directionX), y + 2 * (directionY))))
                {
                    var checkerMove = new CheckerMove
                    {
                        FromPoint = new CellPoint(x, y),
                        ToPoint = new CellPoint((byte)(x + 2 * (directionX)), (byte)(y + 2 * (directionY)))
                    };
                    moves.Add(checkerMove);

                    var newField = RefreshField(field, x, y, directionX, directionY);

                    CheckAttackInSpecificDirection(
                        checkerMove.ToPoint.X,
                        checkerMove.ToPoint.Y,
                        directionX,
                        directionY,
                        newField,
                        team,
                        moves);
                }
            }
        }

        private CellState[][] RefreshField(
            CellState[][] field,
            byte x,
            byte y,
            int dirrectionX,
            int dirrectionY)
        {
            var newField = CopyField(field);

            var swapChecker = newField[y][x];
            newField[y][x] = CellState.EmptyCell;
            newField[y + 1 * (dirrectionY)][x + 1 * (dirrectionX)] = CellState.EmptyCell;
            newField[y + 2 * (dirrectionY)][x + 2 * (dirrectionX)] = swapChecker;

            return newField;
        }

        private static CellState[][] CopyField(CellState[][] field)
        {
            CellState[][] newField = new CellState[8][];

            for (int v = 0; v < 8; v++)
            {
                newField[v] = new CellState[8];
                for (int d = 0; d < 8; d++)
                {
                    newField[v][d] = field[v][d];
                }
            }

            return newField;
        }

        private static bool IsOurChecker(Team team, CellState cellState)
            => team == Team.Black && IsBlackTeamChecker(cellState)
            || team == Team.White && IsWhiteTeamChecker(cellState);

        private static bool IsEmptyCell(CellState cellState)
            => cellState == CellState.EmptyCell;

        private static bool IsWhiteTeamChecker(CellState cellState)
            => cellState == CellState.WhiteChecker || cellState == CellState.WhiteQueenChecker;

        private static bool IsBlackTeamChecker(CellState cellState)
            => cellState == CellState.BlackChecker || cellState == CellState.BlackQueenChecker;

        private static bool IsEnemyChecker(CellState cellState, Team team)
            => team == Team.Black && IsWhiteTeamChecker(cellState)
            || team == Team.White && IsBlackTeamChecker(cellState);
    }
}
