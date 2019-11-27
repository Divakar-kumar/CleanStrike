using System.Collections.Generic;

namespace CleanStrike.Core.Models
{
    public interface ICleanStrikeGame
    {
        public ICarromBoard carromBoard { get; }
        public List<Player> players { get; set; }
        public Player currentPlayer { get; set; }
        public CoinType currentCoinType { get; set; }
        public int playerIndex { get; set; }       
        public Player winningPlayer { get; set; }       
        bool checkIfWinnerIsAvailable();
        bool checkPlayerHistoryForFouls(Player player);
        Player getNextPlayer();
        List<IStrikeType> InitializeStrikeList();
        void UpdateCarromBoard(Player player, IStrikeType strike);
        void UpdatePlayerScore(Player player, IStrikeType strike);
    }
}