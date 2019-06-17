using PokerConsoleApp.Models;

namespace PokerConsoleApp.BusinessLogic
{
    public interface IHandComparer
    {
        Player CompareTwoHands(Player first, Player second);
    }
}
