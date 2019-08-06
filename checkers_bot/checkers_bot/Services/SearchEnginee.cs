using System.Collections.Generic;

namespace checkers_bot.Services
{
    public class SearchEnginee
    {
        private readonly int[] _dx = { -1, 1 };
        private readonly int[] _dy = { -1, 1 };

        public IEnumerable<PossibleMoves> SearchAllPossibleMoves(CheckerPayload data)
        {
            var possibleMoves = new List<PossibleMoves>();

            //TODO: check attacks.

            if (possibleMoves.Count != 0)
            {
                return possibleMoves;
            }

            for (byte x = 0; x < 8; x++)
                for (byte y = 0; y < 8; y++)
                {
                    if (data.Field[x][y] != CellState.EmptyCell && IsOurChecker(data.Team, data.Field[x][y]))
                    {
                        var moves = SearchMoveAround(x, y, data.Field, data.Team);
                        possibleMoves.Add(new PossibleMoves { Moves = moves });
                    }
                }

            return possibleMoves;
        }

        private CheckerMove[] SearchMoveAround(byte x, byte y, CellState[][] field, Team team)
        {
            var possibleMoves = new List<CheckerMove>();

            foreach (var i in _dx)
            {
                foreach (var j in _dy)
                {
                    if (CanMove(x, y, i, j, field, team))
                    {
                        possibleMoves.Add(new CheckerMove
                        {
                            FromPoint = new CellPoint(x, y),
                            ToPoint = new CellPoint((byte)(x + i), (byte)(y + j))
                        });
                    }
                }
            }

            return possibleMoves.ToArray();
        }

        private static bool CanMove(byte x, byte y, int dirrectionX, int dirrectionY, CellState[][] field, Team team)
        {
            var targetX = x + dirrectionX;
            var targetY = y + dirrectionY;
            if (!CellPoint.IsValidCellPoint(targetX, targetY) || !IsEmptyCell(field[targetX][targetY]))
            {
                return false;
            }

            if (IsQueen(field[x][y]))
            {
                return true;
            }

            if (team == Team.Black && targetY < y)
            {
                return false;
            }

            return team == Team.White && targetY < y;
        }

        private void CheckAttackMove(byte x, byte y, int dirrectionX, int dirrectionY, CellState[][] field, Team team, List<CheckerMove> moves)
        {
            if (CellPoint.IsValidCellPoint(x + 1 * (dirrectionX), y + 1 * (dirrectionY))
                && CellPoint.IsValidCellPoint(x + 2 * (dirrectionX), y + 2 * (dirrectionY)))
            {
                if (IsEnemyChecker(field[x + 1 * (dirrectionX)][y + 1 * (dirrectionY)], team)
                    && IsEmptyCell(field[x + 2 * (dirrectionX)][y + 2 * (dirrectionY)]))
                {
                    moves.Add(new CheckerMove
                    {
                        FromPoint = new CellPoint(x, y),
                        ToPoint = new CellPoint((byte)(x + 2 * (dirrectionX)), (byte)(y + 2 * (dirrectionY)))
                    });
                }
            }
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

        private static bool IsQueen(CellState cellState)
            => cellState == CellState.BlackQueenChecker || cellState == CellState.WhiteQueenChecker;

        private static CellState[][] Copy(CellState[][] field)
        {
            var newField = new CellState[8][];
            for (var i = 0; i < 8; i++)
            {
                newField[i] = new CellState[8];
                for (var j = 0; j < 8; j++)
                {
                    newField[i][j] = field[i][j];
                }
            }

            return newField;
        }
    }
}
