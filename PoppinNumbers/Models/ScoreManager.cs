namespace PoppinNumbers.Models
{
    public class ScoreManager
    {
        private int score = 0;
        private int enemyScore = 0;

        public void PrintScores()
        {
            Console.WriteLine($"Player Score: {score}");
            Console.WriteLine($"Enemy Score: {enemyScore}");
        }

        public void AwardPoints(int length)
        {
            if (length == 3)
            {
                score += 100;
            }
            else if (length == 4)
            {
                score += 200;
            }
            else if (length >= 5)
            {
                score += 500;
            }
        }

        public void DetermineWinner()
        {
            if (score > enemyScore)
            {
                Console.WriteLine("Player wins!");
            }
            else if (score < enemyScore)
            {
                Console.WriteLine("Enemy wins!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        }
    }
}
