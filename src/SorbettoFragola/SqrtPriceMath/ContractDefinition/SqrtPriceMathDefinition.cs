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

namespace SorbettoFragola.Contracts.SqrtPriceMath.ContractDefinition
{


    public partial class SqrtPriceMathDeployment : SqrtPriceMathDeploymentBase
    {
        public SqrtPriceMathDeployment() : base(BYTECODE) { }
        public SqrtPriceMathDeployment(string byteCode) : base(byteCode) { }
    }

    public class SqrtPriceMathDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea26469706673582212204b64dd04a7956f7c851df7907dba42b12a43723347523718d734a78d8a557bbd64736f6c63430007060033";
        public SqrtPriceMathDeploymentBase() : base(BYTECODE) { }
        public SqrtPriceMathDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
