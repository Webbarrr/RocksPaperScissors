using RocksPaperScissorsLibrary.Hands;
using System;

namespace RocksPaperScissorsConsole
{
    internal class Program
    {
        private static void Main()
        {
            var hand = new Hand();

            var playingGame = true;
            var random = new Random();

            while (playingGame)
            {
                var computersChoice = hand.GetHand(random);
                Game(computersChoice);
                playingGame = PlayAgain();
            }

            Console.WriteLine("Thank you for playing!");
        }

        private static void Game(IHand computersChoice)
        {
            var usersChoice = UserInput();

            // check that we had a valid input
            if (usersChoice == null)
                return;

            // display the state of the game
            var gameState = usersChoice.Beats(computersChoice);
            Console.WriteLine($"You {gameState.ToString()}");

            // leave if it's a draw
            if (gameState == GameEvaluation.GameState.Tie)
                return;

            var winningHand = gameState == GameEvaluation.GameState.Win ? usersChoice : computersChoice;
            var losingHand = gameState == GameEvaluation.GameState.Lose ? usersChoice : computersChoice;

            Console.WriteLine($"{winningHand.Name().ToUpper()} {winningHand.Action()} {losingHand.Name().ToUpper()}!");
        }

        private static IHand UserInput()
        {
            Console.WriteLine("Pick one - rock, paper or scissors or 'q' to quit.");

            while (true)
            {
                var response = Console.ReadLine().ToLower();

                switch (response)
                {
                    case "rock":
                        return new Rock();

                    case "paper":
                        return new Paper();

                    case "scissors":
                        return new Scissors();

                    case "q":
                        return null;

                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            }
        }

        private static bool PlayAgain()
        {
            Console.WriteLine("Play again? Y or N");

            while (true)
            {
                var userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "y":
                        return true;

                    case "n":
                        return false;

                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}