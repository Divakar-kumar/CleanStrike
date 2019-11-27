using System.Collections.Generic;

namespace CleanStrike.Core.Models
{
    public interface ICarromBoard
    {
        public List<ICoinType> coins { get; set; }
        public int coinsCount { get; set; }
        public bool hasCoin { get; set; }
        int getCoinsCount();
        bool hasCoinsInBoard();
        bool hasCoinType(List<ICoinType> coinType);
    }
}