using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    public class Knight : Figure
    {
        public Knight(int y, int x, Colors color, Board board) : base(y, x, color, board)
        {
        }
        public override string GetSymbol()
        {
            if (this.color == Colors.BLACK) return "bN";
            else return "wN";
        }

        public override int IsCanMove(int y, int x)
        {
            if (!this.IsValidData(y, x)) return 0;
            if (Math.Abs(x - this.x) == 2 && Math.Abs(y - this.y) == 1 || Math.Abs(x - this.x) == 1 && Math.Abs(y - this.y) == 2) return 1;
            return 0;
        }

        public override bool Move(int y, int x)
        {
            int CanMove = this.IsCanMove(y, x);
            if (CanMove != 0)
            {
                board.Move(this, y, x);
                return true;
            }
            return false;
        }
    }
}
