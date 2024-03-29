using checkers_bot;
using checkers_bot.Services;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class SearchEngineeTests
    {
        private SearchEnginee _searchEnginee;

        [SetUp]
        public void Setup()
        {
            _searchEnginee = new SearchEnginee();
        }

        [Test]
        public void Test1()
        {
            var payload = new CheckerPayload
            {
                Field = new[]
                {
                    new[]
                    {
                        CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker
                    },
                    new[]
                    {
                        CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker
                    },
                    new[]
                    {
                        CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell
                    }
                },
                Team = Team.Black
            };

            var possibleMoves = _searchEnginee.SearchAllPossibleMoves(payload.Field, payload.Team)
                .Where(x => x.Weight != 0)
                .ToList();


            Assert.That(possibleMoves, Has.Count.EqualTo(2));
            Assert.That(possibleMoves.First().Weight, Is.EqualTo(1));
            Assert.That(possibleMoves.First().Moves.Length, Is.EqualTo(1));
            Assert.That(possibleMoves.First().Moves[0].FromPoint.Y, Is.EqualTo(2));
            Assert.That(possibleMoves.First().Moves[0].FromPoint.X, Is.EqualTo(1));
            Assert.That(possibleMoves.First().Moves[0].ToPoint.Y, Is.EqualTo(4));
            Assert.That(possibleMoves.First().Moves[0].ToPoint.X, Is.EqualTo(3));
            Assert.That(possibleMoves.Last().Weight, Is.EqualTo(3));
            Assert.That(possibleMoves.Last().Moves.Length, Is.EqualTo(3));
            Assert.That(possibleMoves.Last().Moves[0].FromPoint.Y, Is.EqualTo(2));
            Assert.That(possibleMoves.Last().Moves[0].FromPoint.X, Is.EqualTo(3));
            Assert.That(possibleMoves.Last().Moves[0].ToPoint.Y, Is.EqualTo(4));
            Assert.That(possibleMoves.Last().Moves[0].ToPoint.X, Is.EqualTo(1));
            Assert.That(possibleMoves.Last().Moves[1].FromPoint.Y, Is.EqualTo(4));
            Assert.That(possibleMoves.Last().Moves[1].FromPoint.X, Is.EqualTo(1));
            Assert.That(possibleMoves.Last().Moves[1].ToPoint.Y, Is.EqualTo(6));
            Assert.That(possibleMoves.Last().Moves[1].ToPoint.X, Is.EqualTo(3));
            Assert.That(possibleMoves.Last().Moves[2].FromPoint.Y, Is.EqualTo(6));
            Assert.That(possibleMoves.Last().Moves[2].FromPoint.X, Is.EqualTo(3));
            Assert.That(possibleMoves.Last().Moves[2].ToPoint.Y, Is.EqualTo(4));
            Assert.That(possibleMoves.Last().Moves[2].ToPoint.X, Is.EqualTo(5));
        }

        [Test]
        public void Test2()
        {
            var payload = new CheckerPayload
            {
                Field = new[]
                {
                    new[]
                    {
                        CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker
                    },
                    new[]
                    {
                        CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell
                    }
                },
                Team = Team.Black
            };

            var possibleMoves = _searchEnginee.SearchAllPossibleMoves(payload.Field, payload.Team)
                .Where(x => x.Weight != 0)
                .ToList();

            Assert.That(possibleMoves, Has.Count.EqualTo(4));
            var selectedMoves = possibleMoves.Where(x => x.Moves.Any(y => y.FromPoint.Y == 4 && y.FromPoint.X == 5)).ToList();
            Assert.That(selectedMoves, Has.Count.EqualTo(2));
            Assert.That(selectedMoves.First().Weight, Is.EqualTo(2));
            Assert.That(selectedMoves.First().Moves.Length, Is.EqualTo(2));
            Assert.That(selectedMoves.First().Moves[0].FromPoint.Y, Is.EqualTo(4));
            Assert.That(selectedMoves.First().Moves[0].FromPoint.X, Is.EqualTo(5));
            Assert.That(selectedMoves.First().Moves[0].ToPoint.Y, Is.EqualTo(6));
            Assert.That(selectedMoves.First().Moves[0].ToPoint.X, Is.EqualTo(3));
            Assert.That(selectedMoves.First().Moves[1].FromPoint.Y, Is.EqualTo(6));
            Assert.That(selectedMoves.First().Moves[1].FromPoint.X, Is.EqualTo(3));
            Assert.That(selectedMoves.First().Moves[1].ToPoint.Y, Is.EqualTo(4));
            Assert.That(selectedMoves.First().Moves[1].ToPoint.X, Is.EqualTo(1));
            Assert.That(selectedMoves.Last().Weight, Is.EqualTo(1));
            Assert.That(selectedMoves.Last().Moves.Length, Is.EqualTo(1));
            Assert.That(selectedMoves.Last().Moves[0].FromPoint.Y, Is.EqualTo(4));
            Assert.That(selectedMoves.Last().Moves[0].FromPoint.X, Is.EqualTo(5));
            Assert.That(selectedMoves.Last().Moves[0].ToPoint.Y, Is.EqualTo(6));
            Assert.That(selectedMoves.Last().Moves[0].ToPoint.X, Is.EqualTo(7));
        }

        [Test]
        public void Test3()
        {
            var payload = new CheckerPayload
            {
                Field = new[]
                {
                    new[]
                    {
                        CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker
                    },
                    new[]
                    {
                        CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.BlackQueenChecker, CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell
                    }
                },
                Team = Team.Black
            };

            var possibleMoves = _searchEnginee.SearchAllPossibleMoves(payload.Field, payload.Team)
                .Where(x => x.Weight > 0)
                .ToList();

            Assert.That(possibleMoves, Has.Count.EqualTo(1));
            Assert.That(possibleMoves.First().Weight, Is.EqualTo(2));
            Assert.That(possibleMoves.First().Moves.Length, Is.EqualTo(2));
            Assert.That(possibleMoves.First().Moves[0].FromPoint.Y, Is.EqualTo(2));
            Assert.That(possibleMoves.First().Moves[0].FromPoint.X, Is.EqualTo(1));
            Assert.That(possibleMoves.First().Moves[0].ToPoint.Y, Is.EqualTo(6));
            Assert.That(possibleMoves.First().Moves[0].ToPoint.X, Is.EqualTo(5));
            Assert.That(possibleMoves.First().Moves[1].FromPoint.Y, Is.EqualTo(6));
            Assert.That(possibleMoves.First().Moves[1].FromPoint.X, Is.EqualTo(5));
            Assert.That(possibleMoves.First().Moves[1].ToPoint.Y, Is.EqualTo(4));
            Assert.That(possibleMoves.First().Moves[1].ToPoint.X, Is.EqualTo(7));
        }

        [Test]
        public void Test4()
        {
            var payload = new CheckerPayload
            {
                Field = new[]
                {
                    new[]
                    {
                        CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker
                    },
                    new[]
                    {
                        CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.BlackQueenChecker, CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.EmptyCell,CellState.EmptyCell
                    }
                },
                Team = Team.Black
            };

            var possibleMoves = _searchEnginee.SearchAllPossibleMoves(payload.Field, payload.Team)
                .Where(x => x.Weight > 0)
                .ToList();

            Assert.That(possibleMoves.Where(x => x.Weight > 0).ToArray(), Has.Length.EqualTo(0));
        }
        [Test]
        public void Test5()
        {
            var payload = new CheckerPayload
            {
                Field = new[]
                {
                    new[]
                    {
                        CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker
                    },
                    new[]
                    {
                        CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.BlackQueenChecker, CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new[]
                    {
                        CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.EmptyCell,CellState.EmptyCell
                    }
                },
                Team = Team.Black
            };

            var possibleMoves = _searchEnginee.SearchAllPossibleMoves(payload.Field, payload.Team)
                .Where(x => x.Weight > 0)
                .ToArray();

            Assert.That(possibleMoves, Has.Length.EqualTo(3));
            Assert.That(possibleMoves[0].Weight, Is.EqualTo(1));
            Assert.That(possibleMoves[0].Moves.Length, Is.EqualTo(1));
            Assert.That(possibleMoves[0].Moves[0].FromPoint.Y, Is.EqualTo(2));
            Assert.That(possibleMoves[0].Moves[0].FromPoint.X, Is.EqualTo(1));
            Assert.That(possibleMoves[0].Moves[0].ToPoint.Y, Is.EqualTo(5));
            Assert.That(possibleMoves[0].Moves[0].ToPoint.X, Is.EqualTo(4));
            Assert.That(possibleMoves[1].Weight, Is.EqualTo(2));
            Assert.That(possibleMoves[1].Moves.Length, Is.EqualTo(2));
            Assert.That(possibleMoves[1].Moves[0].FromPoint.Y, Is.EqualTo(2));
            Assert.That(possibleMoves[1].Moves[0].FromPoint.X, Is.EqualTo(1));
            Assert.That(possibleMoves[1].Moves[0].ToPoint.Y, Is.EqualTo(6));
            Assert.That(possibleMoves[1].Moves[0].ToPoint.X, Is.EqualTo(5));
            Assert.That(possibleMoves[1].Moves[1].FromPoint.Y, Is.EqualTo(6));
            Assert.That(possibleMoves[1].Moves[1].FromPoint.X, Is.EqualTo(5));
            Assert.That(possibleMoves[1].Moves[1].ToPoint.Y, Is.EqualTo(4));
            Assert.That(possibleMoves[1].Moves[1].ToPoint.X, Is.EqualTo(7));
            Assert.That(possibleMoves[2].Weight, Is.EqualTo(1));
            Assert.That(possibleMoves[2].Moves.Length, Is.EqualTo(1));
            Assert.That(possibleMoves[2].Moves[0].FromPoint.Y, Is.EqualTo(2));
            Assert.That(possibleMoves[2].Moves[0].FromPoint.X, Is.EqualTo(1));
            Assert.That(possibleMoves[2].Moves[0].ToPoint.Y, Is.EqualTo(7));
            Assert.That(possibleMoves[2].Moves[0].ToPoint.X, Is.EqualTo(6));
        }
    }
}