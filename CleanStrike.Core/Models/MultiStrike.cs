using System;
using System.Collections.Generic;
using System.Text;

namespace CleanStrike.Core.Models
{
    public class MultiStrike : IStrikeType
    {
        private int score = 2;
        private List<ICoinType> coinTypes = new List<ICoinType>() { new BlackCoin(),new BlackCoin()};
        
        public MultiStrike()
        { 
        }
        public MultiStrike(List<ICoinType> coinTypes)
        {
            this.coinTypes = coinTypes;
        }
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
