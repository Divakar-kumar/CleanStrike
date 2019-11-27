using CleanStrike.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanStrike.Core.Constants
{
    public static class ApplicationConstants
    {
        public static readonly int DEFAULT_SCORE = 0;
        public static readonly int DEFAULT_FOULS = 0;
        public static readonly IStrikeType DEFAULT_STRIKE_TYPE = new NoneStrike();
        public static readonly dynamic DEFAULT_LIST = null;
        public static readonly List<IStrikeType> DEFAULT_STRIKE_TYPE_LIST = new List<IStrikeType>();
        public static readonly int LIMIT_OF_NONSTRIKE = 3;
        public static readonly int LIMIT_OF_FOULS = 3;
        public static readonly int NO_OF_BLACK_COINS = 9;
        public static readonly int NO_OF_RED_COINS = 1;
        public static readonly int MIN_STRIKE_SCORE = 5;
        public static readonly int WIN_STRIKE_DIFF = 3;
        public static readonly int MAX_PLAYERS = 2;
        public static readonly string SINGLE_STRIKE = "Strike";
        public static readonly string MULTI_STRIKE = "MultiStrike";
        public static readonly string STRIKER_STRIKE = "StrikerStrike";
        public static readonly string NONE_STRIKE = "NoneStrike";
        public static readonly string DEFUNCT_STRIKE = "DefunctStrike";
        public static readonly string RED_STRIKE = "RedStrike";
    }
}
