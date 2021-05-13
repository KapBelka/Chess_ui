using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    public class JsonModel {
        public string figure { get; set; }
        public int y { get; set; }
        public int x { get; set; }
    }
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
        public void GetFieldData(ref List<JsonModel> array)
        {
            foreach (Figure figure in white_figures)
            {
                array.Add(new JsonModel(){ y = figure.GetY(), x = figure.GetX(), figure = figure.GetSymbol() });
            }
            foreach (Figure figure in black_figures)
            {
                array.Add(new JsonModel() { y = figure.GetY(), x = figure.GetX(), figure = figure.GetSymbol() });
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
            if (fig.GetColor() == Colors.BLACK && IsUnderAttack(this.black_king.GetY(), this.black_king.GetX(), Colors.BLACK) > 0 || (fig.GetColor() == Colors.WHITE && IsUnderAttack(this.white_king.GetY(), this.white_king.GetX(), Colors.WHITE) > 0))
            {
                Move(fig, tempy, tempx);
                AddFigure(temp);
                return true;
            }
            Move(fig, tempy, tempx);
            AddFigure(temp);
            return false;
        }
        public bool IsCheckMate()
        {
            List<Figure> attack_figures = new List<Figure>();
            int count_attack;
            Figure king;
            if (Step == Colors.BLACK)
            {
                count_attack = IsUnderAttack(this.black_king.GetY(), this.black_king.GetX(), Colors.BLACK, attack_figures);
                king = black_king;
            }
            else
            {
                count_attack = IsUnderAttack(this.white_king.GetY(), this.white_king.GetX(), Colors.WHITE, attack_figures);
                king = white_king;
            }
            if (count_attack == 0) return false;
            else if (count_attack == 1 && attack_figures[0].GetType() != typeof(Knight))
            {
                Figure figure = attack_figures[0];
                if (figure.GetY() == king.GetY())
                {
                    int start_i = Math.Min(figure.GetX(), king.GetX());
                    int end_i = Math.Max(figure.GetX(), king.GetX());
                    for (int i = start_i; i < end_i; i++)
                    {
                        if (king.GetColor() == Colors.BLACK)
                        {
                            if (IsUnderAttack(king.GetY(), i, Colors.WHITE) > 0) return false;
                        }
                        else if (IsUnderAttack(king.GetY(), i, Colors.BLACK) > 0) return false;
                    }
                }
                else if (figure.GetX() == king.GetX())
                {
                    int start_i = Math.Min(figure.GetY(), king.GetY());
                    int end_i = Math.Max(figure.GetY(), king.GetY());
                    for (int i = start_i; i < end_i; i++)
                    {
                        if (king.GetColor() == Colors.BLACK)
                        {
                            if (IsUnderAttack(i, king.GetX(), Colors.WHITE) > 0) return false;
                        }
                        else if (IsUnderAttack(i, king.GetX(), Colors.BLACK) > 0) return false;
                    }
                }
                else
                {
                    int razn_x = king.GetX() - figure.GetX();
                    int razn_y = king.GetY() - figure.GetY();
                    for (int i = 1; i < Math.Abs(razn_x); i++)
                    {
                        if (king.GetColor() == Colors.BLACK)
                        {
                            if (IsUnderAttack(king.GetY() - i * (razn_y / Math.Abs(razn_y)), king.GetX() - i * (razn_x / Math.Abs(razn_x)), Colors.WHITE) > 0) return false;
                        }
                        else if (IsUnderAttack(king.GetY() - i * (razn_y / Math.Abs(razn_y)), king.GetX() - i * (razn_x / Math.Abs(razn_x)), Colors.BLACK) > 0) return false;
                    }
                }
            }
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (king.IsCanMove(king.GetY() + i, king.GetX() + j) > 0 && !IsCheck(king, king.GetY() + i, king.GetX() + j)) return false;
                }
            }
            return true;
        }
        public int IsUnderAttack(int y, int x, Colors color, List<Figure> who_attack=null)
        {
            int count_attack = 0;
            if (color == Colors.BLACK)
            {
                foreach (Figure figure in white_figures)
                {
                    if (figure.IsCanMove(y, x) > 0)
                    {
                        who_attack?.Add(figure);
                        count_attack++;
                    }
                }
            }
            else
            {
                foreach (Figure figure in black_figures)
                {
                    if (figure.IsCanMove(y, x) > 0)
                    {
                        who_attack?.Add(figure);
                        count_attack++;
                    }
                }
            }
            return count_attack;
        }
        public void Move(Figure fig, int y, int x)
        {
            if (fig != null)
            {
                RemoveFigure(GetFigure(y, x));
                fig.SetPos(y, x);
            }
        }
        public void EndMove()
        {
            count_steps++;
            ChangeColor();
        }
    }
}
