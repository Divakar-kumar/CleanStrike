using System;
using System.Collections.Generic;
using System.Text;

namespace CleanStrike.Core.Models
{
    public class DefunctStrike:IStrikeType
    {
        private int score = -2;
        private List<ICoinType> coinTypes = new List<ICoinType>() { new BlackCoin() };        
        public int strikeScore
        {
            get { return score; }
        }
        public List<ICoinType> singleTurn
        {
            get { return coinTypes; }
        }
    }
}
