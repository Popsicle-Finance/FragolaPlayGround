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

namespace SorbettoFragola.Contracts.FullMath.ContractDefinition
{


    public partial class FullMathDeployment : FullMathDeploymentBase
    {
        public FullMathDeployment() : base(BYTECODE) { }
        public FullMathDeployment(string byteCode) : base(byteCode) { }
    }

    public class FullMathDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea26469706673582212205a5c38f8d9e98d04afb9d586d3de63b8693c6607156cdce4a44dd7ac6bfab6f064736f6c63430007060033";
        public FullMathDeploymentBase() : base(BYTECODE) { }
        public FullMathDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
