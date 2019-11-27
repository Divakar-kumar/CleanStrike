using System;
using System.Collections.Generic;
using System.Text;

namespace CleanStrike.Core.Models
{
    public class CarromBoard
    {
        public List<ICoinType> coins;
        public int coinsCount;
        public bool hasCoin = false;
        public bool hasCurrentCoin = false;
        /// <summary>
        /// Carrom Board Constructor to set list of coins available
        /// </summary>
        /// <param name="coinTypes"></param>
        public CarromBoard(List<ICoinType> coinTypes)
        {
            coins = coinTypes;
            coinsCount = coinTypes.Count;
        }
        public bool containsCurrentCoin(CoinType coinType)
        {
            hasCurrentCoin = false;
            foreach(var coin in coins)
            {
                if(coin.coinType.Equals(coinType))
                {
                    hasCurrentCoin = true;
                    return hasCurrentCoin;
                }
            }

            return hasCurrentCoin;
        }
        /// <summary>
        /// Check whether the carrom Board has current pocketed coin
        /// </summary>
        /// <param name="coinType"></param>
        /// <returns></returns>
        public bool hasCoinType(List<ICoinType> coinType)
        {
            hasCoin = false;
            foreach (var coin in coinType)
            {
                if (coin.coinType.Equals(CoinType.NONE) || coin.coinType.Equals(CoinType.STRIKER))
                {
                    hasCoin = true;
                    return hasCoin;
                }
                else if (getCoinsCount() > 0 && containsCurrentCoin(coin.coinType))
                {
                    hasCoin = true;
                }
                else
                {
                    hasCoin = false;
                    return hasCoin;
                }

            }
            return hasCoin;
        }
        /// <summary>
        /// Gets current Coins count in the carrom Board
        /// </summary>
        /// <returns></returns>
        public int getCoinsCount()
        {
            return coinsCount;
        }
        /// <summary>
        /// Checks whether coins are there in CarromBoard
        /// </summary>
        /// <returns></returns>
        public bool hasCoinsInBoard()
        {
            if (getCoinsCount() > 0)
                hasCoin = true;
            return hasCoin;

        }
    }
}
