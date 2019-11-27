using System;
using System.Collections.Generic;
using System.Text;

namespace CleanStrike.Core.Models
{
    public class Player
    {
        public Player(string playerName, int score, int foulsCount, List<IStrikeType> strikeHistory, IStrikeType currentStrike)
        {
            this.playerName = playerName;
            this.score = score;
            this.foulsCount = foulsCount;
            this.strikeHistory = strikeHistory;
            this.currentStrike = currentStrike;
        }

        public string playerName { get; set; }
        public int score { get; set; }        
        public int foulsCount { get; set; }
        public List<IStrikeType> strikeHistory { get; set; } 
        public IStrikeType currentStrike { get; set; }


    }
}
