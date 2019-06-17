using System.Collections.Generic;

namespace PokerConsoleApp.Models
{
    public class Hand
    {
        public SortedDictionary<int, int> histogram = new SortedDictionary<int, int>();

        public List<Card> Cards { get; set; }

        public Hand()
        {
        }
        public Hand(string cards)
        {
            Cards = new List<Card>();
            var cardList = cards.Split(',');
            foreach (var card in cardList)
            {
                Cards.Add(new Card(card.Trim()));
            }

            // Sort the list for easier comparison
            Cards.Sort((p, q) => q.Number.CompareTo(p.Number));
            PopulateHistogram();
        }

        private void PopulateHistogram()
        {
            foreach (var item in Cards)
            {
                if (histogram.ContainsKey(item.Number))
                {
                    histogram[item.Number]++;
                }
                else
                {
                    histogram[item.Number] = 1;
                }
            }
        }
    }
}
