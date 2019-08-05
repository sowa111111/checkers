using System;
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
                    if (data.Field[x][y] != CellState.EmptyCell && IsOurChecker(data.Team, data.Field[x][y]))
                    {
                        var moves = SearchMoveAround(x, y, data.Field, data.Team);
                        possibleMoves.AddRange(moves);
                    }
                }

            return possibleMoves;
        }

        private IEnumerable<CheckerMove> SearchMoveAround(byte x, byte y, CellState[][] field, Team team)
        {
            var possibleMoves = new List<PossibleMoves>();

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
    }
}
