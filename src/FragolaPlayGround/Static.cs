using System.Collections.Generic;

namespace FragolaPlayGround
{
    public static class Static
    {
        public static Dictionary<string, Coin> SupportedCoins { get; set; } = new();
    }

    public class Coin
    {
        public decimal Usd { get; set; }
        public string Ticker { get; set; }
        public int DecimalPow { get; set; }
    }
}
