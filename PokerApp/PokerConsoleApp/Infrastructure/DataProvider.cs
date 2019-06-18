using PokerConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

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
                    Hand = line.ToUpper()
                };

                if (newPlayer.IsValid())
                {
                    showDownList.Add(newPlayer);
                }
                else
                {
                    Console.WriteLine("Error on input Data: Name = {0}, Hand = {1}", newPlayer.Name, newPlayer.Hand);
                }
            }

            return showDownList;
        }
        public string GetApplicationRoot()
        {
            var exePath = Path.GetDirectoryName(System.Reflection
                              .Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return appRoot;
        }
    }
}
