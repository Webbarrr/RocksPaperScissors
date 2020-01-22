using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocksPaperScissorsLibrary.Hands
{
    public class Hand
    {
        private readonly List<IHand> _hands = new List<IHand>();
        private Random _random = new Random();

        public Hand()
        {
            _hands.Add(new Rock());
            _hands.Add(new Paper());
            _hands.Add(new Scissors());
        }

        public IHand GetHand(Random random)
        {
            var randomNumber = random.Next(_hands.Count());
            return _hands[randomNumber];
        }
    }

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

        public bool Beats(IHand hand)
        {
            return hand.Name() == "scissors";
        }
    }

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

        public bool Beats(IHand hand)
        {
            return hand.Name() == "rock";
        }
    }

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

        public bool Beats(IHand hand)
        {
            return hand.Name() == "paper";
        }
    }

    public interface IHand
    {
        string Name();
        bool Beats(IHand hand);
        string Action();
    }
}
