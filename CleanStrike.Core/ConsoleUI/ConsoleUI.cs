using System;
using System.Collections.Generic;
using System.Text;
using CleanStrike.Core.Constants;
using CleanStrike.Core.Models;

namespace CleanStrike.Core
{
    public static class ConsoleUI
    {
        public static void CreateMatchResultHeaderView()
        {
            Console.WriteLine(" =======================================");
            Console.WriteLine("           MATCH RESULT                     ");
            Console.WriteLine(" =======================================");
        }

        public static void CreateMatchResultBodyView(CleanStrikeGame _cleanStrikeGame)
        {
            int playersCount = 0;
            Console.Write("" + _cleanStrikeGame.winningPlayer.playerName + " won the game . Final Score : ");
            foreach (var player in _cleanStrikeGame.players)
            {
                playersCount++;
                Console.Write(player.score);
                if (playersCount != _cleanStrikeGame.players.Count)
                    Console.Write("/");
            }
        }

        public static void CreateMatchDrawView()
        {
            Console.WriteLine("Match is draw");
        }

        public static void CreateThrowOrPocketView(IStrikeType strike, ICoinType coin)
        {
            var commandMessage = strike.GetType().Name.Equals(ApplicationConstants.DEFUNCT_STRIKE) ? "throws" : "pockets";
            Console.WriteLine(" " + commandMessage + " " + coin.coinType + " coin");
        }

        public static void CreateIntroView()
        {
            Console.WriteLine(" =======================================");
            Console.WriteLine("        Starting the Clean Strike App");
            Console.WriteLine(" =======================================");
        }

        public static void CreateFoulView(Player player)
        {
            Console.WriteLine("" + player.playerName +" committed a foul and the current score is " + player.score);
        }

        public static void CreateScoreView(Player player)
        {
            Console.WriteLine("" + player.playerName + " current score is " + player.score);
        }
    }
}
