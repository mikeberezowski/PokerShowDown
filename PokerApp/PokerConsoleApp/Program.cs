using PokerConsoleApp.Models;

namespace PokerConsoleApp
{
    internal class Program
    {
        private const string round1player1 = "Joe";
        private const string round1player1cards = "8S, 8D, AD, QD, JH";

        private const string round1player2 = "Bob";
        private const string round1player2cards = "AS, QS, 8S, 6S, 4D";

        private const string round1player3 = "Sally";
        private const string round1player3cards = "4S, 4H, 3H, QC, 8C";

        private const string round2player1 = "Joe";
        private const string round2player1cards = "QD, 8D, KD, 7D, 3D";

        private const string round2player2 = "Bob";
        private const string round2player2cards = "AS, QS, 8S, 6S, 4S";

        private const string round2player3 = "Sally";
        private const string round2player3cards = "4S, 4H, 3H, QC, 8C";

        private const string round3player1 = "Joe";
        private const string round3player1cards = "3H, 5D, 9C, 9D, QH";

        private const string round3player2 = "Bob";
        private const string round3player2cards = "2H, 2C, 5S, 10C, AH";

        private const string round3player3 = "Jen";
        private const string round3player3cards = "5C, 7D, 9H, 9S, QS";

        private const string round4player1 = "Joe";
        private const string round4player1cards = "2H, 3D, 4C, 5D, 10H";

        private const string round4player2 = "Bob";
        private const string round4player2cards = "2C, 4D, 5S, 10C, JH";

        private const string round4player3 = "Jen";
        private const string round4player3cards = "5C, 7D, 8H, 9S, QD";

        static void Main(string[] args)
        {
            var game = new ShowDown();
            game.AddPlayer(new Player(round1player1, round1player1cards));
            game.AddPlayer(new Player(round1player2, round1player2cards));
            game.AddPlayer(new Player(round1player3, round1player3cards));
            game.PrintWinner();
            var game2 = new ShowDown();
            game2.AddPlayer(new Player(round2player1, round2player1cards));
            game2.AddPlayer(new Player(round2player2, round2player2cards));
            game2.AddPlayer(new Player(round2player3, round2player3cards));
            game2.PrintWinner();
            var game3 = new ShowDown();
            game3.AddPlayer(new Player(round3player1, round3player1cards));
            game3.AddPlayer(new Player(round3player2, round3player2cards));
            game3.AddPlayer(new Player(round3player3, round3player3cards));
            game3.PrintWinner();

            var game4 = new ShowDown();
            game4.AddPlayer(new Player(round4player1, round4player1cards));
            game4.AddPlayer(new Player(round4player2, round4player2cards));
            game4.AddPlayer(new Player(round4player3, round4player3cards));
            game4.PrintWinner();
        }
    }
}