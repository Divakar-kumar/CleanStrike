using System;
using System.Collections.Generic;
using System.Text;

namespace CleanStrike.Core.Models
{
    public class NoneStrike : IStrikeType
    {
        private int score=0;
        
        private List<ICoinType> coinTypes = new List<ICoinType>() { new NoneCoin() };
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
