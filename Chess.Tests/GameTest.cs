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
            Board GameBoard = Board.CreateChessBoard();
            GameBoard.GetFigure(1, 1).Move(3, 1);
            GameBoard.GetFigure(6, 5).Move(4, 5);
            GameBoard.GetFigure(3, 1).Move(4, 1);
            GameBoard.GetFigure(6, 2).Move(5, 2);
            GameBoard.GetFigure(4, 1).Move(5, 2);
            GameBoard.GetFigure(7, 1).Move(5, 0);
            GameBoard.GetFigure(5, 2).Move(6, 1);
            GameBoard.GetFigure(7, 0).Move(7, 1);
            (GameBoard.GetFigure(6, 1) as Pawn).Move(7, 2, Figures.QUEEN);
            GameBoard.GetFigure(7, 3).Move(7, 2);
            GameBoard.GetFigure(0, 1).Move(2, 2);
            GameBoard.GetFigure(5, 0).Move(3, 1);
            GameBoard.GetFigure(2, 2).Move(4, 1);
            GameBoard.GetFigure(3, 1).Move(5, 2);
            GameBoard.GetFigure(0, 2).Move(2, 0);
            GameBoard.GetFigure(5, 2).Move(3, 1);
            GameBoard.GetFigure(0, 3).Move(0, 1);
            GameBoard.GetFigure(3, 1).Move(1, 0);
            GameBoard.GetFigure(0, 1).Move(1, 0);
            GameBoard.GetFigure(6, 3).Move(5, 3);
            GameBoard.GetFigure(4, 1).Move(6, 0);
            GameBoard.GetFigure(7, 2).Move(6, 1);
            GameBoard.GetFigure(2, 0).Move(5, 3);
            GameBoard.GetFigure(6, 4).Move(4, 4);
            GameBoard.GetFigure(5, 3).Move(7, 1);
            GameBoard.GetFigure(6, 1).Move(7, 1);
            GameBoard.GetFigure(0, 2).Move(0, 1);
            GameBoard.GetFigure(7, 1).Move(6, 0);
            GameBoard.GetFigure(1, 3).Move(2, 3);
            GameBoard.GetFigure(7, 4).Move(3, 0);
            GameBoard.GetFigure(1, 0).Move(1, 1);
            GameBoard.GetFigure(3, 0).Move(1, 2);
            GameBoard.GetFigure(1, 1).Move(1, 2);
            GameBoard.GetFigure(4, 4).Move(3, 4);
            GameBoard.GetFigure(1, 5).Move(3, 5);
            GameBoard.GetFigure(3, 4).Move(2, 5);
            GameBoard.GetFigure(1, 4).Move(2, 5);
            GameBoard.GetFigure(4, 5).Move(3, 5);
            GameBoard.GetFigure(1, 6).Move(2, 6);
            GameBoard.GetFigure(3, 5).Move(2, 6);
            GameBoard.GetFigure(1, 7).Move(2, 7);
            GameBoard.GetFigure(2, 6).Move(1, 6);
            GameBoard.GetFigure(0, 5).Move(1, 4);
            (GameBoard.GetFigure(1, 6) as Pawn).Move(0, 7, Figures.QUEEN);
            GameBoard.GetFigure(2, 5).Move(3, 5);
            GameBoard.GetFigure(0, 7).Move(5, 2);
            GameBoard.GetFigure(1, 2).Move(1, 3);
            GameBoard.GetFigure(7, 5).Move(3, 1);
            GameBoard.GetFigure(1, 3).Move(2, 4);
            GameBoard.GetFigure(3, 1).Move(0, 4);
            GameBoard.GetFigure(0, 6).Move(2, 5);
            GameBoard.GetFigure(5, 2).Move(2, 5);
            GameBoard.GetFigure(2, 4).Move(2, 5);
            GameBoard.GetFigure(0, 4).Move(4, 0);
            GameBoard.GetFigure(2, 3).Move(3, 3);
            GameBoard.GetFigure(7, 6).Move(5, 5);
            GameBoard.GetFigure(3, 3).Move(4, 3);
            GameBoard.GetFigure(5, 5).Move(4, 3);
            GameBoard.GetFigure(2, 5).Move(3, 4);
            GameBoard.GetFigure(6, 7).Move(5, 7);
            GameBoard.GetFigure(3, 5).Move(4, 5);
            GameBoard.GetFigure(6, 6).Move(4, 6);
            GameBoard.GetFigure(4, 5).Move(5, 6);
            GameBoard.GetFigure(4, 3).Move(3, 5);
            GameBoard.GetFigure(5, 6).Move(6, 6);
            GameBoard.GetFigure(7, 7).Move(7, 6);
            GameBoard.GetFigure(3, 4).Move(3, 5);
            GameBoard.GetFigure(7, 6).Move(6, 6);
            GameBoard.GetFigure(2, 7).Move(3, 7);
            GameBoard.GetFigure(6, 6).Move(6, 5);
            GameBoard.GetFigure(3, 5).Move(3, 6);
            GameBoard.GetFigure(6, 5).Move(6, 6);
            GameBoard.GetFigure(3, 6).Move(4, 7);
            GameBoard.GetFigure(6, 6).Move(6, 1);
            GameBoard.GetFigure(0, 1).Move(6, 1);
            GameBoard.GetFigure(6, 0).Move(6, 1);
            GameBoard.GetFigure(4, 7).Move(5, 7);
            GameBoard.GetFigure(4, 0).Move(1, 3);
            GameBoard.GetFigure(5, 7).Move(5, 6);
            GameBoard.GetFigure(1, 3).Move(0, 2);
            GameBoard.GetFigure(3, 7).Move(4, 7);
            GameBoard.GetFigure(0, 2).Move(1, 3);
            GameBoard.GetFigure(4, 7).Move(5, 7);
            GameBoard.GetFigure(1, 3).Move(0, 2);
            GameBoard.GetFigure(5, 6).Move(5, 5);
            GameBoard.GetFigure(0, 2).Move(5, 7);
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
