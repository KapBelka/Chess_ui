using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    public class Bishop : Figure
    {
        public Bishop(int y, int x, Colors color, Board board) : base(y, x, color, board)
        {
        }
        public override string GetSymbol()
        {
            if(this.color == Colors.BLACK) return "bB";
            else return "wB";
        }
        public override int IsCanMove(int y, int x)
        {
            if (!this.IsValidData(y, x)) return 0;
            if(Math.Abs(y - this.y) == Math.Abs(x - this.x))
            {
                int multiplex = 1;
                int multipley = 1;
                if (this.x - x > 0) multiplex = -1;
                if (this.y - y > 0) multipley = -1;
                for (int i = 1; i < Math.Abs(y - this.y); i++)
                {
                    if (this.board.GetFigure(this.y + i * multipley, this.x + i * multiplex) != null) return 0;
                }
                return 1;
            }
            return 0;
        }

        public override int Move(int y, int x)
        {
            if (board.IsCheck(this, y, x)) return 0;
            if (GetColor() != board.GetColor()) return -2;
            int CanMove = this.IsCanMove(y, x);
            if (CanMove != 0)
            {
                board.Move(this, y, x);
                board.EndMove();
                return 1;
            }
            return 0;
        }
    }
}
