using PokerConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace PokerConsoleApp.Infrastructure
{
    public class DataProvider : IDataProvider
    {
        public string InputFile { get; set; }

        public List<ShowDownDto> ReadPlayerData()
        {
            Stack<string> stack = new Stack<string>();
            var showDownList = new List<ShowDownDto>();

            if (string.IsNullOrEmpty(InputFile))
            {
                Console.WriteLine("No Input File Specified.");
                return null;
            }

            foreach (string line in File.ReadLines(InputFile))
            {
                if (stack.Count != 1)
                {
                    stack.Push(line);
                    continue;
                }
                var newPlayer = new ShowDownDto
                {
                    Name = stack.Pop(),
                    Hand = line
                };
                if (newPlayer.IsValid()) {
                    showDownList.Add(newPlayer);
                } else
                {
                    Console.WriteLine("Error on input Data: Name = {0}, Hand = {1}", newPlayer.Name, newPlayer.Hand);
                }
            }
            return showDownList;
        }
    }
}
