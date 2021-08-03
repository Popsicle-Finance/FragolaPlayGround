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
using SorbettoFragola.Contracts.SafeCast.ContractDefinition;

namespace SorbettoFragola.Contracts.SafeCast
{
    public partial class SafeCastService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, SafeCastDeployment safeCastDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<SafeCastDeployment>().SendRequestAndWaitForReceiptAsync(safeCastDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, SafeCastDeployment safeCastDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<SafeCastDeployment>().SendRequestAsync(safeCastDeployment);
        }

        public static async Task<SafeCastService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, SafeCastDeployment safeCastDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, safeCastDeployment, cancellationTokenSource);
            return new SafeCastService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public SafeCastService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
