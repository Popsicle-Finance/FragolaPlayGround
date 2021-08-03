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

namespace SorbettoFragola.Contracts.IUniswapV3PoolDerivedState.ContractDefinition
{


    public partial class IUniswapV3PoolDerivedStateDeployment : IUniswapV3PoolDerivedStateDeploymentBase
    {
        public IUniswapV3PoolDerivedStateDeployment() : base(BYTECODE) { }
        public IUniswapV3PoolDerivedStateDeployment(string byteCode) : base(byteCode) { }
    }

    public class IUniswapV3PoolDerivedStateDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public IUniswapV3PoolDerivedStateDeploymentBase() : base(BYTECODE) { }
        public IUniswapV3PoolDerivedStateDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class ObserveFunction : ObserveFunctionBase { }

    [Function("observe", typeof(ObserveOutputDTO))]
    public class ObserveFunctionBase : FunctionMessage
    {
        [Parameter("uint32[]", "secondsAgos", 1)]
        public virtual List<uint> SecondsAgos { get; set; }
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
}
