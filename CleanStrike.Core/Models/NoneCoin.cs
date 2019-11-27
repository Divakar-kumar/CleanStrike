namespace CleanStrike.Core.Models
{
    public class NoneCoin : ICoinType
    {
        private int value = 0;
        public CoinType coinType
        {
            get
            {
                return CoinType.NONE;
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