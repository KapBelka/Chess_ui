using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    public enum Figures
    {
        NULL,
        PAWN,
        ROOK,
        QUEEN,
        KNIGHT,
        BISHOP,
        KING
    }
    public enum Colors
    {
        WHITE,
        BLACK
    }
    public abstract class Figure
    {
        protected int y;
        protected int x;
        protected Colors color;
        protected Board board;
        public Figure(int y, int x, Colors color, Board board)
        {
            this.y = y;
            this.x = x;
            this.board = board;
            this.color = color;
        }
        public abstract string GetSymbol();
        public Colors GetColor()
        {
            return this.color;
        }
        public int GetY()
        {
            return this.y;
        }
        public int GetX()
        {
            return this.x;
        }
        internal void SetPos(int y, int x)
        {
            this.y = y;
            this.x = x;
        }
        public bool IsValidData(int y, int x)
        {
            if (y < 0 || y > 7 || x < 0 || x > 7) return false;
            if (this.y == y && this.x == x) return false;
            if (board.GetFigure(y, x)?.GetColor() == this.color) return false;
            return true;
        }
        public abstract int IsCanMove(int y, int x);
        public abstract bool Move(int y, int x);
    }
}
