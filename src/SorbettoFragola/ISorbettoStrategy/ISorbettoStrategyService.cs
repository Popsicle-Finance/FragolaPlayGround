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
using SorbettoFragola.Contracts.ISorbettoStrategy.ContractDefinition;

namespace SorbettoFragola.Contracts.ISorbettoStrategy
{
    public partial class ISorbettoStrategyService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ISorbettoStrategyDeployment iSorbettoStrategyDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ISorbettoStrategyDeployment>().SendRequestAndWaitForReceiptAsync(iSorbettoStrategyDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ISorbettoStrategyDeployment iSorbettoStrategyDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ISorbettoStrategyDeployment>().SendRequestAsync(iSorbettoStrategyDeployment);
        }

        public static async Task<ISorbettoStrategyService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ISorbettoStrategyDeployment iSorbettoStrategyDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, iSorbettoStrategyDeployment, cancellationTokenSource);
            return new ISorbettoStrategyService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ISorbettoStrategyService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<int> MaxTwapDeviationQueryAsync(MaxTwapDeviationFunction maxTwapDeviationFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MaxTwapDeviationFunction, int>(maxTwapDeviationFunction, blockParameter);
        }

        
        public Task<int> MaxTwapDeviationQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MaxTwapDeviationFunction, int>(null, blockParameter);
        }

        public Task<uint> PriceImpactPercentageQueryAsync(PriceImpactPercentageFunction priceImpactPercentageFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PriceImpactPercentageFunction, uint>(priceImpactPercentageFunction, blockParameter);
        }

        
        public Task<uint> PriceImpactPercentageQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PriceImpactPercentageFunction, uint>(null, blockParameter);
        }

        public Task<uint> ProtocolFeeQueryAsync(ProtocolFeeFunction protocolFeeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ProtocolFeeFunction, uint>(protocolFeeFunction, blockParameter);
        }

        
        public Task<uint> ProtocolFeeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ProtocolFeeFunction, uint>(null, blockParameter);
        }

        public Task<int> TickRangeMultiplierQueryAsync(TickRangeMultiplierFunction tickRangeMultiplierFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TickRangeMultiplierFunction, int>(tickRangeMultiplierFunction, blockParameter);
        }

        
        public Task<int> TickRangeMultiplierQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TickRangeMultiplierFunction, int>(null, blockParameter);
        }

        public Task<uint> TwapDurationQueryAsync(TwapDurationFunction twapDurationFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TwapDurationFunction, uint>(twapDurationFunction, blockParameter);
        }

        
        public Task<uint> TwapDurationQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TwapDurationFunction, uint>(null, blockParameter);
        }
    }
}
