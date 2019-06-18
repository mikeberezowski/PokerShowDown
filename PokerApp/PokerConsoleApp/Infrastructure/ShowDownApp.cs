using PokerConsoleApp.BusinessLogic;
using PokerConsoleApp.Models;

namespace PokerConsoleApp.Infrastructure
{
    public class ShowDownApp
    {
        private readonly IDataProvider dataProvider;
        private readonly IRankCalculator rankCalculator;
        private readonly IHandComparer handComparer;

        public ShowDownApp(IDataProvider provider, IRankCalculator calculator, IHandComparer comparer)
        {
            dataProvider = provider;
            rankCalculator = calculator;
            handComparer = comparer;
        }

        public void Run()
        {
            var showDown = new ShowDown(handComparer);
            var rawData = dataProvider.ReadPlayerData();
            foreach (var player in rawData)
            {
                showDown.AddPlayer(new Player(rankCalculator, player.Name, player.Hand));
            }
            showDown.PrintWinner();
        }
    }
}
