using System;
using System.Collections.Generic;
using System.Text;
using CleanStrike.Core.Constants;
using CleanStrike.Core.Models;

namespace CleanStrike.Core.Repositories
{
    public class CarromBoardRepository : ICarromBoardRepository
    {
        /// <summary>
        /// Initializing carrom board with 9 Black coins and 1 Red Coin
        /// </summary>
        /// <returns></returns>
        private CarromBoard InitializeCarromBoard()
        {            
            List<ICoinType> coinsAvailable = new List<ICoinType>();            
            for (int i = 0; i < ApplicationConstants.NO_OF_BLACK_COINS; i++)
            {
                coinsAvailable.Add(new BlackCoin());               
            }            
            for (int i = 0; i < ApplicationConstants.NO_OF_RED_COINS; i++)
            {
                coinsAvailable.Add(new RedCoin());
            }
            CarromBoard carromBoard = new CarromBoard(coinsAvailable);
            return carromBoard;
        }
        /// <summary>
        /// Initialize the Clean Strike Game
        /// </summary>
        /// <returns></returns>
        public CleanStrikeGame InitializeClearStrikeGame()
        {
            CleanStrikeGame cleanStrikeGame = new CleanStrikeGame(InitializeCarromBoard(), InitializePlayers(), ApplicationConstants.DEFAULT_LIST);
            return cleanStrikeGame;
        }
        /// <summary>
        /// Initializing list of player participating in game
        /// </summary>
        /// <returns></returns>
        private List<Player> InitializePlayers()
        {
            List<Player> players = new List<Player>();
            players.Add(SetPlayerInformation("Player1"));
            players.Add(SetPlayerInformation("Player2"));
            return players;
        }

        /// <summary>
        /// Initialize each player with default values from Application Constant
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        private Player SetPlayerInformation(string playerName)
        {
            Player player = new Player(playerName, ApplicationConstants.DEFAULT_SCORE,
                ApplicationConstants.DEFAULT_FOULS, ApplicationConstants.DEFAULT_STRIKE_TYPE_LIST,
                ApplicationConstants.DEFAULT_STRIKE_TYPE);
            return player;
        }
    }
}
