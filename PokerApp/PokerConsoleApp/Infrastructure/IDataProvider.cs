using PokerConsoleApp.Models;
using System.Collections.Generic;

namespace PokerConsoleApp.Infrastructure
{
    public interface IDataProvider
    {
        List<ShowDownDto> ReadPlayerData();
        string GetApplicationRoot();
    }
}
