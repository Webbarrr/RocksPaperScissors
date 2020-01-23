namespace RocksPaperScissorsLibrary.Hands
{
    public class Paper : IHand
    {
        public string Action()
        {
            return "covers";
        }

        public string Name()
        {
            return "paper";
        }

        public GameEvaluation.GameState Beats(IHand hand)
        {
            switch (hand.Name())
            {
                case "paper":
                    return GameEvaluation.GameState.Tie;

                case "scissors":
                    return GameEvaluation.GameState.Lose;

                default:
                    return GameEvaluation.GameState.Win;
            }
        }
    }
}