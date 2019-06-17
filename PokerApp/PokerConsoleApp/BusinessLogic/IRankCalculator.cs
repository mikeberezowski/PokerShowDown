using PokerConsoleApp.Enums;
using PokerConsoleApp.Models;

namespace PokerConsoleApp.BusinessLogic
{
    public interface IRankCalculator
    {
        PokerHandRank CalculateBestHand(Hand hand);
    }
}
