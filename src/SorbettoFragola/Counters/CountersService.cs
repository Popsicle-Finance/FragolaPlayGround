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
using SorbettoFragola.Contracts.Counters.ContractDefinition;

namespace SorbettoFragola.Contracts.Counters
{
    public partial class CountersService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, CountersDeployment countersDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<CountersDeployment>().SendRequestAndWaitForReceiptAsync(countersDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, CountersDeployment countersDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<CountersDeployment>().SendRequestAsync(countersDeployment);
        }

        public static async Task<CountersService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, CountersDeployment countersDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, countersDeployment, cancellationTokenSource);
            return new CountersService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public CountersService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
