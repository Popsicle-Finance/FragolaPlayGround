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
using SorbettoFragola.Contracts.IUniswapV3PoolImmutables.ContractDefinition;

namespace SorbettoFragola.Contracts.IUniswapV3PoolImmutables
{
    public partial class IUniswapV3PoolImmutablesService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, IUniswapV3PoolImmutablesDeployment iUniswapV3PoolImmutablesDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<IUniswapV3PoolImmutablesDeployment>().SendRequestAndWaitForReceiptAsync(iUniswapV3PoolImmutablesDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, IUniswapV3PoolImmutablesDeployment iUniswapV3PoolImmutablesDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<IUniswapV3PoolImmutablesDeployment>().SendRequestAsync(iUniswapV3PoolImmutablesDeployment);
        }

        public static async Task<IUniswapV3PoolImmutablesService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, IUniswapV3PoolImmutablesDeployment iUniswapV3PoolImmutablesDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, iUniswapV3PoolImmutablesDeployment, cancellationTokenSource);
            return new IUniswapV3PoolImmutablesService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public IUniswapV3PoolImmutablesService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<int> TickSpacingQueryAsync(TickSpacingFunction tickSpacingFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TickSpacingFunction, int>(tickSpacingFunction, blockParameter);
        }

        
        public Task<int> TickSpacingQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TickSpacingFunction, int>(null, blockParameter);
        }

        public Task<string> Token0QueryAsync(Token0Function token0Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Token0Function, string>(token0Function, blockParameter);
        }

        
        public Task<string> Token0QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Token0Function, string>(null, blockParameter);
        }

        public Task<string> Token1QueryAsync(Token1Function token1Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Token1Function, string>(token1Function, blockParameter);
        }

        
        public Task<string> Token1QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Token1Function, string>(null, blockParameter);
        }
    }
}
