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
using SorbettoFragola.Contracts.LiquidityAmounts.ContractDefinition;

namespace SorbettoFragola.Contracts.LiquidityAmounts
{
    public partial class LiquidityAmountsService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, LiquidityAmountsDeployment liquidityAmountsDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<LiquidityAmountsDeployment>().SendRequestAndWaitForReceiptAsync(liquidityAmountsDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, LiquidityAmountsDeployment liquidityAmountsDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<LiquidityAmountsDeployment>().SendRequestAsync(liquidityAmountsDeployment);
        }

        public static async Task<LiquidityAmountsService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, LiquidityAmountsDeployment liquidityAmountsDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, liquidityAmountsDeployment, cancellationTokenSource);
            return new LiquidityAmountsService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public LiquidityAmountsService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
