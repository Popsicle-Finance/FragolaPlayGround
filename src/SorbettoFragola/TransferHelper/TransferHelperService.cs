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
using SorbettoFragola.Contracts.TransferHelper.ContractDefinition;

namespace SorbettoFragola.Contracts.TransferHelper
{
    public partial class TransferHelperService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, TransferHelperDeployment transferHelperDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<TransferHelperDeployment>().SendRequestAndWaitForReceiptAsync(transferHelperDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, TransferHelperDeployment transferHelperDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<TransferHelperDeployment>().SendRequestAsync(transferHelperDeployment);
        }

        public static async Task<TransferHelperService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, TransferHelperDeployment transferHelperDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, transferHelperDeployment, cancellationTokenSource);
            return new TransferHelperService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public TransferHelperService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
