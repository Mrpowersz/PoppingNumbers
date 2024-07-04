using PoppinNumbers.Models;

namespace PoppinNumbers.Controllers
{
    public class Player
    {
        public void TakeTurn(Board board)
        {
            int num = GetValidNumber("Enter the number to place: ");
            int row = GetValidCoordinate($"Enter the row (0-{board.BoardSize - 1}) to place the number: ", board.BoardSize);
            int col = GetValidCoordinate($"Enter the column (0-{board.BoardSize - 1}) to place the number: ", board.BoardSize);

            if (!board.PlaceNumber(num, row, col))
            {
                Console.WriteLine("Cell is already occupied, try again.");
                TakeTurn(board);
            }
        }

        private int GetValidNumber(string prompt)
        {
            int number;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out number))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
            return number;
        }

        private int GetValidCoordinate(string prompt, int maxSize)
        {
            int coordinate;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out coordinate) && coordinate >= 0 && coordinate < maxSize)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Please enter a valid number between 0 and {maxSize - 1}.");
                }
            }
            return coordinate;
        }
    }
}
