namespace PoppinNumbers.Models
{
    public class Board
    {
        public int BoardSize { get; private set; }
        public List<int> NumbersInPlay { get; private set; } = new List<int>();
        private int[,] board;
        private char[,] predictors;

        public void Initialize()
        {
            BoardSize = GetBoardSize();
            board = new int[BoardSize, BoardSize];
            predictors = new char[BoardSize, BoardSize];
            NumbersInPlay = GetNumbersInPlay();
        }

        private int GetBoardSize()
        {
            int size;
            while (true)
            {
                Console.WriteLine("Enter board size (between 5 and 25): ");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out size) && size >= 5 && size <= 25)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number between 5 and 25.");
                }
            }
            return size;
        }

        private List<int> GetNumbersInPlay()
        {
            List<int> numbers = new List<int>();
            while (numbers.Count == 0)
            {
                Console.WriteLine("Enter the numbers to use (0-9), separated by spaces: ");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    string[] numberStrings = input.Split(' ');
                    foreach (string num in numberStrings)
                    {
                        if (int.TryParse(num, out int n) && n >= 0 && n <= 9)
                        {
                            numbers.Add(n);
                        }
                    }
                }
                if (numbers.Count == 0)
                {
                    Console.WriteLine("Please enter valid numbers (0-9).");
                }
            }
            return numbers;
        }

        public void Print()
        {
            Console.Clear();
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    if (board[row, col] == 0 && predictors[row, col] == '*')
                    {
                        Console.Write("* ");
                    }
                    else if (board[row, col] != 0)
                    {
                        Console.Write($"{GetColoredNumber(board[row, col])} ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }
        }

        public bool IsFull()
        {
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    if (board[row, col] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void CheckAndClearLines(ScoreManager scoreManager)
        {
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col <= BoardSize - 3; col++)
                {
                    if (board[row, col] != 0 &&
                        board[row, col] == board[row, col + 1] &&
                        board[row, col] == board[row, col + 2])
                    {
                        int length = 3;
                        while (col + length < BoardSize && board[row, col] == board[row, col + length])
                        {
                            length++;
                        }
                        scoreManager.AwardPoints(length);
                        ClearLine(row, col, length, true);
                        col += length - 1;
                    }
                }
            }

            for (int col = 0; col < BoardSize; col++)
            {
                for (int row = 0; row <= BoardSize - 3; row++)
                {
                    if (board[row, col] != 0 &&
                        board[row, col] == board[row + 1, col] &&
                        board[row, col] == board[row + 2, col])
                    {
                        int length = 3;
                        while (row + length < BoardSize && board[row, col] == board[row + length, col])
                        {
                            length++;
                        }
                        scoreManager.AwardPoints(length);
                        ClearLine(row, col, length, false);
                        row += length - 1;
                    }
                }
            }
        }

        public bool PlaceNumber(int num, int row, int col)
        {
            if (board[row, col] == 0)
            {
                board[row, col] = num;
                predictors[row, col] = ' ';
                return true;
            }
            return false;
        }

        private void ClearLine(int row, int col, int length, bool isRow)
        {
            for (int i = 0; i < length; i++)
            {
                if (isRow)
                {
                    board[row, col + i] = 0;
                }
                else
                {
                    board[row + i, col] = 0;
                }
            }
        }

        private string GetColoredNumber(int number)
        {
            switch (number)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 0:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
            return number.ToString();
        }
    }
}

