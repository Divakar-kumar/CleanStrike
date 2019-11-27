using CleanStrike.Core.Engine;
using CleanStrike.Core.Models;
using CleanStrike.Core.Repositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace CleanStrike.Core.Tests
{
    public class ClearStrikeGameTest
    {
        [Fact]
        public void Should_have_9_black_coins()
        {
            CleanStrikeGame cleanStrikeGame = InitializeGame();
            int blackCoinsCount = cleanStrikeGame.getCoinCount(CoinType.BLACK);
            Assert.Equal(9,blackCoinsCount);
        }
        [Fact]
        public void Should_have_1_red_coin()
        {
            CleanStrikeGame cleanStrikeGame = InitializeGame();
            int blackCoinsCount = cleanStrikeGame.getCoinCount(CoinType.RED);
            Assert.Equal(1, blackCoinsCount);
        }
        [Fact]
        public void should_match_draw_when_coin_exhausted()
        {            
            CleanStrikeGame cleanStrikeGame = InitializeGame();
            ICleanStrikeService clearStrikeService = new CleanStrikeService();
            clearStrikeService.PlayGame(cleanStrikeGame, GetExhaustedLists());
            Player winningPlayer = cleanStrikeGame.GetWinner();
            Assert.Null(winningPlayer);
        }
        [Fact]
        public void should_player2_wins_match()
        {
            CleanStrikeGame cleanStrikeGame = InitializeGame();
            ICleanStrikeService clearStrikeService = new CleanStrikeService();
            clearStrikeService.PlayGame(cleanStrikeGame, GetPlayer2WinningList());
            Player winningPlayer = cleanStrikeGame.GetWinner();
            Assert.Equal("Player2", winningPlayer.playerName);
        }
        [Fact]
        public void should_player1_wins_match()
        {
            CleanStrikeGame cleanStrikeGame = InitializeGame();
            ICleanStrikeService clearStrikeService = new CleanStrikeService();
            clearStrikeService.PlayGame(cleanStrikeGame, GetPlayer1WinningList());
            Player winningPlayer = cleanStrikeGame.GetWinner();
            Assert.Equal("Player1", winningPlayer.playerName);
        }

        private static CleanStrikeGame InitializeGame()
        {
            CarromBoardRepository carromBoardRepository = new CarromBoardRepository();
            CleanStrikeGame cleanStrikeGame = carromBoardRepository.InitializeClearStrikeGame();
            return cleanStrikeGame; 
        }

        private static List<IStrikeType> GetExhaustedLists()
        {
            List<IStrikeType> strikeTypes = new List<IStrikeType>() { new DefunctStrike(),new RedStrike(),new DefunctStrike(),
                new SingleStrike(), new DefunctStrike(),new StrikerStrike(),
                new MultiStrike(new List<ICoinType>(){ new BlackCoin(),new BlackCoin(),new BlackCoin()}),
                new NoneStrike(), new SingleStrike(), new NoneStrike(),
                new SingleStrike(), new NoneStrike(), new SingleStrike(),
                new NoneStrike(), new NoneStrike()};
            return strikeTypes;
        }
        private static List<IStrikeType> GetPlayer2WinningList()
        {
            List<IStrikeType> strikeTypes = new List<IStrikeType>() { new DefunctStrike(),new RedStrike(),new DefunctStrike(),
                new SingleStrike(), new DefunctStrike(),new StrikerStrike(),
                new MultiStrike(new List<ICoinType>(){ new BlackCoin(),new BlackCoin(),new BlackCoin()}),
                new NoneStrike(), new SingleStrike(), new SingleStrike(),
                new NoneStrike(), new NoneStrike(), new SingleStrike(),
                new NoneStrike(), new NoneStrike()};
            return strikeTypes;
        }

        private static List<IStrikeType> GetPlayer1WinningList()
        {
            List<IStrikeType> strikeTypes = new List<IStrikeType>() { new MultiStrike(),new DefunctStrike(),new SingleStrike(),
                new NoneStrike(), new DefunctStrike(),new StrikerStrike(),
                new MultiStrike(new List<ICoinType>(){ new BlackCoin(),new BlackCoin(),new BlackCoin()}),
                new NoneStrike(), new SingleStrike(), new SingleStrike(),
                new NoneStrike(), new NoneStrike(), new SingleStrike(),
                new NoneStrike(), new NoneStrike()};
            return strikeTypes;
        }
    }
}
