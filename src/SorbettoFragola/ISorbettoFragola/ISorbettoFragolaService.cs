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
using SorbettoFragola.Contracts.ISorbettoFragola.ContractDefinition;

namespace SorbettoFragola.Contracts.ISorbettoFragola
{
    public partial class ISorbettoFragolaService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ISorbettoFragolaDeployment iSorbettoFragolaDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ISorbettoFragolaDeployment>().SendRequestAndWaitForReceiptAsync(iSorbettoFragolaDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ISorbettoFragolaDeployment iSorbettoFragolaDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ISorbettoFragolaDeployment>().SendRequestAsync(iSorbettoFragolaDeployment);
        }

        public static async Task<ISorbettoFragolaService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ISorbettoFragolaDeployment iSorbettoFragolaDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, iSorbettoFragolaDeployment, cancellationTokenSource);
            return new ISorbettoFragolaService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ISorbettoFragolaService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> DepositRequestAsync(DepositFunction depositFunction)
        {
             return ContractHandler.SendRequestAsync(depositFunction);
        }

        public Task<TransactionReceipt> DepositRequestAndWaitForReceiptAsync(DepositFunction depositFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(depositFunction, cancellationToken);
        }

        public Task<string> DepositRequestAsync(BigInteger amount0Desired, BigInteger amount1Desired)
        {
            var depositFunction = new DepositFunction();
                depositFunction.Amount0Desired = amount0Desired;
                depositFunction.Amount1Desired = amount1Desired;
            
             return ContractHandler.SendRequestAsync(depositFunction);
        }

        public Task<TransactionReceipt> DepositRequestAndWaitForReceiptAsync(BigInteger amount0Desired, BigInteger amount1Desired, CancellationTokenSource cancellationToken = null)
        {
            var depositFunction = new DepositFunction();
                depositFunction.Amount0Desired = amount0Desired;
                depositFunction.Amount1Desired = amount1Desired;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(depositFunction, cancellationToken);
        }

        public Task<string> PoolQueryAsync(PoolFunction poolFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PoolFunction, string>(poolFunction, blockParameter);
        }

        
        public Task<string> PoolQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PoolFunction, string>(null, blockParameter);
        }

        public Task<string> RebalanceRequestAsync(RebalanceFunction rebalanceFunction)
        {
             return ContractHandler.SendRequestAsync(rebalanceFunction);
        }

        public Task<string> RebalanceRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RebalanceFunction>();
        }

        public Task<TransactionReceipt> RebalanceRequestAndWaitForReceiptAsync(RebalanceFunction rebalanceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(rebalanceFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RebalanceRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RebalanceFunction>(null, cancellationToken);
        }

        public Task<string> RerangeRequestAsync(RerangeFunction rerangeFunction)
        {
             return ContractHandler.SendRequestAsync(rerangeFunction);
        }

        public Task<string> RerangeRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RerangeFunction>();
        }

        public Task<TransactionReceipt> RerangeRequestAndWaitForReceiptAsync(RerangeFunction rerangeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(rerangeFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RerangeRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RerangeFunction>(null, cancellationToken);
        }

        public Task<int> TickLowerQueryAsync(TickLowerFunction tickLowerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TickLowerFunction, int>(tickLowerFunction, blockParameter);
        }

        
        public Task<int> TickLowerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TickLowerFunction, int>(null, blockParameter);
        }

        public Task<int> TickSpacingQueryAsync(TickSpacingFunction tickSpacingFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TickSpacingFunction, int>(tickSpacingFunction, blockParameter);
        }

        
        public Task<int> TickSpacingQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TickSpacingFunction, int>(null, blockParameter);
        }

        public Task<int> TickUpperQueryAsync(TickUpperFunction tickUpperFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TickUpperFunction, int>(tickUpperFunction, blockParameter);
        }

        
        public Task<int> TickUpperQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TickUpperFunction, int>(null, blockParameter);
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

        public Task<string> WithdrawRequestAsync(WithdrawFunction withdrawFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(WithdrawFunction withdrawFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(BigInteger shares)
        {
            var withdrawFunction = new WithdrawFunction();
                withdrawFunction.Shares = shares;
            
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(BigInteger shares, CancellationTokenSource cancellationToken = null)
        {
            var withdrawFunction = new WithdrawFunction();
                withdrawFunction.Shares = shares;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }
    }
}
