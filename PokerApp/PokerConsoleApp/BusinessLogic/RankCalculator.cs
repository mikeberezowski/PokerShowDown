using PokerConsoleApp.Enums;
using PokerConsoleApp.Models;

namespace PokerConsoleApp.BusinessLogic
{
    public class RankCalculator : IRankCalculator
    {
        public PokerHandRank CalculateBestHand(Hand hand)
        {
            if (IsFlush(hand)) return PokerHandRank.Flush;
            if (IsThreeOfAKind(hand)) return PokerHandRank.ThreeOfAKind;
            if (IsOnePair(hand)) return PokerHandRank.OnePair;

            return PokerHandRank.HighCard;
        }

        private bool IsFlush(Hand hand)
        {
            var suit = hand.Cards[0].Suit;
            foreach (var card in hand.Cards)
            {
                if (card.Suit != suit) return false;
            }

            return true;
        }

        private bool IsThreeOfAKind(Hand hand)
        {
            foreach (var hist in hand.histogram)
            {
                if (hist.Value == 3) return true;
            }

            return false;
        }

        private bool IsOnePair(Hand hand)
        {
            foreach (var hist in hand.histogram)
            {
                if (hist.Value == 2) return true;
            }

            return false;
        }
    }
}
