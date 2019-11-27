using CleanStrike.Core.Constants;
using CleanStrike.Core.Models;
using CleanStrike.Core.Repositories;
using CleanStrike.Core.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanStrike.Core.Engine
{
    public interface ICleanStrikeService
    {
        void PlayGame(CleanStrikeGame cleanStrikeGame,List<IStrikeType> strikeLists);
    }

    public class CleanStrikeService : ICleanStrikeService
    {
        private readonly ILogger<CleanStrikeService> _logger;
        private readonly ApplicationSettings _config;        

        public CleanStrikeService()
        {

        }
        public CleanStrikeService(ILogger<CleanStrikeService> logger,
            IOptions<ApplicationSettings> config)
        {
            _logger = logger;
            _config = config.Value;            
        }
        /// <summary>
        /// Game simulator for Clear Strike App 
        /// CarromBoard Game
        /// </summary>
        /// <param name="cleanStrikeGame"></param>
        public void PlayGame(CleanStrikeGame cleanStrikeGame, List<IStrikeType> strikeLists)
        {
            CleanStrikeGame _cleanStrikeGame = cleanStrikeGame;
            List<IStrikeType> strikeList = strikeLists;
            foreach(var strike in strikeList)
            {                
                Player player= _cleanStrikeGame.getNextPlayer();
                if (_cleanStrikeGame.carromBoard.hasCoinsInBoard() && _cleanStrikeGame.carromBoard.hasCoinType(strike.singleTurn)) // check whether the carrom board has coins
                {
                    _cleanStrikeGame.UpdateCarromBoard(player,strike);
                    _cleanStrikeGame.UpdatePlayerScore(player,strike);                    
                    if (_cleanStrikeGame.checkIfWinnerIsAvailable()) // break from the loop if winner is found
                        break;
                }
                else //break from the loop when there are no more coins in the carrom board
                {
                    break;
                }
            }
            if(_cleanStrikeGame.winningPlayer != null)
            {
                ConsoleUI.CreateMatchResultHeaderView();                
                ConsoleUI.CreateMatchResultBodyView(_cleanStrikeGame);                
            }
            else
            {
                ConsoleUI.CreateMatchDrawView();
            }
        }
    }
}
