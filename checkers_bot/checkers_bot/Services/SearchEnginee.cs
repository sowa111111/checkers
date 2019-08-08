using System;
using System.Collections.Generic;
using System.Linq;

namespace checkers_bot.Services
{
    public class SearchEnginee
    {
        private readonly int[] _dx = { -1, 1 };
        private readonly int[] _dy = { -1, 1 };

        public CheckerMove[] FindNextMove(CellState[][] field, Team team)
        {
            var possibleMoves = SearchAllPossibleMoves(field, team).ToArray();

            if (possibleMoves?.Any() != true)
            {
                return new CheckerMove[] { };
            }

            foreach (var possibleMove in possibleMoves)
            {
                var newField = GetRefreshedField(possibleMove, field, team);
                var possibleEnemyMove = SearchAllPossibleMoves(newField, GetEnemyTeam(team));

                if (possibleEnemyMove.Any())
                {
                    var maxDamageWeight = possibleEnemyMove.Max(x => x.Weight);
                    possibleMove.Weight -= maxDamageWeight;
                }
            }

            return GetPrimaryMove(possibleMoves);
        }

        private CellState[][] GetRefreshedField(PossibleMoves possibleMove, CellState[][] field, Team team)
        {
            var newField = Copy(field);

            foreach (var move in possibleMove.Moves)
            {
                var directionX = move.FromPoint.X < move.ToPoint.X ? 1 : -1;
                var directionY = move.FromPoint.Y < move.ToPoint.Y ? 1 : -1;

                var initialChecker = field[move.FromPoint.Y][move.FromPoint.X];

                var targetX = move.FromPoint.X;
                var targetY = move.FromPoint.Y;

                do
                {
                    newField[targetY][targetX] = CellState.EmptyCell;
                    targetX = (byte)(targetX + directionX);
                    targetY = (byte)(targetY + directionY);
                } while (targetY != move.ToPoint.Y && targetX != move.ToPoint.X);

                newField[move.ToPoint.Y][move.ToPoint.X] = initialChecker;
            }

            return newField;
        }

        private CheckerMove[] GetPrimaryMove(IEnumerable<PossibleMoves> possibleMoves)
        {
            if (possibleMoves?.Any() != true)
            {
                return new CheckerMove[] { };
            }

            var weightedResult = possibleMoves
                .GroupBy(x => x.Weight)
                .OrderByDescending(x => x.Key)
                .ToArray();

            var maxWeight = weightedResult[0].ToArray();
            var random = new Random();
            return maxWeight[random.Next(maxWeight.Length)].Moves;
        }

        public IEnumerable<PossibleMoves> SearchAllPossibleMoves(CellState[][] field, Team team)
        {
            var possibleMoves = new List<PossibleMoves>();

            for (byte x = 0; x < 8; x++)
                for (byte y = 0; y < 8; y++)
                {
                    if (field[y][x] != CellState.EmptyCell && IsOurChecker(team, field[y][x]))
                    {
                        var tree = new CheckerMoveTreeNode();
                        SearchAttackMoves(x, y, field, team, tree);
                        possibleMoves.AddRange(ReadCheckerMoveTree(tree));
                    }
                }

            for (byte x = 0; x < 8; x++)
                for (byte y = 0; y < 8; y++)
                {
                    if (field[y][x] != CellState.EmptyCell && IsOurChecker(team, field[y][x]))
                    {
                        var moves = SearchMoveAround(x, y, field, team)
                            .Select(move =>
                            new PossibleMoves
                            {
                                Moves = new[] { move },
                                Weight = 0
                            });
                        possibleMoves.AddRange(moves);
                    }
                }

            return possibleMoves;
        }

