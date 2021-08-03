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

namespace SorbettoFragola.Contracts.IUniswapV3PoolImmutables.ContractDefinition
{


    public partial class IUniswapV3PoolImmutablesDeployment : IUniswapV3PoolImmutablesDeploymentBase
    {
        public IUniswapV3PoolImmutablesDeployment() : base(BYTECODE) { }
        public IUniswapV3PoolImmutablesDeployment(string byteCode) : base(byteCode) { }
    }

    public class IUniswapV3PoolImmutablesDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public IUniswapV3PoolImmutablesDeploymentBase() : base(BYTECODE) { }
        public IUniswapV3PoolImmutablesDeploymentBase(string byteCode) : base(byteCode) { }

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
