using RocksPaperScissorsLibrary.Hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocksPaperScissorsConsole
{
    class Program
    {
        static void Main()
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

        static void Game(IHand computersChoice)
        {
            var usersChoice = UserInput();

            // check that we had a valid input
            if (usersChoice == null)
            {
                return;
            }

            // it's a draw
            if (usersChoice.Name() == computersChoice.Name())
            {
                Console.WriteLine("Tie!");
                return;
            }

            // it's not a draw
            if (usersChoice.Beats(computersChoice))
            {
                Console.WriteLine("You win!");
                Console.WriteLine($"{usersChoice.Name().ToUpper()} {usersChoice.Action()} {computersChoice.Name().ToUpper()}!");
            }
            else
            {
                Console.WriteLine("You lose!");
                Console.WriteLine($"{computersChoice.Name().ToUpper()} {computersChoice.Action()} {usersChoice.Name().ToUpper()}!");
            }
        }

        static IHand UserInput()
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

        static bool PlayAgain()
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
