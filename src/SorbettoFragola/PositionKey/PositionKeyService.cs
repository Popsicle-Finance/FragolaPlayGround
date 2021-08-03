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
using SorbettoFragola.Contracts.PositionKey.ContractDefinition;

namespace SorbettoFragola.Contracts.PositionKey
{
    public partial class PositionKeyService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PositionKeyDeployment positionKeyDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PositionKeyDeployment>().SendRequestAndWaitForReceiptAsync(positionKeyDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PositionKeyDeployment positionKeyDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PositionKeyDeployment>().SendRequestAsync(positionKeyDeployment);
        }

        public static async Task<PositionKeyService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PositionKeyDeployment positionKeyDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, positionKeyDeployment, cancellationTokenSource);
            return new PositionKeyService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PositionKeyService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
