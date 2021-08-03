using System.Numerics;

namespace FragolaPlayGround.Models
{
    class ModifyPositionParams
    {
        public string Owner { get; set; }
        public int TickLower { get; set; }
        public int TickUpper { get; set; }
        public BigInteger LiquidityDelta { get; set; }
    }
}
