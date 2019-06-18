using PokerConsoleApp.Enums;
using System;

namespace PokerConsoleApp.Models
{
    public class Card
    {
        public int Number { get; set; }
        public CardSuit Suit { get; set; }
        public bool IsDrawn { get; set; }
        public Card() { }

        public Card(string cardData)
        {
            // Business rules: A card can be up to three characters in total i.e. 10D
            // Anything else is considered unacceptable data
            if (cardData.Length > 3)
            {
                Console.WriteLine("Invalid Card data : {0}", cardData);
            }

            //Here we have a two digit number
            if (cardData.Length > 2)
            {
                Number = MapNumber(cardData.Substring(0, 2));
                Suit = MapSuit(cardData.Substring(cardData.Length - 1, 1));
            }
            // Here we have a single digit for the card value
            else
            {
                Number = MapNumber(cardData[0].ToString());
                Suit = MapSuit(cardData[1].ToString());
            }
        }

        private int MapNumber(string inputDigit)
        {
            // if the number is a digit, simply return that digit
            if (int.TryParse(inputDigit, out int value))
            {
                return value;
            }

            // otherwise convert to a numeric value
            switch (inputDigit)
            {
                case ("J"): return 11;
                case ("Q"): return 12;
                case ("K"): return 13;
                case ("A"): return 14;
                default: return 0;
            }
        }

        private CardSuit MapSuit(string inputSuit)
        {
            switch (inputSuit)
            {
                case ("S"): return CardSuit.Spades;
                case ("C"): return CardSuit.Clubs;
                case ("D"): return CardSuit.Diamonds;
                case ("H"): return CardSuit.Hearts;
                default: return CardSuit.Spades;
            }
        }
    }
}
