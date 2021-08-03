using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace SorbettoFragola.Contracts.IUniswapV3Pool.ContractDefinition
{


    public partial class IUniswapV3PoolDeployment : IUniswapV3PoolDeploymentBase
    {
        public IUniswapV3PoolDeployment() : base(BYTECODE) { }
        public IUniswapV3PoolDeployment(string byteCode) : base(byteCode) { }
    }

    public class IUniswapV3PoolDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public IUniswapV3PoolDeploymentBase() : base(BYTECODE) { }
        public IUniswapV3PoolDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class BurnFunction : BurnFunctionBase { }

    [Function("burn", typeof(BurnOutputDTO))]
    public class BurnFunctionBase : FunctionMessage
    {
        [Parameter("int24", "tickLower", 1)]
        public virtual int TickLower { get; set; }
        [Parameter("int24", "tickUpper", 2)]
        public virtual int TickUpper { get; set; }
        [Parameter("uint128", "amount", 3)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class CollectFunction : CollectFunctionBase { }

    [Function("collect", typeof(CollectOutputDTO))]
    public class CollectFunctionBase : FunctionMessage
    {
        [Parameter("address", "recipient", 1)]
        public virtual string Recipient { get; set; }
        [Parameter("int24", "tickLower", 2)]
        public virtual int TickLower { get; set; }
        [Parameter("int24", "tickUpper", 3)]
        public virtual int TickUpper { get; set; }
        [Parameter("uint128", "amount0Requested", 4)]
        public virtual BigInteger Amount0Requested { get; set; }
        [Parameter("uint128", "amount1Requested", 5)]
        public virtual BigInteger Amount1Requested { get; set; }
    }

    public partial class MintFunction : MintFunctionBase { }

    [Function("mint", typeof(MintOutputDTO))]
    public class MintFunctionBase : FunctionMessage
    {
        [Parameter("address", "recipient", 1)]
        public virtual string Recipient { get; set; }
        [Parameter("int24", "tickLower", 2)]
        public virtual int TickLower { get; set; }
        [Parameter("int24", "tickUpper", 3)]
        public virtual int TickUpper { get; set; }
        [Parameter("uint128", "amount", 4)]
        public virtual BigInteger Amount { get; set; }
        [Parameter("bytes", "data", 5)]
        public virtual byte[] Data { get; set; }
    }

    public partial class ObserveFunction : ObserveFunctionBase { }

    [Function("observe", typeof(ObserveOutputDTO))]
    public class ObserveFunctionBase : FunctionMessage
    {
        [Parameter("uint32[]", "secondsAgos", 1)]
        public virtual List<uint> SecondsAgos { get; set; }
    }

    public partial class PositionsFunction : PositionsFunctionBase { }

    [Function("positions", typeof(PositionsOutputDTO))]
    public class PositionsFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "key", 1)]
        public virtual byte[] Key { get; set; }
    }

    public partial class Slot0Function : Slot0FunctionBase { }

    [Function("slot0", typeof(Slot0OutputDTO))]
    public class Slot0FunctionBase : FunctionMessage
    {

    }

    public partial class SwapFunction : SwapFunctionBase { }

    [Function("swap", typeof(SwapOutputDTO))]
    public class SwapFunctionBase : FunctionMessage
    {
        [Parameter("address", "recipient", 1)]
        public virtual string Recipient { get; set; }
        [Parameter("bool", "zeroForOne", 2)]
        public virtual bool ZeroForOne { get; set; }
        [Parameter("int256", "amountSpecified", 3)]
        public virtual BigInteger AmountSpecified { get; set; }
        [Parameter("uint160", "sqrtPriceLimitX96", 4)]
        public virtual BigInteger SqrtPriceLimitX96 { get; set; }
        [Parameter("bytes", "data", 5)]
        public virtual byte[] Data { get; set; }
    }

    public partial class TickSpacingFunction : TickSpacingFunctionBase { }

    [Function("tickSpacing", "int24")]
    public class TickSpacingFunctionBase : FunctionMessage
    {

    }

    public partial class Token0Function : Token0FunctionBase { }

    [Function("token0", "address")]
    public class Token0FunctionBase : FunctionMessage
    {

    }

    public partial class Token1Function : Token1FunctionBase { }

    [Function("token1", "address")]
    public class Token1FunctionBase : FunctionMessage
    {

    }

    public partial class BurnOutputDTO : BurnOutputDTOBase { }

    [FunctionOutput]
    public class BurnOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "amount0", 1)]
        public virtual BigInteger Amount0 { get; set; }
        [Parameter("uint256", "amount1", 2)]
        public virtual BigInteger Amount1 { get; set; }
    }

    public partial class CollectOutputDTO : CollectOutputDTOBase { }

    [FunctionOutput]
    public class CollectOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint128", "amount0", 1)]
        public virtual BigInteger Amount0 { get; set; }
        [Parameter("uint128", "amount1", 2)]
        public virtual BigInteger Amount1 { get; set; }
    }

    public partial class MintOutputDTO : MintOutputDTOBase { }

    [FunctionOutput]
    public class MintOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "amount0", 1)]
        public virtual BigInteger Amount0 { get; set; }
        [Parameter("uint256", "amount1", 2)]
        public virtual BigInteger Amount1 { get; set; }
    }

    public partial class ObserveOutputDTO : ObserveOutputDTOBase { }

    [FunctionOutput]
    public class ObserveOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("int56[]", "tickCumulatives", 1)]
        public virtual List<long> TickCumulatives { get; set; }
        [Parameter("uint160[]", "secondsPerLiquidityCumulativeX128s", 2)]
        public virtual List<BigInteger> SecondsPerLiquidityCumulativeX128s { get; set; }
    }

    public partial class PositionsOutputDTO : PositionsOutputDTOBase { }

    [FunctionOutput]
    public class PositionsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint128", "_liquidity", 1)]
        public virtual BigInteger Liquidity { get; set; }
        [Parameter("uint256", "feeGrowthInside0LastX128", 2)]
        public virtual BigInteger FeeGrowthInside0LastX128 { get; set; }
        [Parameter("uint256", "feeGrowthInside1LastX128", 3)]
        public virtual BigInteger FeeGrowthInside1LastX128 { get; set; }
        [Parameter("uint128", "tokensOwed0", 4)]
        public virtual BigInteger TokensOwed0 { get; set; }
        [Parameter("uint128", "tokensOwed1", 5)]
        public virtual BigInteger TokensOwed1 { get; set; }
    }

    public partial class Slot0OutputDTO : Slot0OutputDTOBase { }

    [FunctionOutput]
    public class Slot0OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint160", "sqrtPriceX96", 1)]
        public virtual BigInteger SqrtPriceX96 { get; set; }
        [Parameter("int24", "tick", 2)]
        public virtual int Tick { get; set; }
        [Parameter("uint16", "observationIndex", 3)]
        public virtual ushort ObservationIndex { get; set; }
        [Parameter("uint16", "observationCardinality", 4)]
        public virtual ushort ObservationCardinality { get; set; }
        [Parameter("uint16", "observationCardinalityNext", 5)]
        public virtual ushort ObservationCardinalityNext { get; set; }
        [Parameter("uint8", "feeProtocol", 6)]
        public virtual byte FeeProtocol { get; set; }
        [Parameter("bool", "unlocked", 7)]
        public virtual bool Unlocked { get; set; }
    }

    public partial class SwapOutputDTO : SwapOutputDTOBase { }

    [FunctionOutput]
    public class SwapOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("int256", "amount0", 1)]
        public virtual BigInteger Amount0 { get; set; }
        [Parameter("int256", "amount1", 2)]
        public virtual BigInteger Amount1 { get; set; }
    }

    public partial class TickSpacingOutputDTO : TickSpacingOutputDTOBase { }

    [FunctionOutput]
    public class TickSpacingOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("int24", "", 1)]
        public virtual int ReturnValue1 { get; set; }
    }

    public partial class Token0OutputDTO : Token0OutputDTOBase { }

    [FunctionOutput]
    public class Token0OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class Token1OutputDTO : Token1OutputDTOBase { }

    [FunctionOutput]
    public class Token1OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
