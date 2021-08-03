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

namespace SorbettoFragola.Contracts.IUniswapV3PoolActions.ContractDefinition
{


    public partial class IUniswapV3PoolActionsDeployment : IUniswapV3PoolActionsDeploymentBase
    {
        public IUniswapV3PoolActionsDeployment() : base(BYTECODE) { }
        public IUniswapV3PoolActionsDeployment(string byteCode) : base(byteCode) { }
    }

    public class IUniswapV3PoolActionsDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public IUniswapV3PoolActionsDeploymentBase() : base(BYTECODE) { }
        public IUniswapV3PoolActionsDeploymentBase(string byteCode) : base(byteCode) { }

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

    public partial class SwapOutputDTO : SwapOutputDTOBase { }

    [FunctionOutput]
    public class SwapOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("int256", "amount0", 1)]
        public virtual BigInteger Amount0 { get; set; }
        [Parameter("int256", "amount1", 2)]
        public virtual BigInteger Amount1 { get; set; }
    }
}
