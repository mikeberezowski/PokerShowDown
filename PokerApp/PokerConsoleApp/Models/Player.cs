using PokerConsoleApp.BusinessLogic;
using PokerConsoleApp.Enums;

namespace PokerConsoleApp.Models
{
    public class Player
    {
        private IRankCalculator rankCalculator;

        public string Name { get; set; }

        public Hand Hand { get; set; }

        public PokerHandRank BestHand { get; set; }

        public Player(IRankCalculator calculator)
        {
            
            rankCalculator = calculator;
        }

        public Player(IRankCalculator calculator, string name, string cards)
        {
            rankCalculator = calculator;
            Name = name;
            Hand = new Hand(cards);
            BestHand = rankCalculator.CalculateBestHand(Hand);
        }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Name)) return false;

            return Hand.IsValid();
        }
    }
}
