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

namespace SorbettoFragola.Contracts.EIP712.ContractDefinition
{


    public partial class EIP712Deployment : EIP712DeploymentBase
    {
        public EIP712Deployment() : base(BYTECODE) { }
        public EIP712Deployment(string byteCode) : base(byteCode) { }
    }

    public class EIP712DeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public EIP712DeploymentBase() : base(BYTECODE) { }
        public EIP712DeploymentBase(string byteCode) : base(byteCode) { }

    }
}
