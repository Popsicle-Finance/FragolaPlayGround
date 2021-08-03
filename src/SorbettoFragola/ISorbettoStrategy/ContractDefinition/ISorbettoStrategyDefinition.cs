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

namespace SorbettoFragola.Contracts.ISorbettoStrategy.ContractDefinition
{


    public partial class ISorbettoStrategyDeployment : ISorbettoStrategyDeploymentBase
    {
        public ISorbettoStrategyDeployment() : base(BYTECODE) { }
        public ISorbettoStrategyDeployment(string byteCode) : base(byteCode) { }
    }

    public class ISorbettoStrategyDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public ISorbettoStrategyDeploymentBase() : base(BYTECODE) { }
        public ISorbettoStrategyDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class MaxTwapDeviationFunction : MaxTwapDeviationFunctionBase { }

    [Function("maxTwapDeviation", "int24")]
    public class MaxTwapDeviationFunctionBase : FunctionMessage
    {

    }

    public partial class PriceImpactPercentageFunction : PriceImpactPercentageFunctionBase { }

    [Function("priceImpactPercentage", "uint24")]
    public class PriceImpactPercentageFunctionBase : FunctionMessage
    {

    }

    public partial class ProtocolFeeFunction : ProtocolFeeFunctionBase { }

    [Function("protocolFee", "uint24")]
    public class ProtocolFeeFunctionBase : FunctionMessage
    {

    }

    public partial class TickRangeMultiplierFunction : TickRangeMultiplierFunctionBase { }

    [Function("tickRangeMultiplier", "int24")]
    public class TickRangeMultiplierFunctionBase : FunctionMessage
    {

    }

    public partial class TwapDurationFunction : TwapDurationFunctionBase { }

    [Function("twapDuration", "uint32")]
    public class TwapDurationFunctionBase : FunctionMessage
    {

    }

    public partial class MaxTwapDeviationOutputDTO : MaxTwapDeviationOutputDTOBase { }

    [FunctionOutput]
    public class MaxTwapDeviationOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("int24", "", 1)]
        public virtual int ReturnValue1 { get; set; }
    }

    public partial class PriceImpactPercentageOutputDTO : PriceImpactPercentageOutputDTOBase { }

    [FunctionOutput]
    public class PriceImpactPercentageOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint24", "", 1)]
        public virtual uint ReturnValue1 { get; set; }
    }

    public partial class ProtocolFeeOutputDTO : ProtocolFeeOutputDTOBase { }

    [FunctionOutput]
    public class ProtocolFeeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint24", "", 1)]
        public virtual uint ReturnValue1 { get; set; }
    }

    public partial class TickRangeMultiplierOutputDTO : TickRangeMultiplierOutputDTOBase { }

    [FunctionOutput]
    public class TickRangeMultiplierOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("int24", "", 1)]
        public virtual int ReturnValue1 { get; set; }
    }

    public partial class TwapDurationOutputDTO : TwapDurationOutputDTOBase { }

    [FunctionOutput]
    public class TwapDurationOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint32", "", 1)]
        public virtual uint ReturnValue1 { get; set; }
    }
}
