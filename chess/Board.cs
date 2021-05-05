using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    public class Board
    {
        private List<Figure> black_figures = new List<Figure>();
        private List<Figure> white_figures = new List<Figure>();
        private Colors Step = Colors.WHITE;
        private int count_steps = 1;
        private Figure white_king;
        private Figure black_king;
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
            foreach (Figure figure in white_figures)
            {
                array[figure.GetY(), figure.GetX()] = figure.GetSymbol();
            }
            foreach (Figure figure in black_figures)
            {
                array[figure.GetY(), figure.GetX()] = figure.GetSymbol();
            }
        }
        public Figure GetFigure(int y, int x)
        {
            foreach (Figure figure in white_figures)
            {
                if (y == figure.GetY() && x == figure.GetX()) return figure;
            }
            foreach (Figure figure in black_figures)
            {
                if (y == figure.GetY() && x == figure.GetX()) return figure;
            }
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
            this.AddFigure(figure);
            return figure;
        }
        public void AddFigure(Figure figure)
        {
            if (figure != null)
            {
                if (figure.GetColor() == Colors.BLACK) this.black_figures.Add(figure);
                else this.white_figures.Add(figure);
            }
        }
        public void RemoveFigure(Figure figure)
        {
            if (figure != null)
            {
                if (figure.GetColor() == Colors.BLACK) this.black_figures.Remove(figure);
                else this.white_figures.Remove(figure);
            }
        }
        public bool IsCheck(Figure fig, int y, int x)
        {
            Figure temp = GetFigure(y, x);
            int tempy = fig.GetY();
            int tempx = fig.GetX();
            Move(fig, y, x);
            if (fig.GetColor() == Colors.BLACK && IsUnderAttack(this.black_king.GetY(), this.black_king.GetX(), Colors.BLACK) || (fig.GetColor() == Colors.WHITE && IsUnderAttack(this.white_king.GetY(), this.white_king.GetX(), Colors.WHITE)))
            {
                Console.WriteLine(IsUnderAttack(this.white_king.GetY(), this.white_king.GetX(), Colors.WHITE));
                Move(fig, tempy, tempx);
                AddFigure(temp);
                return true;
            }
            Move(fig, tempy, tempx);
            AddFigure(temp);
            return false;
        }
        public bool IsUnderAttack(int y, int x, Colors color)
        {
            if (color == Colors.BLACK)
            {
                foreach (Figure figure in white_figures)
                {
                    if (figure.IsCanMove(y, x) > 0)
                    {
                        return true;
                    }
                }
            }
            else
            {
                foreach (Figure figure in black_figures)
                {
                    if (figure.IsCanMove(y, x) > 0)
                    {
                        Console.WriteLine(figure.GetColor());
                        return true;
                    }
                }
            }
            return false;
        }
        public void Move(Figure fig, int y, int x)
        {
            if (fig != null)
            {
                RemoveFigure(GetFigure(y, x));
                fig.SetPos(y, x);
            }
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
