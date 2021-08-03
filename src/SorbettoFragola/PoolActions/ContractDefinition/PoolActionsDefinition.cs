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

namespace SorbettoFragola.Contracts.PoolActions.ContractDefinition
{


    public partial class PoolActionsDeployment : PoolActionsDeploymentBase
    {
        public PoolActionsDeployment() : base(BYTECODE) { }
        public PoolActionsDeployment(string byteCode) : base(byteCode) { }
    }

    public class PoolActionsDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea264697066735822122054aacf5c040a9fe995c3775c219bb3d9021a9199666d5478294ec54848ddac9064736f6c63430007060033";
        public PoolActionsDeploymentBase() : base(BYTECODE) { }
        public PoolActionsDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
