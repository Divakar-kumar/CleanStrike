using System;
using System.Collections.Generic;
using System.Text;

namespace CleanStrike.Core.Models
{
    public class StrikerStrike:IStrikeType
    {
        private int score = 0;
        private List<ICoinType> coinTypes = new List<ICoinType>() { new StrikerCoin() };           
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
