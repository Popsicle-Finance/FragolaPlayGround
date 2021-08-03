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

namespace SorbettoFragola.Contracts.Context.ContractDefinition
{


    public partial class ContextDeployment : ContextDeploymentBase
    {
        public ContextDeployment() : base(BYTECODE) { }
        public ContextDeployment(string byteCode) : base(byteCode) { }
    }

    public class ContextDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public ContextDeploymentBase() : base(BYTECODE) { }
        public ContextDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
