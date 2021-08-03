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
using SorbettoFragola.Contracts.ECDSA.ContractDefinition;

namespace SorbettoFragola.Contracts.ECDSA
{
    public partial class ECDSAService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ECDSADeployment eCDSADeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ECDSADeployment>().SendRequestAndWaitForReceiptAsync(eCDSADeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ECDSADeployment eCDSADeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ECDSADeployment>().SendRequestAsync(eCDSADeployment);
        }

        public static async Task<ECDSAService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ECDSADeployment eCDSADeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, eCDSADeployment, cancellationTokenSource);
            return new ECDSAService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ECDSAService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
