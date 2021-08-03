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

namespace SorbettoFragola.Contracts.LowGasSafeMath.ContractDefinition
{


    public partial class LowGasSafeMathDeployment : LowGasSafeMathDeploymentBase
    {
        public LowGasSafeMathDeployment() : base(BYTECODE) { }
        public LowGasSafeMathDeployment(string byteCode) : base(byteCode) { }
    }

    public class LowGasSafeMathDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea26469706673582212201b5f1595f0937131c128ca441dcd64b39f2bd6c18bd88bf99100d738a49f600f64736f6c63430007060033";
        public LowGasSafeMathDeploymentBase() : base(BYTECODE) { }
        public LowGasSafeMathDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
