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

namespace SorbettoFragola.Contracts.PoolVariables.ContractDefinition
{


    public partial class PoolVariablesDeployment : PoolVariablesDeploymentBase
    {
        public PoolVariablesDeployment() : base(BYTECODE) { }
        public PoolVariablesDeployment(string byteCode) : base(byteCode) { }
    }

    public class PoolVariablesDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea26469706673582212202b1fec2bba55b4a5f67849b88f82f3fae11c6e8559213d5cc91a449760969ef064736f6c63430007060033";
        public PoolVariablesDeploymentBase() : base(BYTECODE) { }
        public PoolVariablesDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
