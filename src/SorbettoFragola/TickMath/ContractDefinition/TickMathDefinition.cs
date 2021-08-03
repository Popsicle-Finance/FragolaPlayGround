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

namespace SorbettoFragola.Contracts.TickMath.ContractDefinition
{


    public partial class TickMathDeployment : TickMathDeploymentBase
    {
        public TickMathDeployment() : base(BYTECODE) { }
        public TickMathDeployment(string byteCode) : base(byteCode) { }
    }

    public class TickMathDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea264697066735822122050cf34a52c3b714ed194e5bb5257a2f788c9bfcea2b36809c3ad39e5caab369664736f6c63430007060033";
        public TickMathDeploymentBase() : base(BYTECODE) { }
        public TickMathDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
