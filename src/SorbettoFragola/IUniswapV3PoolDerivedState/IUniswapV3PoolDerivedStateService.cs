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
using SorbettoFragola.Contracts.IUniswapV3PoolDerivedState.ContractDefinition;

namespace SorbettoFragola.Contracts.IUniswapV3PoolDerivedState
{
    public partial class IUniswapV3PoolDerivedStateService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, IUniswapV3PoolDerivedStateDeployment iUniswapV3PoolDerivedStateDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<IUniswapV3PoolDerivedStateDeployment>().SendRequestAndWaitForReceiptAsync(iUniswapV3PoolDerivedStateDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, IUniswapV3PoolDerivedStateDeployment iUniswapV3PoolDerivedStateDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<IUniswapV3PoolDerivedStateDeployment>().SendRequestAsync(iUniswapV3PoolDerivedStateDeployment);
        }

        public static async Task<IUniswapV3PoolDerivedStateService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, IUniswapV3PoolDerivedStateDeployment iUniswapV3PoolDerivedStateDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, iUniswapV3PoolDerivedStateDeployment, cancellationTokenSource);
            return new IUniswapV3PoolDerivedStateService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public IUniswapV3PoolDerivedStateService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<ObserveOutputDTO> ObserveQueryAsync(ObserveFunction observeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ObserveFunction, ObserveOutputDTO>(observeFunction, blockParameter);
        }

        public Task<ObserveOutputDTO> ObserveQueryAsync(List<uint> secondsAgos, BlockParameter blockParameter = null)
        {
            var observeFunction = new ObserveFunction();
                observeFunction.SecondsAgos = secondsAgos;
            
            return ContractHandler.QueryDeserializingToObjectAsync<ObserveFunction, ObserveOutputDTO>(observeFunction, blockParameter);
        }
    }
}
