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

namespace SorbettoFragola.Contracts.TransferHelper.ContractDefinition
{


    public partial class TransferHelperDeployment : TransferHelperDeploymentBase
    {
        public TransferHelperDeployment() : base(BYTECODE) { }
        public TransferHelperDeployment(string byteCode) : base(byteCode) { }
    }

    public class TransferHelperDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea2646970667358221220e10bdf5ed63ed8233f5a57e99925952422f6963b5254f1fe7ec24bee632ced6f64736f6c63430007060033";
        public TransferHelperDeploymentBase() : base(BYTECODE) { }
        public TransferHelperDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
