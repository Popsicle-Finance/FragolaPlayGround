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
using SorbettoFragola.Contracts.LowGasSafeMath.ContractDefinition;

namespace SorbettoFragola.Contracts.LowGasSafeMath
{
    public partial class LowGasSafeMathService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, LowGasSafeMathDeployment lowGasSafeMathDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<LowGasSafeMathDeployment>().SendRequestAndWaitForReceiptAsync(lowGasSafeMathDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, LowGasSafeMathDeployment lowGasSafeMathDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<LowGasSafeMathDeployment>().SendRequestAsync(lowGasSafeMathDeployment);
        }

        public static async Task<LowGasSafeMathService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, LowGasSafeMathDeployment lowGasSafeMathDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, lowGasSafeMathDeployment, cancellationTokenSource);
            return new LowGasSafeMathService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public LowGasSafeMathService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
