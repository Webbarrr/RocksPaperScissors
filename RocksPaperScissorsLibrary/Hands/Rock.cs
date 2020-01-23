namespace RocksPaperScissorsLibrary.Hands
{
    public class Rock : IHand
    {
        public string Action()
        {
            return "smashes";
        }

        public string Name()
        {
            return "rock";
        }

        public GameEvaluation.GameState Beats(IHand hand)
        {
            switch (hand.Name())
            {
                case "rock":
                    return GameEvaluation.GameState.Tie;

                case "paper":
                    return GameEvaluation.GameState.Lose;

                default:
                    return GameEvaluation.GameState.Win;
            }
        }
    }
}