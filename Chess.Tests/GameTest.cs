using chess;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Chess.Tests
{
    public class GameTest
    {
        [Fact]
        public void ChessGameTest()
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
            GameBoard.CreateNewFigure(0, 3, Colors.WHITE, Figures.KING);
            GameBoard.CreateNewFigure(0, 4, Colors.WHITE, Figures.QUEEN);
            GameBoard.CreateNewFigure(0, 5, Colors.WHITE, Figures.BISHOP);
            GameBoard.CreateNewFigure(0, 6, Colors.WHITE, Figures.KNIGHT);
            GameBoard.CreateNewFigure(0, 7, Colors.WHITE, Figures.ROOK);
            GameBoard.CreateNewFigure(7, 0, Colors.BLACK, Figures.ROOK);
            GameBoard.CreateNewFigure(7, 1, Colors.BLACK, Figures.KNIGHT);
            GameBoard.CreateNewFigure(7, 2, Colors.BLACK, Figures.BISHOP);
            GameBoard.CreateNewFigure(7, 3, Colors.BLACK, Figures.KING);
            GameBoard.CreateNewFigure(7, 4, Colors.BLACK, Figures.QUEEN);
            GameBoard.CreateNewFigure(7, 5, Colors.BLACK, Figures.BISHOP);
            GameBoard.CreateNewFigure(7, 6, Colors.BLACK, Figures.KNIGHT);
            GameBoard.CreateNewFigure(7, 7, Colors.BLACK, Figures.ROOK);
            GameBoard.MoveFig(GameBoard.GetFigure(1, 1), 3, 1);
            GameBoard.MoveFig(GameBoard.GetFigure(6, 5), 4, 5);
            GameBoard.MoveFig(GameBoard.GetFigure(3, 1), 4, 1);
            GameBoard.MoveFig(GameBoard.GetFigure(6, 2), 5, 2);
            GameBoard.MoveFig(GameBoard.GetFigure(4, 1), 5, 2);
            GameBoard.MoveFig(GameBoard.GetFigure(7, 1), 5, 0);
            GameBoard.MoveFig(GameBoard.GetFigure(5, 2), 6, 1);
            GameBoard.MoveFig(GameBoard.GetFigure(7, 0), 7, 1);
            GameBoard.MoveFig(GameBoard.GetFigure(6, 1), 7, 2, Figures.QUEEN);
            GameBoard.MoveFig(GameBoard.GetFigure(7, 3), 7, 2);
            GameBoard.MoveFig(GameBoard.GetFigure(0, 1), 2, 2);
            GameBoard.MoveFig(GameBoard.GetFigure(5, 0), 3, 1);
            GameBoard.MoveFig(GameBoard.GetFigure(2, 2), 4, 1);
            GameBoard.MoveFig(GameBoard.GetFigure(3, 1), 5, 2);
            GameBoard.MoveFig(GameBoard.GetFigure(0, 2), 2, 0);
            GameBoard.MoveFig(GameBoard.GetFigure(5, 2), 3, 1);
            GameBoard.MoveFig(GameBoard.GetFigure(0, 3), 0, 1);
            GameBoard.MoveFig(GameBoard.GetFigure(3, 1), 1, 0);
            GameBoard.MoveFig(GameBoard.GetFigure(0, 1), 1, 0);
            GameBoard.MoveFig(GameBoard.GetFigure(6, 3), 5, 3);
            GameBoard.MoveFig(GameBoard.GetFigure(4, 1), 6, 0);
            GameBoard.MoveFig(GameBoard.GetFigure(7, 2), 6, 1);
            GameBoard.MoveFig(GameBoard.GetFigure(2, 0), 5, 3);
            GameBoard.MoveFig(GameBoard.GetFigure(6, 4), 4, 4);
            GameBoard.MoveFig(GameBoard.GetFigure(5, 3), 7, 1);
            GameBoard.MoveFig(GameBoard.GetFigure(6, 1), 7, 1);
            GameBoard.MoveFig(GameBoard.GetFigure(0, 2), 0, 1);
            GameBoard.MoveFig(GameBoard.GetFigure(7, 1), 6, 0);
            GameBoard.MoveFig(GameBoard.GetFigure(1, 3), 2, 3);
            GameBoard.MoveFig(GameBoard.GetFigure(7, 4), 3, 0);
            GameBoard.MoveFig(GameBoard.GetFigure(1, 0), 1, 1);
            GameBoard.MoveFig(GameBoard.GetFigure(3, 0), 1, 2);
            GameBoard.MoveFig(GameBoard.GetFigure(1, 1), 1, 2);
            GameBoard.MoveFig(GameBoard.GetFigure(4, 4), 3, 4);
            GameBoard.MoveFig(GameBoard.GetFigure(1, 5), 3, 5);
            GameBoard.MoveFig(GameBoard.GetFigure(3, 4), 2, 5);
            GameBoard.MoveFig(GameBoard.GetFigure(1, 4), 2, 5);
            GameBoard.MoveFig(GameBoard.GetFigure(4, 5), 3, 5);
            GameBoard.MoveFig(GameBoard.GetFigure(1, 6), 2, 6);
            GameBoard.MoveFig(GameBoard.GetFigure(3, 5), 2, 6);
            GameBoard.MoveFig(GameBoard.GetFigure(1, 7), 2, 7);
            GameBoard.MoveFig(GameBoard.GetFigure(2, 6), 1, 6);
            GameBoard.MoveFig(GameBoard.GetFigure(0, 5), 1, 4);
            GameBoard.MoveFig(GameBoard.GetFigure(1, 6), 0, 7, Figures.QUEEN);
            GameBoard.MoveFig(GameBoard.GetFigure(2, 5), 3, 5);
            GameBoard.MoveFig(GameBoard.GetFigure(0, 7), 5, 2);
            GameBoard.MoveFig(GameBoard.GetFigure(1, 2), 1, 3);
            GameBoard.MoveFig(GameBoard.GetFigure(7, 5), 3, 1);
            GameBoard.MoveFig(GameBoard.GetFigure(1, 3), 2, 4);
            GameBoard.MoveFig(GameBoard.GetFigure(3, 1), 0, 4);
            GameBoard.MoveFig(GameBoard.GetFigure(0, 6), 2, 5);
            GameBoard.MoveFig(GameBoard.GetFigure(5, 2), 2, 5);
            GameBoard.MoveFig(GameBoard.GetFigure(2, 4), 2, 5);
            GameBoard.MoveFig(GameBoard.GetFigure(0, 4), 4, 0);
            GameBoard.MoveFig(GameBoard.GetFigure(2, 3), 3, 3);
            GameBoard.MoveFig(GameBoard.GetFigure(7, 6), 5, 5);
            GameBoard.MoveFig(GameBoard.GetFigure(3, 3), 4, 3);
            GameBoard.MoveFig(GameBoard.GetFigure(5, 5), 4, 3);
            GameBoard.MoveFig(GameBoard.GetFigure(2, 5), 3, 4);
            GameBoard.MoveFig(GameBoard.GetFigure(6, 7), 5, 7);
            GameBoard.MoveFig(GameBoard.GetFigure(3, 5), 4, 5);
            GameBoard.MoveFig(GameBoard.GetFigure(6, 6), 4, 6);
            GameBoard.MoveFig(GameBoard.GetFigure(4, 5), 5, 6);
            GameBoard.MoveFig(GameBoard.GetFigure(4, 3), 3, 5);
            GameBoard.MoveFig(GameBoard.GetFigure(5, 6), 6, 6);
            GameBoard.MoveFig(GameBoard.GetFigure(7, 7), 7, 6);
            GameBoard.MoveFig(GameBoard.GetFigure(3, 4), 3, 5);
            GameBoard.MoveFig(GameBoard.GetFigure(7, 6), 6, 6);
            GameBoard.MoveFig(GameBoard.GetFigure(2, 7), 3, 7);
            GameBoard.MoveFig(GameBoard.GetFigure(6, 6), 6, 5);
            GameBoard.MoveFig(GameBoard.GetFigure(3, 5), 3, 6);
            GameBoard.MoveFig(GameBoard.GetFigure(6, 5), 6, 6);
            GameBoard.MoveFig(GameBoard.GetFigure(3, 6), 4, 7);
            GameBoard.MoveFig(GameBoard.GetFigure(6, 6), 6, 1);
            GameBoard.MoveFig(GameBoard.GetFigure(0, 1), 6, 1);
            GameBoard.MoveFig(GameBoard.GetFigure(6, 0), 6, 1);
            GameBoard.MoveFig(GameBoard.GetFigure(4, 7), 5, 7);
            GameBoard.MoveFig(GameBoard.GetFigure(4, 0), 1, 3);
            GameBoard.MoveFig(GameBoard.GetFigure(5, 7), 5, 6);
            GameBoard.MoveFig(GameBoard.GetFigure(1, 3), 0, 2);
            GameBoard.MoveFig(GameBoard.GetFigure(3, 7), 4, 7);
            GameBoard.MoveFig(GameBoard.GetFigure(0, 2), 1, 3);
            GameBoard.MoveFig(GameBoard.GetFigure(4, 7), 5, 7);
            GameBoard.MoveFig(GameBoard.GetFigure(1, 3), 0, 2);
            GameBoard.MoveFig(GameBoard.GetFigure(5, 6), 5, 5);
            GameBoard.MoveFig(GameBoard.GetFigure(0, 2), 5, 7);
            string[,] result = new string[8,8];
            GameBoard.GetFieldData(ref result);
            string[,] answer = new string[8, 8] { { null, null, null, null, null, null, null, null },
                                                  { null, null, null, null, "wB", null, null, null },
                                                  { null, null, null, null, null, null, null, null },
                                                  { null, null, null, null, null, null, null, null },
                                                  { null, null, null, null, null, null, null, null },
                                                  { null, null, null, null, null, "wK", null, "bB" },
                                                  { null, "bK", null, null, null, null, null, null },
                                                  { null, null, null, null, null, null, null, null } };

            Assert.Equal(answer, result);
        }
    }
}
