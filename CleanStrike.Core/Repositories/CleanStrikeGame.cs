﻿using CleanStrike.Core.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanStrike.Core.Models
{
    public class CleanStrikeGame
    {
        public CarromBoard carromBoard;
        public List<Player> players;
        public Player currentPlayer;
        public CoinType currentCoinType;
        public int playerIndex = 0;
        private bool hasWinner = false;
        public Player winningPlayer = null;
        private bool hasCommittedFoul = false;

        /// <summary>
        /// Constructor for CleanStrikeGame
        /// </summary>
        /// <param name="carromBoard"></param>
        /// <param name="players"></param>
        /// <param name="currentPlayer"></param>
        public CleanStrikeGame(CarromBoard carromBoard, List<Player> players, Player currentPlayer)
        {
            this.carromBoard = carromBoard;
            this.players = players;
            this.currentPlayer = currentPlayer;
        }
        /// <summary>
        /// Updates Carrom Board - Removes coin from board or gets back to board based on Rules
        /// </summary>
        /// <param name="player"></param>
        /// <param name="strike"></param>
        public void UpdateCarromBoard(Player player, IStrikeType strike)
        {
            int removeCount = 0;
            Console.Write("" + player.playerName + " ");
            foreach (var coin in strike.singleTurn)
            {
                if (strike.GetType().Name.Equals(ApplicationConstants.MULTI_STRIKE) && removeCount < 2)
                {
                    removeCount += 1;
                    this.carromBoard.coins.Remove(coin);
                }
                else if (strike.GetType().Name.Equals(ApplicationConstants.RED_STRIKE))
                {
                    if (coin.coinType == CoinType.RED)
                        this.carromBoard.coins.Remove(coin);
                }
                else if (strike.GetType().Name.Equals(ApplicationConstants.SINGLE_STRIKE) || strike.GetType().Name.Equals(ApplicationConstants.DEFUNCT_STRIKE))
                {
                    this.carromBoard.coins.Remove(coin);
                }
                ConsoleUI.CreateThrowOrPocketView(strike,coin);
            }
        }
        /// <summary>
        /// Gets Next Player from the list of players playing the game
        /// </summary>
        /// <returns>Player</returns>
        public Player getNextPlayer()
        {
            if (playerIndex == players.Count)
                playerIndex = 0;
            return this.players[playerIndex++];
        }
        /// <summary>
        /// Check for LIMIT_OF_FOULS or when a player does not pocket coin for LIMIT_OF_NOSTRIKE
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool checkPlayerHistoryForFouls(Player player)
        {
            player.noStrikeCount = 0;
            player.foulsCount = 0;
            hasCommittedFoul = false;
            /**
             * Did a mistake by taking 3 sets each time instead of last 3 strikes
             * and also missed logic for no strike
             * while checking now thought of changing this logic 
             */
            int startIndex = player.strikeHistory.Count - ApplicationConstants.LIMIT_OF_FOULS;
            for (int i = startIndex; i < player.strikeHistory.Count; i++)
            {
                if (player.strikeHistory[i].GetType().Name.Equals(ApplicationConstants.DEFUNCT_STRIKE))
                    player.foulsCount++;
                if (player.strikeHistory[i].GetType().Name.Equals(ApplicationConstants.STRIKER_STRIKE))
                    player.foulsCount++;
                if (player.strikeHistory[i].GetType().Name.Equals(ApplicationConstants.NONE_STRIKE))
                    player.noStrikeCount++;
            }
            if (player.noStrikeCount!=0&&player.noStrikeCount%ApplicationConstants.LIMIT_OF_NONSTRIKE==0)
            {                
                player.foulsCount++;                
            }
            if (player.foulsCount!=0&&player.foulsCount%ApplicationConstants.LIMIT_OF_FOULS==0)
            {
                hasCommittedFoul = true;
                return hasCommittedFoul;
            }                        
            return hasCommittedFoul;
        }
        /// <summary>
        /// Updates the Given player informations like strikehistory,scores and currentstrike
        /// </summary>
        /// <param name="player"></param>
        /// <param name="strike"></param>
        public void UpdatePlayerScore(Player player, IStrikeType strike)
        {
            player.strikeHistory = new List<IStrikeType>(player.strikeHistory);
            player.currentStrike = null;
            player.currentStrike = strike;
            player.strikeHistory.Add(player.currentStrike);


            /**
             * Did a mistake by taking 3 sets each time instead of last 3 strikes
             * while checking now thought of changing this logic
             */

            if (((player.strikeHistory?.Count) >= ApplicationConstants.LIMIT_OF_FOULS) && checkPlayerHistoryForFouls(player))
            {
                player.score += strike.strikeScore;
                player.score -= 1; // when loses a point for 3 consecutive turns or not scored any in 3 consecutive turns                
                ConsoleUI.CreateFoulView(player);
            }
            else
            {
                player.score += player.noStrikeCount!=0&&player.noStrikeCount % ApplicationConstants.LIMIT_OF_NONSTRIKE == 0 ? -1 : strike.strikeScore;
                ConsoleUI.CreateScoreView(player);                
            }            

        }

        /// <summary>
        /// Initializes test model for initial Run
        /// </summary>
        /// <returns></returns>
        public List<IStrikeType> InitializeStrikeList()
        {
            List<IStrikeType> strikeTypes = new List<IStrikeType>() { new NoneStrike(),new RedStrike(),new NoneStrike(),
                new SingleStrike(), new NoneStrike(),new DefunctStrike(),
                new MultiStrike(new List<ICoinType>(){ new BlackCoin(),new BlackCoin(),new BlackCoin()}),
                new DefunctStrike(), new DefunctStrike(), new DefunctStrike(),
                new DefunctStrike(), new NoneStrike(), new StrikerStrike(),
                new NoneStrike(), new NoneStrike()};

            return strikeTypes;
        }

        /// <summary>
        /// Checks for any winner available 
        /// If Player has atleast 5 points and at least 3 points higher than other opponents
        /// </summary>
        /// <returns></returns>
        public bool checkIfWinnerIsAvailable()
        {
            foreach (var player in players)
            {
                if (player.score >= ApplicationConstants.MIN_STRIKE_SCORE && playerIndex <= players.Count)
                {
                    int maxSum = player.score;
                    for (int i = 0; i < players.Count; i++)
                    {
                        if (maxSum >= players[i].score + ApplicationConstants.WIN_STRIKE_DIFF)
                        {
                            winningPlayer = player;
                            hasWinner = true;
                            return hasWinner;
                        }
                        else
                        {
                            continue;
                        }

                    }
                }
            }
            return hasWinner;

        }
        /// <summary>
        /// Gets particular coin type count in carrom board
        /// </summary>        
        /// <param name="coinType"></param>
        /// <returns></returns>
        public int getCoinCount(CoinType coinType)
        {
            int coinCount = 0;
            foreach (var coin in this.carromBoard.coins)
            {
                if (coin.coinType.Equals(coinType))
                {
                    coinCount++;
                }
            }
            return coinCount;
        }

        /// <summary>
        /// Returns winning Player
        /// </summary>
        /// <returns></returns>
        public Player GetWinner()
        {
            return this.winningPlayer;


        }

    }
}
