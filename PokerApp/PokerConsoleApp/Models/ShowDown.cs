﻿using PokerConsoleApp.BusinessLogic;
using System;
using System.Collections.Generic;

namespace PokerConsoleApp.Models
{
    public class ShowDown
    {
        public Player CurrentWinner { get; set; }
        public List<Player> Players { get; set; }

        private readonly IHandComparer handComparer;

        public ShowDown()
        {
            handComparer = new HandComparer();
            Players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            CalculateWinner(player);
        }

        public void CalculateWinner(Player player)
        {
            if (CurrentWinner == null)
            {
                CurrentWinner = player;
                return;
            }
            CurrentWinner = handComparer.CompareTwoHands(CurrentWinner, player);
        }
        public void PrintWinner()
        {
            Console.WriteLine("{0} wins", CurrentWinner.Name);
        }
    }
}