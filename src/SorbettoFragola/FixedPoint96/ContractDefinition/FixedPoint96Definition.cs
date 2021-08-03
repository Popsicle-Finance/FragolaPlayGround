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

namespace SorbettoFragola.Contracts.FixedPoint96.ContractDefinition
{


    public partial class FixedPoint96Deployment : FixedPoint96DeploymentBase
    {
        public FixedPoint96Deployment() : base(BYTECODE) { }
        public FixedPoint96Deployment(string byteCode) : base(byteCode) { }
    }

    public class FixedPoint96DeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea2646970667358221220c8e91d3fcb09ca2db9216dc56ad35eba992051400e8ca6b3e9e60b54b4d6e5fc64736f6c63430007060033";
        public FixedPoint96DeploymentBase() : base(BYTECODE) { }
        public FixedPoint96DeploymentBase(string byteCode) : base(byteCode) { }

    }
}
