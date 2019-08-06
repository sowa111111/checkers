using System.Collections.Generic;

namespace checkers_bot
{
    public class CheckerMoveTreeNode
    {
        public CheckerMove Move { get; set; }

        public List<CheckerMoveTreeNode> ChildMoves { get; set; }
    }
}
