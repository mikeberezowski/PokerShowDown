using PokerConsoleApp.Enums;
using System;

namespace PokerConsoleApp.Models
{
    public class Card
    {
        public int Number { get; set; }
        public CardSuit Suit { get; set; }

        public Card() { }
        public Card(string cardData)
        {
            Number = MapNumber(cardData[0]);
            Suit = MapSuit(cardData[1]);
        }

        private int MapNumber(char inputChar)
        {
            // if the number is a digit, simply return that digit
            if (char.IsNumber(inputChar))
            {
                return Convert.ToInt32(char.GetNumericValue(inputChar));
            }

            // otherwise convert to a numeric value
            switch (inputChar)
            {
                case ('J'): return 11;
                case ('Q'): return 12;
                case ('K'): return 13;
                case ('A'): return 14;
                default: return 0;
            }
        }

        private CardSuit MapSuit(char inputSuit)
        {
            switch (inputSuit)
            {
                case ('S'): return CardSuit.Spades;
                case ('C'): return CardSuit.Clubs;
                case ('D'): return CardSuit.Diamonds;
                case ('H'): return CardSuit.Hearts;
                default: return CardSuit.Spades;
            }
        }
    }
}
