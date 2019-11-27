using System;
using System.Collections.Generic;
using System.Text;

namespace CleanStrike.Core.Models
{
    public class RedCoin : ICoinType
    {
        private int value = 0;
        public CoinType coinType
        {
            get
            {
                return CoinType.RED;
            }
        }
        public int coinValue
        {
            get
            {
                return value;
            }
        }
    }
}
