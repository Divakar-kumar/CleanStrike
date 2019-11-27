namespace CleanStrike.Core.Models
{
    public class StrikerCoin : ICoinType
    {
        private int value = 0;
        public CoinType coinType
        {
            get
            {
                return CoinType.STRIKER;
            }
        }
        public int coinValue
        {
            get
            {
                return value;
            }
        }
    }
}