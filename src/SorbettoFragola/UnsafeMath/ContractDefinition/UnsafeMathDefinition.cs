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

namespace SorbettoFragola.Contracts.UnsafeMath.ContractDefinition
{


    public partial class UnsafeMathDeployment : UnsafeMathDeploymentBase
    {
        public UnsafeMathDeployment() : base(BYTECODE) { }
        public UnsafeMathDeployment(string byteCode) : base(byteCode) { }
    }

    public class UnsafeMathDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea26469706673582212202cb7e8f3c7b7e5151703bc638649aabc78b890b1add0b12a09e1e48656e1270e64736f6c63430007060033";
        public UnsafeMathDeploymentBase() : base(BYTECODE) { }
        public UnsafeMathDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
