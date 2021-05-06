using Xunit;
using chess;
using System.Collections.Generic;
using System;

namespace Chess.Tests
{
    public class KingTests
    {
        int[][] valid_data = new int[][] { new int[] { 2, 3 },
                                           new int[] { 3, 2 },
                                           new int[] { 2, 2 },
                                           new int[] { 3, 4 },
                                           new int[] { 4, 3 },
                                           new int[] { 4, 4 },
                                           new int[] { 4, 2 },
                                           new int[] { 2, 4 }};
        [Fact]
        public void ValidPosMoveTest()
        {
            Board board = new Board();
            int y = 3;
            int x = 3;
            Figure king = board.CreateNewFigure(y, x, Colors.BLACK, Figures.KING);

            List<int> result = new List<int>();

            foreach (int[] elem in valid_data)
            {
                result.Add(king.IsCanMove(elem[0], elem[1]));
            }

            Assert.All(result, elem => Assert.Equal(1, elem));
        }
        [Fact]
        public void WrongPosMoveTest()
        {
            Board board = new Board();
            int y = 3;
            int x = 3;
            Figure king = board.CreateNewFigure(y, x, Colors.BLACK, Figures.KING);

            List<int> result = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!Array.Exists<int[]>(valid_data, element => element[0] == i && element[1] == j)) result.Add(king.IsCanMove(i, j));
                }
            }

            Assert.All(result, elem => Assert.Equal(0, elem));
        }
        [Fact]
        public void MoveToUnderAttack()
        {
            Board board = new Board();
            int y = 3;
            int x = 3;
            Figure king = board.CreateNewFigure(y, x, Colors.WHITE, Figures.KING);
            Figure enemy = board.CreateNewFigure(y + 1, x + 1, Colors.BLACK, Figures.ROOK);
            Figure enemy2 = board.CreateNewFigure(y - 2, x, Colors.BLACK, Figures.KING);

            List<int> result = new List<int>();

            result.Add(king.Move(y + 1, x));
            result.Add(king.Move(y - 1, x));

            List<int> answer = new List<int> { 0, 0 };
            Assert.Equal<int>(result, answer);
        }
        [Fact]
        public void MoveCastling()
        {
            Board board = new Board();
            int y = 0;
            int x = 3;
            Figure king = board.CreateNewFigure(y, x, Colors.WHITE, Figures.KING);
            Figure rook1 = board.CreateNewFigure(0, 0, Colors.WHITE, Figures.ROOK);
            Figure rook2 = board.CreateNewFigure(0, 7, Colors.WHITE, Figures.ROOK);
            Figure queen = board.CreateNewFigure(0, 4, Colors.WHITE, Figures.QUEEN);

            Figure king2 = board.CreateNewFigure(7, 3, Colors.BLACK, Figures.KING);
            Figure rook21 = board.CreateNewFigure(7, 0, Colors.BLACK, Figures.ROOK);
            Figure rook22 = board.CreateNewFigure(7, 7, Colors.BLACK, Figures.ROOK);
            Figure queen2 = board.CreateNewFigure(5, 3, Colors.WHITE, Figures.QUEEN);

            List<int> result = new List<int>();

            result.Add(king.Move(y, x + 2));
            result.Add(king.Move(y, x - 2));
            result.Add(king2.Move(7, 1));
            result.Add(king2.Move(7, 5));

            List<int> answer = new List<int> { 0, 1, 0, 0 };
            Assert.Equal<int>(result, answer);
        }
    }
}
