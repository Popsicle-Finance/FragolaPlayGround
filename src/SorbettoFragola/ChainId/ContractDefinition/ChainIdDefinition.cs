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

namespace SorbettoFragola.Contracts.ChainId.ContractDefinition
{


    public partial class ChainIdDeployment : ChainIdDeploymentBase
    {
        public ChainIdDeployment() : base(BYTECODE) { }
        public ChainIdDeployment(string byteCode) : base(byteCode) { }
    }

    public class ChainIdDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea2646970667358221220bf53e2e30d05e4c69c3f68e7fffa70f3879c9a8f1c2706579c4b6a5354df75b764736f6c63430007060033";
        public ChainIdDeploymentBase() : base(BYTECODE) { }
        public ChainIdDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
