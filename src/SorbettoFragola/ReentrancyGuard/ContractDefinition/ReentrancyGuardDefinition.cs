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

namespace SorbettoFragola.Contracts.ReentrancyGuard.ContractDefinition
{


    public partial class ReentrancyGuardDeployment : ReentrancyGuardDeploymentBase
    {
        public ReentrancyGuardDeployment() : base(BYTECODE) { }
        public ReentrancyGuardDeployment(string byteCode) : base(byteCode) { }
    }

    public class ReentrancyGuardDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public ReentrancyGuardDeploymentBase() : base(BYTECODE) { }
        public ReentrancyGuardDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
