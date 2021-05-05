using Xunit;
using chess;
using System.Collections.Generic;
using System;

namespace Chess.Tests
{
    public class RookTests
    {
        int[][] valid_data = new int[][] { new int[] { 2, 3 },
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
            Figure rook = board.CreateNewFigure(y, x, Colors.BLACK, Figures.ROOK);

            List<int> result = new List<int>();

            foreach(int[] elem in valid_data)
            {
                result.Add(rook.IsCanMove(elem[0], elem[1]));
            }

            Assert.All(result, elem => Assert.Equal(1, elem));
        }
        [Fact]
        public void WrongPosMoveTest()
        {
            Board board = new Board();
            int y = 3;
            int x = 3;
            Figure rook = board.CreateNewFigure(y, x, Colors.BLACK, Figures.ROOK);
            List<int> result = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!Array.Exists<int[]>(valid_data, element => element[0] == i && element[1] == j)) result.Add(rook.IsCanMove(i, j));
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
            Figure rook = board.CreateNewFigure(y, x, Colors.BLACK, Figures.ROOK);
            Figure rook2 = board.CreateNewFigure(y+2, x, Colors.BLACK, Figures.ROOK);

            Assert.Equal(0, rook.IsCanMove(y+4, x));
        }
    }
}
