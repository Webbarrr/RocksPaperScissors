namespace RocksPaperScissorsLibrary.Hands
{
    public class Scissors : IHand
    {
        public string Action()
        {
            return "cuts";
        }

        public string Name()
        {
            return "scissors";
        }

        public GameEvaluation.GameState Beats(IHand hand)
        {
            switch (hand.Name())
            {
                case "scissors":
                    return GameEvaluation.GameState.Tie;

                case "rock":
                    return GameEvaluation.GameState.Lose;

                default:
                    return GameEvaluation.GameState.Win;
            }
        }
    }
}