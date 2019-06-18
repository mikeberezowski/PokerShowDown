using PokerConsoleApp.BusinessLogic;
using PokerConsoleApp.Enums;

namespace PokerConsoleApp.Models
{
    public class Player
    {
        private IRankCalculator rankCalculator;
        private readonly Deck gameDeck;

        public string Name { get; set; }
        public Hand Hand { get; set; }
        public PokerHandRank BestHand { get; set; }

        public Player(IRankCalculator calculator, Deck deck)
        {
            rankCalculator = calculator;
            gameDeck = deck;
        }

        public Player(IRankCalculator calculator, Deck deck, string name, string cards)
        {
            rankCalculator = calculator;
            gameDeck = deck;
            Name = name;
            Hand = new Hand(cards, gameDeck);
            BestHand = rankCalculator.CalculateBestHand(Hand);
        }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Name)) return false;

            return Hand.IsValid();
        }
    }
}
