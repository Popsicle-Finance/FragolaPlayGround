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

namespace SorbettoFragola.Contracts.IERC20Permit.ContractDefinition
{


    public partial class IERC20PermitDeployment : IERC20PermitDeploymentBase
    {
        public IERC20PermitDeployment() : base(BYTECODE) { }
        public IERC20PermitDeployment(string byteCode) : base(byteCode) { }
    }

    public class IERC20PermitDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public IERC20PermitDeploymentBase() : base(BYTECODE) { }
        public IERC20PermitDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class DOMAIN_SEPARATORFunction : DOMAIN_SEPARATORFunctionBase { }

    [Function("DOMAIN_SEPARATOR", "bytes32")]
    public class DOMAIN_SEPARATORFunctionBase : FunctionMessage
    {

    }

    public partial class NoncesFunction : NoncesFunctionBase { }

    [Function("nonces", "uint256")]
    public class NoncesFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class PermitFunction : PermitFunctionBase { }

    [Function("permit")]
    public class PermitFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "spender", 2)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "value", 3)]
        public virtual BigInteger Value { get; set; }
        [Parameter("uint256", "deadline", 4)]
        public virtual BigInteger Deadline { get; set; }
        [Parameter("uint8", "v", 5)]
        public virtual byte V { get; set; }
        [Parameter("bytes32", "r", 6)]
        public virtual byte[] R { get; set; }
        [Parameter("bytes32", "s", 7)]
        public virtual byte[] S { get; set; }
    }

    public partial class DOMAIN_SEPARATOROutputDTO : DOMAIN_SEPARATOROutputDTOBase { }

    [FunctionOutput]
    public class DOMAIN_SEPARATOROutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class NoncesOutputDTO : NoncesOutputDTOBase { }

    [FunctionOutput]
    public class NoncesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }


}
