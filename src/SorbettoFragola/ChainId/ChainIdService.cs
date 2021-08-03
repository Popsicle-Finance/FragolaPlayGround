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
using SorbettoFragola.Contracts.ChainId.ContractDefinition;

namespace SorbettoFragola.Contracts.ChainId
{
    public partial class ChainIdService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ChainIdDeployment chainIdDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ChainIdDeployment>().SendRequestAndWaitForReceiptAsync(chainIdDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ChainIdDeployment chainIdDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ChainIdDeployment>().SendRequestAsync(chainIdDeployment);
        }

        public static async Task<ChainIdService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ChainIdDeployment chainIdDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, chainIdDeployment, cancellationTokenSource);
            return new ChainIdService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ChainIdService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
