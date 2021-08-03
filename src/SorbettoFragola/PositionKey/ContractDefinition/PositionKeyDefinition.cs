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

namespace SorbettoFragola.Contracts.PositionKey.ContractDefinition
{


    public partial class PositionKeyDeployment : PositionKeyDeploymentBase
    {
        public PositionKeyDeployment() : base(BYTECODE) { }
        public PositionKeyDeployment(string byteCode) : base(byteCode) { }
    }

    public class PositionKeyDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea26469706673582212200a088c59e06db06a591c394935b55857a2d775cba477c9e0c1882cda96e3061f64736f6c63430007060033";
        public PositionKeyDeploymentBase() : base(BYTECODE) { }
        public PositionKeyDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
