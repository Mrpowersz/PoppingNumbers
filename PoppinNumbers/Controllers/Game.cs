using PoppinNumbers.Models;

namespace PoppinNumbers.Controllers
{
    public class Game
    {
        private Board board;
        private Player player;
        private Computer computer;
        private ScoreManager scoreManager;

        public void Start()
        {
            SetupGame();
            while (true)
            {
                board.Print();
                scoreManager.PrintScores();
                player.TakeTurn(board);
                board.CheckAndClearLines(scoreManager);
                computer.TakeTurn(board, 3);
                board.CheckAndClearLines(scoreManager);
                computer.TakeTurn(board, 1);
                board.CheckAndClearLines(scoreManager);
                if (board.IsFull())
                {
                    Console.WriteLine("Game Over!");
                    board.Print();
                    scoreManager.PrintScores();
                    scoreManager.DetermineWinner();
                    break;
                }
            }
        }

        private void SetupGame()
        {
            board = new Board();
            player = new Player();
            computer = new Computer();
            scoreManager = new ScoreManager();
            board.Initialize();
        }
    }
}
