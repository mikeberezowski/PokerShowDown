using PokerConsoleApp.Enums;
using PokerConsoleApp.Models;
using System.Linq;

namespace PokerConsoleApp.BusinessLogic
{
    public class HandComparer : IHandComparer
    {
        public Player CompareTwoHands(Player first, Player second)
        {
            if (first.BestHand > second.BestHand) return first;
            if (second.BestHand > first.BestHand) return second;

            // the two hands are the same. We compare high cards
            return CompareEqualHands(first, second);
        }

        private Player CompareEqualHands(Player first, Player second)
        {
            if (first.BestHand == PokerHandRank.Flush) return CompareHighCards(first, second);
            if (first.BestHand == PokerHandRank.ThreeOfAKind) return CompareThreeOfAKind(first, second);
            if (first.BestHand == PokerHandRank.OnePair) return CompareOnePair(first, second);
            return CompareHighCards(first, second);
        }

        private Player CompareThreeOfAKind(Player first, Player second)
        {
            var firstCard = first.Hand.histogram.FirstOrDefault(x => x.Value == 3).Key;
            var secondCard = second.Hand.histogram.FirstOrDefault(x => x.Value == 3).Key;

            if (firstCard == secondCard) return CompareHighCards(first, second);
            if (firstCard > secondCard) return first;
            return second;

        }
        private Player CompareOnePair(Player first, Player second)
        {
            var firstCard = first.Hand.histogram.FirstOrDefault(x => x.Value == 2).Key;
            var secondCard = second.Hand.histogram.FirstOrDefault(x => x.Value == 2).Key;

            if (firstCard == secondCard) return CompareHighCards(first, second);
            if (firstCard > secondCard) return first;
            return second;
        }
        private Player CompareHighCards(Player first, Player second)
        {
            for (var i = 0; i < first.Hand.Cards.Count; i++)
            {
                if (first.Hand.Cards[i].Number == second.Hand.Cards[i].Number) continue;
                if (first.Hand.Cards[i].Number > second.Hand.Cards[i].Number) return first;
                if (first.Hand.Cards[i].Number < second.Hand.Cards[i].Number) return second;
            }
            return first;
        }
    }
}
