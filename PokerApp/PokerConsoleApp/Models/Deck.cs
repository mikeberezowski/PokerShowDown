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
            Cards = new List<Card>();
            foreach(var suit in Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>())
            {
                for(var i = 2; i < 15; i++)
                {
                    var card = new Card(this);
                    card.Value = i;
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
        public bool IsCardTaken(Card card)
        {
            var findCard = Cards.Where(x => x.Suit == card.Suit && x.Value == card.Value).FirstOrDefault();
            if(findCard != null)
            {
                return findCard.IsDrawn;
            }
            return false;
        }
        public void DrawCard(Card card)
        {
            var findCard = Cards.Where(x => x.Suit == card.Suit && x.Value == card.Value).FirstOrDefault();
            if (findCard != null)
            {
                findCard.IsDrawn = true;
            }
        }
    }
}
