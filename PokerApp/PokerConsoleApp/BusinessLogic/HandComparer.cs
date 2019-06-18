using PokerConsoleApp.Enums;
using PokerConsoleApp.Models;
using System.Linq;

namespace PokerConsoleApp.BusinessLogic
{
    public class HandComparer : IHandComparer
    {
        public int CompareTwoHands(Player first, Player second)
        {
            if (first.BestHand > second.BestHand) return 1;
            if (second.BestHand > first.BestHand) return 2;

            // the two hands are the same. We compare high cards
            return CompareEqualHands(first, second);
        }

        private int CompareEqualHands(Player first, Player second)
        {
            if (first.BestHand == PokerHandRank.Flush) return CompareHighCards(first, second);
            if (first.BestHand == PokerHandRank.ThreeOfAKind) return CompareThreeOfAKind(first, second);
            if (first.BestHand == PokerHandRank.OnePair) return CompareOnePair(first, second);
            return CompareHighCards(first, second);
        }

        private int CompareThreeOfAKind(Player first, Player second)
        {
            var firstCard = first.Hand.histogram.FirstOrDefault(x => x.Value == 3).Key;
            var secondCard = second.Hand.histogram.FirstOrDefault(x => x.Value == 3).Key;

            if (firstCard == secondCard) return CompareHighCards(first, second);
            if (firstCard > secondCard) return 1;
            return 2;

        }

        private int CompareOnePair(Player first, Player second)
        {
            var firstCard = first.Hand.GetHighestPair();
            var secondCard = second.Hand.GetHighestPair();

            if (firstCard == secondCard) return CompareHighCards(first, second);
            if (firstCard > secondCard) return 1;
            return 2;
        }

        private int CompareHighCards(Player first, Player second)
        {
            for (var i = 0; i < first.Hand.Cards.Count; i++)
            {
                if (first.Hand.Cards[i].Value == second.Hand.Cards[i].Value) continue;
                if (first.Hand.Cards[i].Value > second.Hand.Cards[i].Value) return 1;
                if (first.Hand.Cards[i].Value < second.Hand.Cards[i].Value) return 2;
            }
            return 0;
        }
    }
}
