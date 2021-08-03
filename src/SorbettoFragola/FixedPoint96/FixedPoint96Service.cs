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
using SorbettoFragola.Contracts.FixedPoint96.ContractDefinition;

namespace SorbettoFragola.Contracts.FixedPoint96
{
    public partial class FixedPoint96Service
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, FixedPoint96Deployment fixedPoint96Deployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<FixedPoint96Deployment>().SendRequestAndWaitForReceiptAsync(fixedPoint96Deployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, FixedPoint96Deployment fixedPoint96Deployment)
        {
            return web3.Eth.GetContractDeploymentHandler<FixedPoint96Deployment>().SendRequestAsync(fixedPoint96Deployment);
        }

        public static async Task<FixedPoint96Service> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, FixedPoint96Deployment fixedPoint96Deployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, fixedPoint96Deployment, cancellationTokenSource);
            return new FixedPoint96Service(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public FixedPoint96Service(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
