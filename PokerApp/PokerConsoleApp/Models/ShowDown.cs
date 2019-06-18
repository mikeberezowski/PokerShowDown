using PokerConsoleApp.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerConsoleApp.Models
{
    public class ShowDown
    {
        public List<Player> CurrentWinners { get; set; }
        public List<Player> Players { get; set; }

        private readonly IHandComparer handComparer;

        public ShowDown(IHandComparer comparer)
        {
            handComparer = comparer;
            Players = new List<Player>();
            CurrentWinners = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            CalculateWinner(player);
        }

        public void CalculateWinner(Player player)
        {
            if (CurrentWinners.Count == 0)
            {
                CurrentWinners.Add(player);
                return;
            }

            var winner = handComparer.CompareTwoHands(CurrentWinners.First(), player);

            // if we have a tie, we add the additional player to the winners list
            if (winner == 0)
            {
                CurrentWinners.Add(player);
            }
            // if the second player wins, we clear the list first, then add the player
            // this works because any existing players would have equal hands and the
            // new player's hand is better
            if (winner == 2)
            {
                CurrentWinners.Clear();
                CurrentWinners.Add(player);

            }
        }

        public void PrintWinner()
        {
            if (CurrentWinners == null)
            {
                Console.WriteLine("No valid hands in the input");
            }
            else if (CurrentWinners.Count > 1)
            {
                var listOfWinners = "";

                foreach (var player in CurrentWinners)
                {
                    listOfWinners += " " + player.Name;
                }

                Console.WriteLine("There was a tie. The following players have winning hands: {0}", listOfWinners);
            }
            else
            {
                Console.WriteLine("{0} wins", CurrentWinners.First().Name);
            }
        }
    }
}
