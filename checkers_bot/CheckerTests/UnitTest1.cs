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
                Field = new CellState[][]
                {
                    new CellState[]
                    {
                        CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker
                    },
                    new CellState[]
                    {
                        CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell
                    },
                    new CellState[]
                    {
                        CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker
                    },
                    new CellState[]
                    {
                        CellState.EmptyCell, CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new CellState[]
                    {
                        CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new CellState[]
                    {
                        CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell
                    },
                    new CellState[]
                    {
                        CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker
                    },
                    new CellState[]
                    {
                        CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell
                    }
                },
                Team = Team.Black
            };

            var possibleMoves = _searchEnginee.SearchAllPossibleMoves(payload);
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
                Field = new CellState[][]
                {
                    new CellState[]
                    {
                        CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker
                    },
                    new CellState[]
                    {
                        CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker,CellState.EmptyCell
                    },
                    new CellState[]
                    {
                        CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker, CellState.EmptyCell, CellState.BlackChecker
                    },
                    new CellState[]
                    {
                        CellState.EmptyCell, CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new CellState[]
                    {
                        CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.BlackQueenChecker, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new CellState[]
                    {
                        CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell
                    },
                    new CellState[]
                    {
                        CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell, CellState.EmptyCell
                    },
                    new CellState[]
                    {
                        CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell, CellState.WhiteChecker, CellState.EmptyCell, CellState.WhiteChecker,CellState.EmptyCell
                    }
                },
                Team = Team.Black
            };

            var possibleMoves = _searchEnginee.SearchAllPossibleMoves(payload);

            Assert.That(possibleMoves, Has.Count.EqualTo(4));
            var selectedMoves = possibleMoves.Where(x => x.Moves.Any(y => y.FromPoint.Y == 4 && y.FromPoint.X == 5)).ToList();
            Assert.That(selectedMoves, Has.Count.EqualTo(2));
            Assert.That(possibleMoves.First().Weight, Is.EqualTo(1));
            Assert.That(selectedMoves.First().Moves.Length, Is.EqualTo(1));
            Assert.That(selectedMoves.First().Moves[0].FromPoint.Y, Is.EqualTo(4));
            Assert.That(selectedMoves.First().Moves[0].FromPoint.X, Is.EqualTo(5));
            Assert.That(selectedMoves.First().Moves[0].ToPoint.Y, Is.EqualTo(6));
            Assert.That(selectedMoves.First().Moves[0].ToPoint.X, Is.EqualTo(3));
            Assert.That(possibleMoves.Last().Weight, Is.EqualTo(1));
            Assert.That(selectedMoves.Last().Moves.Length, Is.EqualTo(1));
            Assert.That(selectedMoves.Last().Moves[0].FromPoint.Y, Is.EqualTo(4));
            Assert.That(selectedMoves.Last().Moves[0].FromPoint.X, Is.EqualTo(5));
            Assert.That(selectedMoves.Last().Moves[0].ToPoint.Y, Is.EqualTo(6));
            Assert.That(selectedMoves.Last().Moves[0].ToPoint.X, Is.EqualTo(7));
        }
    }
}