using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    public class Board
    {
        private Figure[,] field = new Figure[8,8];
        private Colors Step = Colors.WHITE;
        private int count_steps = 1;
        public Figure white_king;
        public Figure black_king;
        private void ChangeColor()
        {
            if (Step == Colors.WHITE) Step = Colors.BLACK;
            else Step = Colors.WHITE;
        }
        public Colors GetColor()
        {
            return Step;
        }
        public Board()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    field[i, j] = null;
                }
            }
        }
        public static Board CreateChessBoard()
        {
            Board GameBoard = new Board();
            for (int b = 0; b < 8; b++)
            {
                GameBoard.CreateNewFigure(1, b, Colors.WHITE, Figures.PAWN);
                GameBoard.CreateNewFigure(6, b, Colors.BLACK, Figures.PAWN);
            }
            GameBoard.CreateNewFigure(0, 0, Colors.WHITE, Figures.ROOK);
            GameBoard.CreateNewFigure(0, 1, Colors.WHITE, Figures.KNIGHT);
            GameBoard.CreateNewFigure(0, 2, Colors.WHITE, Figures.BISHOP);
            GameBoard.white_king = GameBoard.CreateNewFigure(0, 3, Colors.WHITE, Figures.KING);
            GameBoard.CreateNewFigure(0, 4, Colors.WHITE, Figures.QUEEN);
            GameBoard.CreateNewFigure(0, 5, Colors.WHITE, Figures.BISHOP);
            GameBoard.CreateNewFigure(0, 6, Colors.WHITE, Figures.KNIGHT);
            GameBoard.CreateNewFigure(0, 7, Colors.WHITE, Figures.ROOK);
            GameBoard.CreateNewFigure(7, 0, Colors.BLACK, Figures.ROOK);
            GameBoard.CreateNewFigure(7, 1, Colors.BLACK, Figures.KNIGHT);
            GameBoard.CreateNewFigure(7, 2, Colors.BLACK, Figures.BISHOP);
            GameBoard.black_king = GameBoard.CreateNewFigure(7, 3, Colors.BLACK, Figures.KING);
            GameBoard.CreateNewFigure(7, 4, Colors.BLACK, Figures.QUEEN);
            GameBoard.CreateNewFigure(7, 5, Colors.BLACK, Figures.BISHOP);
            GameBoard.CreateNewFigure(7, 6, Colors.BLACK, Figures.KNIGHT);
            GameBoard.CreateNewFigure(7, 7, Colors.BLACK, Figures.ROOK);
            return GameBoard;
        }
        public void GetFieldData(ref string[,] array)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    array[i, j] = this.field[i, j]?.GetSymbol();
                }
            }
        }
        public Figure GetFigure(int a, int b)
        {
            if (0 <= a && a < 8 && 0 <= b && b < 8) return field[a, b];
            return null;
        }
        public int GetCountSteps()
        {
            return count_steps;
        }
        public Figure CreateNewFigure(int y, int x, Colors color, Figures type_figure)
        {
            Figure figure;
            switch (type_figure)
            {
                case Figures.BISHOP:
                    figure = new Bishop(y, x, color, this);
                    break;
                case Figures.KNIGHT:
                    figure = new Knight(y, x, color, this);
                    break;
                case Figures.QUEEN:
                    figure = new Queen(y, x, color, this);
                    break;
                case Figures.ROOK:
                    figure = new Rook(y, x, color, this);
                    break;
                case Figures.PAWN:
                    figure = new Pawn(y, x, color, this);
                    break;
                case Figures.KING:
                    figure = new King(y, x, color, this);
                    if (color == Colors.BLACK)
                    {
                        this.black_king = figure;
                    }
                    else this.white_king = figure;
                    break;
                default:
                    return null;
            }
            this.SetFigure(y, x, figure);
            return figure;
        }
        public void SetFigure(int y, int x, Figure fig)
        {
            this.field[y, x] = fig;
        }
        public bool IsCheck(Figure fig, int y, int x)
        {
            Console.WriteLine(fig);
            Figure temp = this.field[y, x];
            this.field[y, x] = fig;
            this.field[fig.GetY(), fig.GetX()] = null;
            int tempy = fig.GetY();
            int tempx = fig.GetX();
            fig.SetPos(y, x);
            if (fig.GetColor() == Colors.BLACK && IsUnderAttack(this.black_king.GetY(), this.black_king.GetX(), fig.GetColor()) || (fig.GetColor() == Colors.WHITE && IsUnderAttack(this.white_king.GetY(), this.white_king.GetX(), fig.GetColor())))
            {
                fig.SetPos(tempy, tempx);
                this.field[fig.GetY(), fig.GetX()] = fig;
                this.field[y, x] = temp;
                return true;
            }
            fig.SetPos(tempy, tempx);
            this.field[fig.GetY(), fig.GetX()] = fig;
            this.field[y, x] = temp;
            return false;
        }
        public bool IsUnderAttack(int y, int x, Colors color)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Figure figure = this.GetFigure(i, j);
                    if (figure != null && figure.GetColor() != color && figure.IsCanMove(y, x) != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void Move(Figure fig, int y, int x)
        {
            SetFigure(y, x, fig);
            SetFigure(fig.GetY(), fig.GetX(), null);
            fig.SetPos(y, x);
        }
        public int MoveFig(Figure fig, int y, int x)
        {
            if (fig == null || IsCheck(fig, y, x)) return 0;
            if (fig.GetType() == typeof(Pawn) && fig.IsCanMove(y, x) != 0 && ((fig.GetColor() == Colors.BLACK && y == 0) || (fig.GetColor() == Colors.WHITE && y == 7))) return -1;
            if (fig.GetColor() != Step) return -2;
            if (fig.Move(y, x))
            {
                count_steps++;
                ChangeColor();
                return 1;
            }
            return 0;
        }
        public int MoveFig(Figure fig, int y, int x, Figures type_figure)
        {
            if (fig == null) return 0;
            if (fig.GetType() != typeof(Pawn) || (fig.GetColor() == Colors.WHITE && y != 7) || (fig.GetColor() == Colors.BLACK && y != 0)) return -1;
            if (fig.GetColor() != Step) return -2;
            if (((Pawn)fig).Move(y, x, type_figure))
            {
                count_steps++;
                ChangeColor();
                return 1;
            }
            return 0;
        }
    }
}
