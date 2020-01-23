namespace RocksPaperScissorsLibrary.Hands
{
    public interface IHand
    {
        string Name();

        GameEvaluation.GameState Beats(IHand hand);

        string Action();
    }
}