using System;
using System.Collections.Generic;
using System.Text;

namespace CleanStrike.Core.Models
{
    public class BlackCoin : ICoinType
    {
        private int value = 0;
        public CoinType coinType
        {
            get
            {
                return CoinType.BLACK;
            }
        }
        public int coinValue {
            get
            {
                return value;
            }
        }
    }
}
