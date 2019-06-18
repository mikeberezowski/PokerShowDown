using PokerConsoleApp.Models;

namespace PokerConsoleApp.BusinessLogic
{
    public interface IHandComparer
    {
        // In order to allow for ties we return an integer value
        // 0 = tie, 1 = first player wins, 2 = second player wins
        int CompareTwoHands(Player first, Player second);
    }
}
