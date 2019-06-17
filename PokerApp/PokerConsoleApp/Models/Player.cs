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

        public Player()
        {
            rankCalculator = new RankCalculator();
        }

        public Player(string name, string cards) : base()
        {
            rankCalculator = new RankCalculator();
            Name = name;
            Hand = new Hand(cards);
            BestHand = rankCalculator.CalculateBestHand(Hand);
        }
    }
}
