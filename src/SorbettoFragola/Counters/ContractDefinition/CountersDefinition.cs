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

namespace SorbettoFragola.Contracts.Counters.ContractDefinition
{


    public partial class CountersDeployment : CountersDeploymentBase
    {
        public CountersDeployment() : base(BYTECODE) { }
        public CountersDeployment(string byteCode) : base(byteCode) { }
    }

    public class CountersDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea264697066735822122077427226a6d8c294514edd75d8888803486decab997cef77772f43e84261cd6e64736f6c63430007060033";
        public CountersDeploymentBase() : base(BYTECODE) { }
        public CountersDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
