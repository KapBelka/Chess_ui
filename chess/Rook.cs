using System;

namespace chess
{
    public class Rook : Figure
    {
        internal bool IsFirstStep = true;
        public Rook(int y, int x, Colors color, Board board) : base(y, x, color, board)
        {
        }
        public override string GetSymbol()
        {
            if (this.color == Colors.BLACK) return "bR";
            else return "wR";
        }

        public override int IsCanMove(int y, int x)
        {
            if (!this.IsValidData(y, x)) return 0;
            int multiplex = 1;
            int multipley = 1;
            if (this.x - x > 0) multiplex = -1;
            if (this.y - y > 0) multipley = -1;
            if(y == this.y || x == this.x) {
                for (int i = 1; i < Math.Abs(x - this.x); i++)
                {
                    if (this.board.GetFigure(y, this.x + i * multiplex) != null) return 0;
                }
                for (int i = 1; i < Math.Abs(y - this.y); i++)
                {
                    if (this.board.GetFigure(this.y + i * multipley, x) != null) return 0;
                }
                return 1;
            }
            return 0;
        }
        public override bool Move(int y, int x)
        {
            int CanMove = this.IsCanMove(y, x);
            if (CanMove != 0)
            {
                this.IsFirstStep = false;
                board.Move(this, y, x);
                return true;
            }
            return false;
        }
    }
}
