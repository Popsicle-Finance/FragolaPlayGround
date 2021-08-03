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

namespace SorbettoFragola.Contracts.Babylonian.ContractDefinition
{


    public partial class BabylonianDeployment : BabylonianDeploymentBase
    {
        public BabylonianDeployment() : base(BYTECODE) { }
        public BabylonianDeployment(string byteCode) : base(byteCode) { }
    }

    public class BabylonianDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea26469706673582212201dc88503f883c32ecf7e8a2f229d91532e31dc1d35f6e6f5c5a9954a0038a6f764736f6c63430007060033";
        public BabylonianDeploymentBase() : base(BYTECODE) { }
        public BabylonianDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
