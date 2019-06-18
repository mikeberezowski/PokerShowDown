using PokerConsoleApp.BusinessLogic;
using PokerConsoleApp.Infrastructure;
using System;
using System.IO;

namespace PokerConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataProvider = new DataProvider();
            var comparer = new HandComparer();
            var calculator = new RankCalculator();

            if (args.Length > 0)
            {
                if (File.Exists(args[0]))
                {
                    dataProvider.InputFile = args[0];
                }
                else
                {
                    Console.WriteLine("ERROR: File does not exist. This application takes a single parameter of an input text file.");
                    return;
                }
            }
            else
            {
                var path = AppDomain.CurrentDomain.BaseDirectory;

                dataProvider.InputFile = @"E:\\Code\\PokerShowDown\\PokerApp\\PokerConsoleApp\\AppData\\test1.txt";
            }

            var showdownApp = new ShowDownApp(dataProvider, calculator, comparer);

            showdownApp.Run();
        }
    }
}