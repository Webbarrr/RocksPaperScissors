using System;
using System.Collections.Generic;
using System.Linq;

namespace RocksPaperScissorsLibrary.Hands
{
    public class Hand
    {
        private readonly List<IHand> _hands = new List<IHand>();

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
}