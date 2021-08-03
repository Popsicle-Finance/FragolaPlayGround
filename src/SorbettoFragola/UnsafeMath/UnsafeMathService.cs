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
using SorbettoFragola.Contracts.UnsafeMath.ContractDefinition;

namespace SorbettoFragola.Contracts.UnsafeMath
{
    public partial class UnsafeMathService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, UnsafeMathDeployment unsafeMathDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<UnsafeMathDeployment>().SendRequestAndWaitForReceiptAsync(unsafeMathDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, UnsafeMathDeployment unsafeMathDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<UnsafeMathDeployment>().SendRequestAsync(unsafeMathDeployment);
        }

        public static async Task<UnsafeMathService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, UnsafeMathDeployment unsafeMathDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, unsafeMathDeployment, cancellationTokenSource);
            return new UnsafeMathService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public UnsafeMathService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
