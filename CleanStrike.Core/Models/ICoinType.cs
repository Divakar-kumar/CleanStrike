using System;
using System.Collections.Generic;
using System.Text;

namespace CleanStrike.Core.Models
{
    public interface ICoinType
    {
        public int coinValue { get; }
        public CoinType coinType { get; }
    }
}
