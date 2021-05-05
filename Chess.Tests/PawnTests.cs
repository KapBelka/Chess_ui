using Xunit;
using chess;
using System.Collections.Generic;

namespace Chess.Tests
{
    public class PawnTests
    {
        [Fact]
        public void ValidPosMoveTest()
        {
            Board board = new Board();
            int y = 3;
            int x = 3;
            Figure pawn = board.CreateNewFigure(y, x, Colors.WHITE, Figures.PAWN);

            List<int> result = new List<int>();

            result.Add(pawn.IsCanMove(4, 3));
            result.Add(pawn.IsCanMove(5, 3));

            List<int> answer = new List<int> { 1, 2 };
            Assert.Equal<int>(answer, result);
        }
        [Fact]
        public void WrongPosMoveTest()
        {
            Board board = new Board();
            int y = 3;
            int x = 3;
            Figure pawn = board.CreateNewFigure(y, x, Colors.WHITE, Figures.PAWN);

            List<int> result = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i == 4 && j == 3) || (i == 5 && j == 3)) continue;
                    result.Add(pawn.IsCanMove(i, j));
                }
            }

            Assert.All(result, elem => Assert.Equal(0, elem));
        }
        [Fact]
        public void ValidAttackTest()
        {
            Board board = new Board();
            int y = 3;
            int x = 3;
            Figure pawn = board.CreateNewFigure(y, x, Colors.WHITE, Figures.PAWN);
            Figure enemy1 = board.CreateNewFigure(y + 1, x - 1, Colors.BLACK, Figures.PAWN);
            Figure enemy2 = board.CreateNewFigure(y + 1, x + 1, Colors.BLACK, Figures.PAWN);

            List<int> result = new List<int>();

            result.Add(pawn.IsCanMove(y + 1, x - 1));
            result.Add(pawn.IsCanMove(y + 1, x + 1));

            List<int> answer = new List<int> { 3, 3 };
            Assert.Equal<int>(answer, result);
        }
        [Fact]
        public void WrongAttackTest()
        {
            Board board = new Board();
            int y = 3;
            int x = 3;
            Figure pawn = board.CreateNewFigure(y, x, Colors.WHITE, Figures.PAWN);
            Figure enemy1 = board.CreateNewFigure(y, x - 1, Colors.BLACK, Figures.PAWN);
            Figure enemy2 = board.CreateNewFigure(y, x + 1, Colors.BLACK, Figures.PAWN);
            Figure enemy3 = board.CreateNewFigure(y + 1, x - 1, Colors.WHITE, Figures.PAWN);
            Figure enemy4 = board.CreateNewFigure(y + 1, x + 1, Colors.BLACK, Figures.PAWN);

            List<int> result = new List<int>();

            result.Add(pawn.IsCanMove(y + 1, x - 1));
            result.Add(pawn.IsCanMove(y + 1, x + 1));

            List<int> answer = new List<int> { 0, 3 };
            Assert.Equal<int>(answer, result);
        }
        [Fact]
        public void ValidAttack2Test()
        {
            Board board = new Board();
            board.CreateNewFigure(0, 0, Colors.WHITE, Figures.KING);
            board.CreateNewFigure(7, 7, Colors.BLACK, Figures.KING);
            int y = 3;
            int x = 3;
            Figure pawn = board.CreateNewFigure(y-2, x, Colors.WHITE, Figures.PAWN);
            Figure enemy1 = board.CreateNewFigure(y + 2, x - 1, Colors.BLACK, Figures.PAWN);
            Figure enemy2 = board.CreateNewFigure(y + 2, x + 1, Colors.BLACK, Figures.PAWN);
            board.MoveFig(pawn, y-1, x);
            board.MoveFig(enemy1, y, x - 1);
            board.MoveFig(pawn, y, x);
            board.MoveFig(enemy2, y, x + 1);

            List<int> result = new List<int>();

            result.Add(pawn.IsCanMove(y + 1, x - 1));
            result.Add(pawn.IsCanMove(y + 1, x + 1));

            List<int> answer = new List<int> { 0, 4 };
            Assert.Equal<int>(answer, result);
        }
        [Fact]
        public void TransformTest()
        {
            Board board = new Board();
            int y = 6;
            int x = 3;
            board.CreateNewFigure(0, 0, Colors.WHITE, Figures.KING);
            board.CreateNewFigure(7, 7, Colors.BLACK, Figures.KING);
            Figure pawn = board.CreateNewFigure(y, x, Colors.WHITE, Figures.PAWN);
            List<int> result = new List<int>();
            result.Add(pawn.IsCanMove(7, 3));
            result.Add(board.MoveFig(pawn, 7, 3));
            result.Add(board.MoveFig(pawn, 7, 3, Figures.QUEEN));
            result.Add(board.GetFigure(7, 3).GetType() == typeof(Queen) ? 1 : 0);

            List<int> answer = new List<int> { 1, -1, 1, 1};
            Assert.Equal<int>(answer, result);
        }
    }
}
