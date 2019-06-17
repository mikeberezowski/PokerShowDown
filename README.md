# PokerShowDown #

## Problem Description ##
Poker is a common card game with many variations. We would like to build a library which will take poker hands as input and output the player with the winning hand for a particular showdown. 

## Input ##
The library accepts data input in the following format:
<Name>
<Hand>
  
There are two lines of data, where <Name> is the name of the player (as a string of text) and <Hand> is a five-card poker hand in the following format:
-	A comma separated list of cards
-	Each card is two characters – one character for the card index and one for the suit
-	Card indexes are listed as A,2,3,4,5,6,7,8,9,J,Q,K representing the card value
-	Suites are listed as S,C,D,H for Spades, Clubs, Diamonds and Hearts respectively

Example:
Joe
AD, 5C, JH, 7S, 4C
(interpreted as: Joe has a hand consisting of the following cards: Ace of Diamonds, Five of Clubs, Jack of Hearts, Seven of Spades and Four of Clubs). 

## Restrictions ##
-	Each player has only one hand of cards
-	Each hand only has 5 cards
-	Each card can only exist in one player’s hand

