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
using SorbettoFragola.Contracts.EIP712.ContractDefinition;

namespace SorbettoFragola.Contracts.EIP712
{
    public partial class EIP712Service
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, EIP712Deployment eIP712Deployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<EIP712Deployment>().SendRequestAndWaitForReceiptAsync(eIP712Deployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, EIP712Deployment eIP712Deployment)
        {
            return web3.Eth.GetContractDeploymentHandler<EIP712Deployment>().SendRequestAsync(eIP712Deployment);
        }

        public static async Task<EIP712Service> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, EIP712Deployment eIP712Deployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, eIP712Deployment, cancellationTokenSource);
            return new EIP712Service(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public EIP712Service(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
