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
using SorbettoFragola.Contracts.Babylonian.ContractDefinition;

namespace SorbettoFragola.Contracts.Babylonian
{
    public partial class BabylonianService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, BabylonianDeployment babylonianDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<BabylonianDeployment>().SendRequestAndWaitForReceiptAsync(babylonianDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, BabylonianDeployment babylonianDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<BabylonianDeployment>().SendRequestAsync(babylonianDeployment);
        }

        public static async Task<BabylonianService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, BabylonianDeployment babylonianDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, babylonianDeployment, cancellationTokenSource);
            return new BabylonianService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public BabylonianService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
