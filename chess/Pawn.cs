using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    public class Pawn : Figure
    {
        internal bool IsFirstStep = true;
        internal bool IsAfterFirstStep = false;
        internal int FirstStep = 0;
        public Pawn(int y, int x, Colors color, Board board) : base(y, x, color, board)
        {
        }
        public override string GetSymbol()
        {
            if (this.color == Colors.BLACK) return "bP";
            else return "wP";
        }
        public override int IsCanMove(int y, int x)
        {
            if (!this.IsValidData(y, x)) return 0;
            int multiple = 1;
            if (this.color == Colors.BLACK) multiple = -1;
            if (board.GetFigure(y, x) == null)
            {
                if (x == this.x && y == (this.y + 1 * multiple)) return 1;
                if (x == this.x && y == (this.y + 2 * multiple) && board.GetFigure(y - 1 * multiple, x) == null && this.IsFirstStep) return 2;
            }
            if ((x == this.x + 1 || x == this.x - 1) && y == this.y + 1 * multiple)
            {
                Figure figure = this.board.GetFigure(y, x);
                if (figure != null && figure.GetColor() != this.color) return 3;
                else
                {
                    figure = this.board.GetFigure(y - 1 * multiple, x);
                    if (figure != null && figure.GetColor() != this.color && figure.GetType() == typeof(Pawn) && (figure as Pawn).IsAfterFirstStep && (figure as Pawn).FirstStep == board.GetCountSteps() - 1) return 4;
                }
            }
            return 0;
        }
        public override bool Move(int y, int x)
        {
            int CanMove = this.IsCanMove(y, x);
            if (CanMove != 0)
            {
                if (CanMove == 2)
                {
                    IsAfterFirstStep = true;
                    FirstStep = board.GetCountSteps();
                }
                else if (CanMove == 4)
                {
                    if (this.GetColor() == Colors.BLACK)
                    {
                        board.RemoveFigure(board.GetFigure(y + 1, x));
                    }
                    else
                    {
                        board.RemoveFigure(board.GetFigure(y - 1, x));
                    }
                }
                else IsAfterFirstStep = false;
                IsFirstStep = false;
                board.Move(this, y, x);
                return true;
            }
            return false;
        }
        public bool Move(int y, int x, Figures figure_type)
        {
            int CanMove = this.IsCanMove(y, x);
            if (CanMove != 0)
            {
                if (CanMove == 2)
                {
                    IsAfterFirstStep = true;
                    FirstStep = board.GetCountSteps();
                }
                else if (CanMove == 4)
                {
                    if (this.GetColor() == Colors.BLACK)
                    {
                        board.RemoveFigure(board.GetFigure(y + 1, x));
                    }
                    else
                    {
                        board.RemoveFigure(board.GetFigure(y + 1, x));
                    }
                }
                else IsAfterFirstStep = false;
                IsFirstStep = false;
                board.RemoveFigure(this);
                board.Move(board.CreateNewFigure(this.y, this.x, this.color, figure_type), y, x);
                return true;
            }
            return false;
        }
    }
}
