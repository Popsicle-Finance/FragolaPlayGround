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

namespace SorbettoFragola.Contracts.LiquidityAmounts.ContractDefinition
{


    public partial class LiquidityAmountsDeployment : LiquidityAmountsDeploymentBase
    {
        public LiquidityAmountsDeployment() : base(BYTECODE) { }
        public LiquidityAmountsDeployment(string byteCode) : base(byteCode) { }
    }

    public class LiquidityAmountsDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea264697066735822122012098a0963627285aff913fbcc36131f98a9b6248cbc23a262bab05a1923b4da64736f6c63430007060033";
        public LiquidityAmountsDeploymentBase() : base(BYTECODE) { }
        public LiquidityAmountsDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
