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

namespace SorbettoFragola.Contracts.IUniswapV3PoolState.ContractDefinition
{


    public partial class IUniswapV3PoolStateDeployment : IUniswapV3PoolStateDeploymentBase
    {
        public IUniswapV3PoolStateDeployment() : base(BYTECODE) { }
        public IUniswapV3PoolStateDeployment(string byteCode) : base(byteCode) { }
    }

    public class IUniswapV3PoolStateDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public IUniswapV3PoolStateDeploymentBase() : base(BYTECODE) { }
        public IUniswapV3PoolStateDeploymentBase(string byteCode) : base(byteCode) { }

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
}
