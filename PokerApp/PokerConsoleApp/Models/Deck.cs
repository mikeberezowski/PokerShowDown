using PokerConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerConsoleApp.Models
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public void InitializeDeck()
        {
            foreach(var suit in Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>())
            {
                for(var i = 2; i < 15; i++)
                {
                    var card = new Card();
                    card.Number = i;
                    card.Suit = suit;
                    card.IsDrawn = false;
                    Cards.Add(card);
                }
            }
        }
        public void ResetDeck()
        {
            foreach(var card in Cards)
            {
                card.IsDrawn = false;
            }
        }
    }
}
