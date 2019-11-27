using System;
using System.Collections.Generic;
using System.Text;

namespace CleanStrike.Core.Models
{
    public class RedStrike:IStrikeType
    {
        private int score=3;
        private List<ICoinType> coinTypes = new List<ICoinType>() { new RedCoin() };        
        public RedStrike()
        {

        }
        public RedStrike(List<ICoinType> coinTypes)
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