        private List<PossibleMoves> ReadCheckerMoveTree(CheckerMoveTreeNode tree)
        {
            var possibleMoves = new List<PossibleMoves>();

            void ReadTree(List<CheckerMove> previousMoves, CheckerMoveTreeNode node)
            {
                if (node.Move != null)
                {
                    previousMoves.Add(node.Move);

                    if (node.ChildMoves?.Count > 0)
                    {
                        foreach (var childMove in node.ChildMoves)
                        {
                            ReadTree(previousMoves.ToList(), childMove);
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new PossibleMoves
                        {
                            Moves = previousMoves.ToArray(),
                            Weight = previousMoves.Count
                        });
                    }
                }
            }

            tree.ChildMoves.ForEach(child => ReadTree(new List<CheckerMove>(), child));

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
            if (!CellPoint.IsValidCellPoint(targetX, targetY) || !IsEmptyCell(field[targetY][targetX]))
            {
                return false;
            }

            if (IsQueen(field[y][x]))
            {
                return true;
            }

            return team == Team.White && targetY < y
                || team == Team.Black && targetY > y;
        }

        public void SearchAttackMoves(byte x, byte y, CellState[][] field, Team team, CheckerMoveTreeNode parent)
        {
            parent.ChildMoves = new List<CheckerMoveTreeNode>();

            foreach (var i in _dx)
            {
                foreach (var j in _dy)
                {
                    var c = 1;
                    if (IsQueen(field[y][x]))
                    {
                        while (CellPoint.IsValidCellPoint(x + c * i, y + c * j) && IsEmptyCell(field[y + c * j][x + c * i]))
                        {
                            c++;
                        }
                    }

                    if (CheckAttackMove(x, y, i, j, c, field, team))
                    {
                        var step = 1;
                        do
                        {
                            var node = new CheckerMoveTreeNode
                            {
                                Move = new CheckerMove
                                {
                                    FromPoint = new CellPoint(x, y),
                                    ToPoint = new CellPoint((byte)(x + (c + step) * i), (byte)(y + (c + step) * j))
                                }
                            };

                            SearchAttackMoves(
                                node.Move.ToPoint.X,
                                node.Move.ToPoint.Y,
                                RefreshedField(field, x, y, i, j, c, step),
                                team,
                                node);

                            parent.ChildMoves.Add(node);
                            step++;
                        } while (IsQueen(field[y][x])
                            && CellPoint.IsValidCellPoint(x + (c + 1 * step) * i, y + (c + 1 * step) * j)
                            && IsEmptyCell(field[y + (c + 1 * step) * j][x + (c + 1 * step) * i]));
                    }
                }
            }
        }

        private CellState[][] RefreshedField(CellState[][] field, byte x, byte y, int directionX, int directionY, int coefficient, int step)
        {
            var newField = Copy(field);

            int victomCellX = x + coefficient * directionX;
            int victomCellY = y + coefficient * directionY;

            int nextCellX = x + (coefficient + step) * directionX;
            int nextCellY = y + (coefficient + step) * directionY;

            var swap = newField[y][x];
            newField[y][x] = CellState.EmptyCell;
            newField[victomCellY][victomCellX] = CellState.EmptyCell;
            newField[nextCellY][nextCellX] = swap;

            return newField;
        }

        private bool CheckAttackMove(byte x, byte y, int dirrectionX, int dirrectionY, int cofficient, CellState[][] field, Team team)
        {
            int victomCellX = x + cofficient * dirrectionX;
            int victomCellY = y + cofficient * dirrectionY;

            int nextCellX = victomCellX + 1 * dirrectionX;
            int nextCellY = victomCellY + 1 * dirrectionY;

            if (CellPoint.IsValidCellPoint(victomCellX, victomCellY)
                && CellPoint.IsValidCellPoint(nextCellX, nextCellY))
            {
                if (IsEnemyChecker(field[victomCellY][victomCellX], team)
                    && IsEmptyCell(field[nextCellY][nextCellX]))
                {
                    return true;
                }
            }
            return false;
        }

        private static Team GetEnemyTeam(Team team)
            => team == Team.White ? Team.Black : Team.White;

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
