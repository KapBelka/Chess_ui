using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    public class King : Figure
    {
        internal bool IsFirstStep = true;
        public King(int y, int x, Colors color, Board board) : base(y, x, color, board)
        {
        }

        public override string GetSymbol()
        {
            if (this.color == Colors.BLACK) return "bK";
            else return "wK";
        }

        public override int IsCanMove(int y, int x)
        {
            if (!this.IsValidData(y, x)) return 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (y == this.y + i && x == this.x + j) return 1;
                }
            }
            if (y == 7 || y == 0)
            {
                Figure fig;
                if (x == 5) fig = board.GetFigure(y, 7);
                else if (x == 1) fig = board.GetFigure(y, 0);
                else return 0;
                if (fig?.GetType() == typeof(Rook) && fig?.GetColor() == this.color && (fig as Rook).IsFirstStep && this.IsFirstStep)
                {
                    if (x == 1)
                    {
                        for (int i = 1; i <= 2; i++)
                        {
                            if (board.GetFigure(y, this.x - i) != null) return 0;
                        }
                        return 2;
                    }
                    else
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            if (board.GetFigure(y, this.x + i) != null) return 0;
                        }
                        return 3;
                    }
                }
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
                if (CanMove == 2)
                {
                    board.GetFigure(y, 0).SetPos(y, 2);
                }
                else if (CanMove == 3)
                {
                    board.GetFigure(y, 7).SetPos(y, 4);
                }
                this.IsFirstStep = false;
                board.Move(this, y, x);
                board.EndMove();
                return 1;
            }
            return 0;
        }
    }
}
