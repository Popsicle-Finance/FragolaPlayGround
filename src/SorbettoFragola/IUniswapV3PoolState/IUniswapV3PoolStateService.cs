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
using SorbettoFragola.Contracts.IUniswapV3PoolState.ContractDefinition;

namespace SorbettoFragola.Contracts.IUniswapV3PoolState
{
    public partial class IUniswapV3PoolStateService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, IUniswapV3PoolStateDeployment iUniswapV3PoolStateDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<IUniswapV3PoolStateDeployment>().SendRequestAndWaitForReceiptAsync(iUniswapV3PoolStateDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, IUniswapV3PoolStateDeployment iUniswapV3PoolStateDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<IUniswapV3PoolStateDeployment>().SendRequestAsync(iUniswapV3PoolStateDeployment);
        }

        public static async Task<IUniswapV3PoolStateService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, IUniswapV3PoolStateDeployment iUniswapV3PoolStateDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, iUniswapV3PoolStateDeployment, cancellationTokenSource);
            return new IUniswapV3PoolStateService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public IUniswapV3PoolStateService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<PositionsOutputDTO> PositionsQueryAsync(PositionsFunction positionsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<PositionsFunction, PositionsOutputDTO>(positionsFunction, blockParameter);
        }

        public Task<PositionsOutputDTO> PositionsQueryAsync(byte[] key, BlockParameter blockParameter = null)
        {
            var positionsFunction = new PositionsFunction();
                positionsFunction.Key = key;
            
            return ContractHandler.QueryDeserializingToObjectAsync<PositionsFunction, PositionsOutputDTO>(positionsFunction, blockParameter);
        }

        public Task<Slot0OutputDTO> Slot0QueryAsync(Slot0Function slot0Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<Slot0Function, Slot0OutputDTO>(slot0Function, blockParameter);
        }

        public Task<Slot0OutputDTO> Slot0QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<Slot0Function, Slot0OutputDTO>(null, blockParameter);
        }
    }
}
