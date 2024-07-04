using PoppinNumbers.Models;

namespace PoppinNumbers.Controllers
{
    public class Computer
    {
        private Random random = new Random();

        public void TakeTurn(Board board, int numberOfMoves)
        {
            int placed = 0;
            while (placed < numberOfMoves)
            {
                int num = board.NumbersInPlay[random.Next(board.NumbersInPlay.Count)];
                int row = random.Next(board.BoardSize);
                int col = random.Next(board.BoardSize);

                if (board.PlaceNumber(num, row, col))
                {
                    placed++;
                }
            }
        }
    }
}
