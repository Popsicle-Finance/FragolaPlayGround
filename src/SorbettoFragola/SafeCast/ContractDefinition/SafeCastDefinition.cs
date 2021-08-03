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

namespace SorbettoFragola.Contracts.SafeCast.ContractDefinition
{


    public partial class SafeCastDeployment : SafeCastDeploymentBase
    {
        public SafeCastDeployment() : base(BYTECODE) { }
        public SafeCastDeployment(string byteCode) : base(byteCode) { }
    }

    public class SafeCastDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea264697066735822122088321464271e71677a8fb545a5927e78b2c95ee6314b77728960c965861ad28964736f6c63430007060033";
        public SafeCastDeploymentBase() : base(BYTECODE) { }
        public SafeCastDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
