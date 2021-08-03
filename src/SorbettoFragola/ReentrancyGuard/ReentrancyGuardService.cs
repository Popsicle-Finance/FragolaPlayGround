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
using SorbettoFragola.Contracts.ReentrancyGuard.ContractDefinition;

namespace SorbettoFragola.Contracts.ReentrancyGuard
{
    public partial class ReentrancyGuardService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ReentrancyGuardDeployment reentrancyGuardDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ReentrancyGuardDeployment>().SendRequestAndWaitForReceiptAsync(reentrancyGuardDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ReentrancyGuardDeployment reentrancyGuardDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ReentrancyGuardDeployment>().SendRequestAsync(reentrancyGuardDeployment);
        }

        public static async Task<ReentrancyGuardService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ReentrancyGuardDeployment reentrancyGuardDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, reentrancyGuardDeployment, cancellationTokenSource);
            return new ReentrancyGuardService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ReentrancyGuardService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
