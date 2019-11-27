using System;
using System.Collections.Generic;
using System.Text;

namespace CleanStrike.Core.Models
{
    public interface IStrikeType
    {        
        public int strikeScore { get; }
        public List<ICoinType> singleTurn { get; }        
    }
}
