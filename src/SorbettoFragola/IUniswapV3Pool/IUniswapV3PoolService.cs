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
using SorbettoFragola.Contracts.IUniswapV3Pool.ContractDefinition;

namespace SorbettoFragola.Contracts.IUniswapV3Pool
{
    public partial class IUniswapV3PoolService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, IUniswapV3PoolDeployment iUniswapV3PoolDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<IUniswapV3PoolDeployment>().SendRequestAndWaitForReceiptAsync(iUniswapV3PoolDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, IUniswapV3PoolDeployment iUniswapV3PoolDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<IUniswapV3PoolDeployment>().SendRequestAsync(iUniswapV3PoolDeployment);
        }

        public static async Task<IUniswapV3PoolService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, IUniswapV3PoolDeployment iUniswapV3PoolDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, iUniswapV3PoolDeployment, cancellationTokenSource);
            return new IUniswapV3PoolService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public IUniswapV3PoolService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> BurnRequestAsync(BurnFunction burnFunction)
        {
             return ContractHandler.SendRequestAsync(burnFunction);
        }

        public Task<TransactionReceipt> BurnRequestAndWaitForReceiptAsync(BurnFunction burnFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFunction, cancellationToken);
        }

        public Task<string> BurnRequestAsync(int tickLower, int tickUpper, BigInteger amount)
        {
            var burnFunction = new BurnFunction();
                burnFunction.TickLower = tickLower;
                burnFunction.TickUpper = tickUpper;
                burnFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(burnFunction);
        }

        public Task<TransactionReceipt> BurnRequestAndWaitForReceiptAsync(int tickLower, int tickUpper, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var burnFunction = new BurnFunction();
                burnFunction.TickLower = tickLower;
                burnFunction.TickUpper = tickUpper;
                burnFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFunction, cancellationToken);
        }

        public Task<string> CollectRequestAsync(CollectFunction collectFunction)
        {
             return ContractHandler.SendRequestAsync(collectFunction);
        }

        public Task<TransactionReceipt> CollectRequestAndWaitForReceiptAsync(CollectFunction collectFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(collectFunction, cancellationToken);
        }

        public Task<string> CollectRequestAsync(string recipient, int tickLower, int tickUpper, BigInteger amount0Requested, BigInteger amount1Requested)
        {
            var collectFunction = new CollectFunction();
                collectFunction.Recipient = recipient;
                collectFunction.TickLower = tickLower;
                collectFunction.TickUpper = tickUpper;
                collectFunction.Amount0Requested = amount0Requested;
                collectFunction.Amount1Requested = amount1Requested;
            
             return ContractHandler.SendRequestAsync(collectFunction);
        }

        public Task<TransactionReceipt> CollectRequestAndWaitForReceiptAsync(string recipient, int tickLower, int tickUpper, BigInteger amount0Requested, BigInteger amount1Requested, CancellationTokenSource cancellationToken = null)
        {
            var collectFunction = new CollectFunction();
                collectFunction.Recipient = recipient;
                collectFunction.TickLower = tickLower;
                collectFunction.TickUpper = tickUpper;
                collectFunction.Amount0Requested = amount0Requested;
                collectFunction.Amount1Requested = amount1Requested;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(collectFunction, cancellationToken);
        }

        public Task<string> MintRequestAsync(MintFunction mintFunction)
        {
             return ContractHandler.SendRequestAsync(mintFunction);
        }

        public Task<TransactionReceipt> MintRequestAndWaitForReceiptAsync(MintFunction mintFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintFunction, cancellationToken);
        }

        public Task<string> MintRequestAsync(string recipient, int tickLower, int tickUpper, BigInteger amount, byte[] data)
        {
            var mintFunction = new MintFunction();
                mintFunction.Recipient = recipient;
                mintFunction.TickLower = tickLower;
                mintFunction.TickUpper = tickUpper;
                mintFunction.Amount = amount;
                mintFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(mintFunction);
        }

        public Task<TransactionReceipt> MintRequestAndWaitForReceiptAsync(string recipient, int tickLower, int tickUpper, BigInteger amount, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var mintFunction = new MintFunction();
                mintFunction.Recipient = recipient;
                mintFunction.TickLower = tickLower;
                mintFunction.TickUpper = tickUpper;
                mintFunction.Amount = amount;
                mintFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintFunction, cancellationToken);
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

        public Task<string> SwapRequestAsync(SwapFunction swapFunction)
        {
             return ContractHandler.SendRequestAsync(swapFunction);
        }

        public Task<TransactionReceipt> SwapRequestAndWaitForReceiptAsync(SwapFunction swapFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(swapFunction, cancellationToken);
        }

        public Task<string> SwapRequestAsync(string recipient, bool zeroForOne, BigInteger amountSpecified, BigInteger sqrtPriceLimitX96, byte[] data)
        {
            var swapFunction = new SwapFunction();
                swapFunction.Recipient = recipient;
                swapFunction.ZeroForOne = zeroForOne;
                swapFunction.AmountSpecified = amountSpecified;
                swapFunction.SqrtPriceLimitX96 = sqrtPriceLimitX96;
                swapFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(swapFunction);
        }

        public Task<TransactionReceipt> SwapRequestAndWaitForReceiptAsync(string recipient, bool zeroForOne, BigInteger amountSpecified, BigInteger sqrtPriceLimitX96, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var swapFunction = new SwapFunction();
                swapFunction.Recipient = recipient;
                swapFunction.ZeroForOne = zeroForOne;
                swapFunction.AmountSpecified = amountSpecified;
                swapFunction.SqrtPriceLimitX96 = sqrtPriceLimitX96;
                swapFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(swapFunction, cancellationToken);
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
