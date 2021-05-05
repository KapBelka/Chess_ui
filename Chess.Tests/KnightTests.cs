using Xunit;
using chess;
using System.Collections.Generic;
using System;

namespace Chess.Tests
{
    public class KnightTests
    {
        int[][] valid_data = new int[][] { new int[] { 1, 2 },
                                           new int[] { 1, 4 },
                                           new int[] { 2, 1 },
                                           new int[] { 4, 1 },
                                           new int[] { 5, 2 },
                                           new int[] { 5, 4 },
                                           new int[] { 4, 5 },
                                           new int[] { 2, 5 }};
        [Fact]
        public void ValidPosMoveTest()
        {
            Board board = new Board();
            int y = 3;
            int x = 3;
            Figure knight = board.CreateNewFigure(y, x, Colors.BLACK, Figures.KNIGHT);

            List<int> result = new List<int>();

            foreach (int[] elem in valid_data)
            {
                result.Add(knight.IsCanMove(elem[0], elem[1]));
            }

            Assert.All(result, elem => Assert.Equal(1, elem));
        }
        [Fact]
        public void WrongPosMoveTest()
        {
            Board board = new Board();
            int y = 3;
            int x = 3;
            Figure knight = board.CreateNewFigure(y, x, Colors.BLACK, Figures.KNIGHT);

            List<int> result = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!Array.Exists<int[]>(valid_data, element => element[0] == i && element[1] == j)) result.Add(knight.IsCanMove(i, j));
                }
            }

            Assert.All(result, elem => Assert.Equal(0, elem));
        }
        [Fact]
        public void WrongAttackTest()
        {
            Board board = new Board();
            int y = 3;
            int x = 3;
            Figure knight = board.CreateNewFigure(y, x, Colors.BLACK, Figures.KNIGHT);
            Figure enemy = board.CreateNewFigure(1, 2, Colors.BLACK, Figures.KNIGHT);

            int result = knight.IsCanMove(1, 2);

            Assert.Equal(0, result);
        }
        [Fact]
        public void ValidAttackTest()
        {
            Board board = new Board();
            int y = 3;
            int x = 3;
            Figure knight = board.CreateNewFigure(y, x, Colors.BLACK, Figures.KNIGHT);
            Figure enemy = board.CreateNewFigure(1, 2, Colors.WHITE, Figures.KNIGHT);

            int result = knight.IsCanMove(1, 2);

            Assert.Equal(1, result);
        }
    }
}
