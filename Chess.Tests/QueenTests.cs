using Xunit;
using chess;
using System.Collections.Generic;
using System;

namespace Chess.Tests
{
    public class QueenTests
    {
        int[][] valid_data = new int[][] { new int[] { 2, 2 },
                                           new int[] { 1, 1 },
                                           new int[] { 0, 0 },
                                           new int[] { 2, 4 },
                                           new int[] { 1, 5 },
                                           new int[] { 0, 6 },
                                           new int[] { 4, 4 },
                                           new int[] { 5, 5 },
                                           new int[] { 6, 6 },
                                           new int[] { 7, 7 },
                                           new int[] { 4, 2 },
                                           new int[] { 5, 1 },
                                           new int[] { 6, 0 },
                                           new int[] { 2, 3 },
                                           new int[] { 1, 3 },
                                           new int[] { 0, 3 },
                                           new int[] { 3, 2 },
                                           new int[] { 3, 1 },
                                           new int[] { 3, 0 },
                                           new int[] { 4, 3 },
                                           new int[] { 5, 3 },
                                           new int[] { 6, 3 },
                                           new int[] { 7, 3 },
                                           new int[] { 3, 4 },
                                           new int[] { 3, 5 },
                                           new int[] { 3, 6 },
                                           new int[] { 3, 7 }};
        [Fact]
        public void ValidPosMoveTest()
        {
            Board board = new Board();
            int y = 3;
            int x = 3;
            Figure queen = board.CreateNewFigure(y, x, Colors.BLACK, Figures.QUEEN);

            List<int> result = new List<int>();

            foreach (int[] elem in valid_data)
            {
                result.Add(queen.IsCanMove(elem[0], elem[1]));
            }

            Assert.All(result, elem => Assert.Equal(1, elem));
        }
        [Fact]
        public void WrongPosMoveTest()
        {
            Board board = new Board();
            int y = 3;
            int x = 3;
            Figure queen = board.CreateNewFigure(y, x, Colors.BLACK, Figures.QUEEN);
            List<int> result = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!Array.Exists<int[]>(valid_data, element => element[0] == i && element[1] == j)) result.Add(queen.IsCanMove(i, j));
                }
            }

            Assert.All(result, elem => Assert.Equal(0, elem));
        }
        [Fact]
        public void MoveBehindFigureTest()
        {
            Board board = new Board();
            int y = 3;
            int x = 3;
            Figure queen = board.CreateNewFigure(y, x, Colors.BLACK, Figures.QUEEN);
            Figure rook2 = board.CreateNewFigure(y + 2, x, Colors.BLACK, Figures.ROOK);
            Figure bishop2 = board.CreateNewFigure(y + 2, x + 2, Colors.BLACK, Figures.BISHOP);

            Assert.Equal(0, queen.IsCanMove(y + 4, x));
            Assert.Equal(0, queen.IsCanMove(y + 4, x + 4));
        }
    }
}
