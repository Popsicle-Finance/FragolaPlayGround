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

namespace SorbettoFragola.Contracts.ECDSA.ContractDefinition
{


    public partial class ECDSADeployment : ECDSADeploymentBase
    {
        public ECDSADeployment() : base(BYTECODE) { }
        public ECDSADeployment(string byteCode) : base(byteCode) { }
    }

    public class ECDSADeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea26469706673582212209a110b21f805dc805742ae9153664830b7622ddb51895a4ed7f160f5ab847f0e64736f6c63430007060033";
        public ECDSADeploymentBase() : base(BYTECODE) { }
        public ECDSADeploymentBase(string byteCode) : base(byteCode) { }

    }
}
