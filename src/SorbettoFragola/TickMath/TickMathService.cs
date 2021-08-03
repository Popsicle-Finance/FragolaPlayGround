using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using SorbettoFragola.Contracts.TickMath.ContractDefinition;

namespace SorbettoFragola.Contracts.TickMath
{
    public partial class TickMathService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, TickMathDeployment tickMathDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<TickMathDeployment>().SendRequestAndWaitForReceiptAsync(tickMathDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, TickMathDeployment tickMathDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<TickMathDeployment>().SendRequestAsync(tickMathDeployment);
        }

        public static async Task<TickMathService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, TickMathDeployment tickMathDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, tickMathDeployment, cancellationTokenSource);
            return new TickMathService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public TickMathService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
