using checkers_bot;
using checkers_bot.Services;
using NUnit.Framework;

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

            _searchEnginee.SearchAllPossibleMoves(payload);
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

            _searchEnginee.SearchAllPossibleMoves(payload);
        }
    }
}