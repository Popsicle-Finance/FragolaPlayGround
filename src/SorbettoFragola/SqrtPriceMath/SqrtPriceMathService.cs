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
using SorbettoFragola.Contracts.SqrtPriceMath.ContractDefinition;

namespace SorbettoFragola.Contracts.SqrtPriceMath
{
    public partial class SqrtPriceMathService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, SqrtPriceMathDeployment sqrtPriceMathDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<SqrtPriceMathDeployment>().SendRequestAndWaitForReceiptAsync(sqrtPriceMathDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, SqrtPriceMathDeployment sqrtPriceMathDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<SqrtPriceMathDeployment>().SendRequestAsync(sqrtPriceMathDeployment);
        }

        public static async Task<SqrtPriceMathService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, SqrtPriceMathDeployment sqrtPriceMathDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, sqrtPriceMathDeployment, cancellationTokenSource);
            return new SqrtPriceMathService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public SqrtPriceMathService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
