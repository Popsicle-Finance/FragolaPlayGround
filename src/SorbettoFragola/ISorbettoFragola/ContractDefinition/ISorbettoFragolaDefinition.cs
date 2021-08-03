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

namespace SorbettoFragola.Contracts.ISorbettoFragola.ContractDefinition
{


    public partial class ISorbettoFragolaDeployment : ISorbettoFragolaDeploymentBase
    {
        public ISorbettoFragolaDeployment() : base(BYTECODE) { }
        public ISorbettoFragolaDeployment(string byteCode) : base(byteCode) { }
    }

    public class ISorbettoFragolaDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public ISorbettoFragolaDeploymentBase() : base(BYTECODE) { }
        public ISorbettoFragolaDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class DepositFunction : DepositFunctionBase { }

    [Function("deposit", typeof(DepositOutputDTO))]
    public class DepositFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "amount0Desired", 1)]
        public virtual BigInteger Amount0Desired { get; set; }
        [Parameter("uint256", "amount1Desired", 2)]
        public virtual BigInteger Amount1Desired { get; set; }
    }

    public partial class PoolFunction : PoolFunctionBase { }

    [Function("pool", "address")]
    public class PoolFunctionBase : FunctionMessage
    {

    }

    public partial class RebalanceFunction : RebalanceFunctionBase { }

    [Function("rebalance")]
    public class RebalanceFunctionBase : FunctionMessage
    {

    }

    public partial class RerangeFunction : RerangeFunctionBase { }

    [Function("rerange")]
    public class RerangeFunctionBase : FunctionMessage
    {

    }

    public partial class TickLowerFunction : TickLowerFunctionBase { }

    [Function("tickLower", "int24")]
    public class TickLowerFunctionBase : FunctionMessage
    {

    }

    public partial class TickSpacingFunction : TickSpacingFunctionBase { }

    [Function("tickSpacing", "int24")]
    public class TickSpacingFunctionBase : FunctionMessage
    {

    }

    public partial class TickUpperFunction : TickUpperFunctionBase { }

    [Function("tickUpper", "int24")]
    public class TickUpperFunctionBase : FunctionMessage
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

    public partial class WithdrawFunction : WithdrawFunctionBase { }

    [Function("withdraw", typeof(WithdrawOutputDTO))]
    public class WithdrawFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "shares", 1)]
        public virtual BigInteger Shares { get; set; }
    }

    public partial class DepositOutputDTO : DepositOutputDTOBase { }

    [FunctionOutput]
    public class DepositOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "shares", 1)]
        public virtual BigInteger Shares { get; set; }
        [Parameter("uint256", "amount0", 2)]
        public virtual BigInteger Amount0 { get; set; }
        [Parameter("uint256", "amount1", 3)]
        public virtual BigInteger Amount1 { get; set; }
    }

    public partial class PoolOutputDTO : PoolOutputDTOBase { }

    [FunctionOutput]
    public class PoolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }





    public partial class TickLowerOutputDTO : TickLowerOutputDTOBase { }

    [FunctionOutput]
    public class TickLowerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("int24", "", 1)]
        public virtual int ReturnValue1 { get; set; }
    }

    public partial class TickSpacingOutputDTO : TickSpacingOutputDTOBase { }

    [FunctionOutput]
    public class TickSpacingOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("int24", "", 1)]
        public virtual int ReturnValue1 { get; set; }
    }

    public partial class TickUpperOutputDTO : TickUpperOutputDTOBase { }

    [FunctionOutput]
    public class TickUpperOutputDTOBase : IFunctionOutputDTO 
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

    public partial class WithdrawOutputDTO : WithdrawOutputDTOBase { }

    [FunctionOutput]
    public class WithdrawOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "amount0", 1)]
        public virtual BigInteger Amount0 { get; set; }
        [Parameter("uint256", "amount1", 2)]
        public virtual BigInteger Amount1 { get; set; }
    }
}
