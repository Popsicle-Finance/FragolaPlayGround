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
using SorbettoFragola.Contracts.PoolActions.ContractDefinition;

namespace SorbettoFragola.Contracts.PoolActions
{
    public partial class PoolActionsService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PoolActionsDeployment poolActionsDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PoolActionsDeployment>().SendRequestAndWaitForReceiptAsync(poolActionsDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PoolActionsDeployment poolActionsDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PoolActionsDeployment>().SendRequestAsync(poolActionsDeployment);
        }

        public static async Task<PoolActionsService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PoolActionsDeployment poolActionsDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, poolActionsDeployment, cancellationTokenSource);
            return new PoolActionsService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PoolActionsService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
