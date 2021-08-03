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
using SorbettoFragola.Contracts.PoolVariables.ContractDefinition;

namespace SorbettoFragola.Contracts.PoolVariables
{
    public partial class PoolVariablesService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PoolVariablesDeployment poolVariablesDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PoolVariablesDeployment>().SendRequestAndWaitForReceiptAsync(poolVariablesDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PoolVariablesDeployment poolVariablesDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PoolVariablesDeployment>().SendRequestAsync(poolVariablesDeployment);
        }

        public static async Task<PoolVariablesService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PoolVariablesDeployment poolVariablesDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, poolVariablesDeployment, cancellationTokenSource);
            return new PoolVariablesService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PoolVariablesService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
