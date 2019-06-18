using System.Collections.Generic;
using System.Linq;

namespace PokerConsoleApp.Models
{
    public class Hand
    {
        public SortedDictionary<int, int> histogram = new SortedDictionary<int, int>();

        public List<Card> Cards { get; set; }

        public Hand(string cards, Deck deck)
        {
            Cards = new List<Card>();
            var cardList = cards.Split(',');
            foreach (var card in cardList)
            {
                Cards.Add(new Card(deck, card.Trim()));
            }

            // Sort the list for easier comparison
            Cards.Sort((p, q) => q.Value.CompareTo(p.Value));
            PopulateHistogram();
        }

        public bool IsValid()
        {
            if (Cards.Count != 5) return false;

            foreach(var card in Cards)
            {
                if (!card.IsValid()) return false;
            }
            return true;
        }
        public int GetHighestPair()
        {
            int temp = histogram.FirstOrDefault(x => x.Value == 2).Key;

            foreach (var pair in histogram)
            {
                if (pair.Value == 2 && pair.Key > temp) temp = pair.Key;
            }

            return temp;
        }
        private void PopulateHistogram()
        {
            foreach (var item in Cards)
            {
                if (histogram.ContainsKey(item.Value))
                {
                    histogram[item.Value]++;
                }
                else
                {
                    histogram[item.Value] = 1;
                }
            }
        }
    }
}
