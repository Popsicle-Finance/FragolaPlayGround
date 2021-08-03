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
using SorbettoFragola.Contracts.FullMath.ContractDefinition;

namespace SorbettoFragola.Contracts.FullMath
{
    public partial class FullMathService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, FullMathDeployment fullMathDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<FullMathDeployment>().SendRequestAndWaitForReceiptAsync(fullMathDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, FullMathDeployment fullMathDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<FullMathDeployment>().SendRequestAsync(fullMathDeployment);
        }

        public static async Task<FullMathService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, FullMathDeployment fullMathDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, fullMathDeployment, cancellationTokenSource);
            return new FullMathService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public FullMathService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
