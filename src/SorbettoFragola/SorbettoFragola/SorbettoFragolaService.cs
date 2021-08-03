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
using SorbettoFragola.Contracts.SorbettoFragola.ContractDefinition;

namespace SorbettoFragola.Contracts.SorbettoFragola
{
    public partial class SorbettoFragolaService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, SorbettoFragolaDeployment sorbettoFragolaDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<SorbettoFragolaDeployment>().SendRequestAndWaitForReceiptAsync(sorbettoFragolaDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, SorbettoFragolaDeployment sorbettoFragolaDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<SorbettoFragolaDeployment>().SendRequestAsync(sorbettoFragolaDeployment);
        }

        public static async Task<SorbettoFragolaService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, SorbettoFragolaDeployment sorbettoFragolaDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, sorbettoFragolaDeployment, cancellationTokenSource);
            return new SorbettoFragolaService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public SorbettoFragolaService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<byte[]> DOMAIN_SEPARATORQueryAsync(DOMAIN_SEPARATORFunction dOMAIN_SEPARATORFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DOMAIN_SEPARATORFunction, byte[]>(dOMAIN_SEPARATORFunction, blockParameter);
        }

        
        public Task<byte[]> DOMAIN_SEPARATORQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DOMAIN_SEPARATORFunction, byte[]>(null, blockParameter);
        }

        public Task<string> AcceptGovernanceRequestAsync(AcceptGovernanceFunction acceptGovernanceFunction)
        {
             return ContractHandler.SendRequestAsync(acceptGovernanceFunction);
        }

        public Task<string> AcceptGovernanceRequestAsync()
        {
             return ContractHandler.SendRequestAsync<AcceptGovernanceFunction>();
        }

        public Task<TransactionReceipt> AcceptGovernanceRequestAndWaitForReceiptAsync(AcceptGovernanceFunction acceptGovernanceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(acceptGovernanceFunction, cancellationToken);
        }

        public Task<TransactionReceipt> AcceptGovernanceRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<AcceptGovernanceFunction>(null, cancellationToken);
        }

        public Task<BigInteger> AccruedProtocolFees0QueryAsync(AccruedProtocolFees0Function accruedProtocolFees0Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccruedProtocolFees0Function, BigInteger>(accruedProtocolFees0Function, blockParameter);
        }

        
        public Task<BigInteger> AccruedProtocolFees0QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccruedProtocolFees0Function, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> AccruedProtocolFees1QueryAsync(AccruedProtocolFees1Function accruedProtocolFees1Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccruedProtocolFees1Function, BigInteger>(accruedProtocolFees1Function, blockParameter);
        }

        
        public Task<BigInteger> AccruedProtocolFees1QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccruedProtocolFees1Function, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> AllowanceQueryAsync(AllowanceFunction allowanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }

        
        public Task<BigInteger> AllowanceQueryAsync(string owner, string spender, BlockParameter blockParameter = null)
        {
            var allowanceFunction = new AllowanceFunction();
                allowanceFunction.Owner = owner;
                allowanceFunction.Spender = spender;
            
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }

        public Task<string> ApproveRequestAsync(ApproveFunction approveFunction)
        {
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(ApproveFunction approveFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(string spender, BigInteger amount)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.Spender = spender;
                approveFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string spender, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.Spender = spender;
                approveFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string account, BlockParameter blockParameter = null)
        {
            var balanceOfFunction = new BalanceOfFunction();
                balanceOfFunction.Account = account;
            
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        public Task<string> CollectFeesRequestAsync(CollectFeesFunction collectFeesFunction)
        {
             return ContractHandler.SendRequestAsync(collectFeesFunction);
        }

        public Task<TransactionReceipt> CollectFeesRequestAndWaitForReceiptAsync(CollectFeesFunction collectFeesFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(collectFeesFunction, cancellationToken);
        }

        public Task<string> CollectFeesRequestAsync(BigInteger amount0, BigInteger amount1)
        {
            var collectFeesFunction = new CollectFeesFunction();
                collectFeesFunction.Amount0 = amount0;
                collectFeesFunction.Amount1 = amount1;
            
             return ContractHandler.SendRequestAsync(collectFeesFunction);
        }

        public Task<TransactionReceipt> CollectFeesRequestAndWaitForReceiptAsync(BigInteger amount0, BigInteger amount1, CancellationTokenSource cancellationToken = null)
        {
            var collectFeesFunction = new CollectFeesFunction();
                collectFeesFunction.Amount0 = amount0;
                collectFeesFunction.Amount1 = amount1;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(collectFeesFunction, cancellationToken);
        }

        public Task<string> CollectProtocolFeesRequestAsync(CollectProtocolFeesFunction collectProtocolFeesFunction)
        {
             return ContractHandler.SendRequestAsync(collectProtocolFeesFunction);
        }

        public Task<TransactionReceipt> CollectProtocolFeesRequestAndWaitForReceiptAsync(CollectProtocolFeesFunction collectProtocolFeesFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(collectProtocolFeesFunction, cancellationToken);
        }

        public Task<string> CollectProtocolFeesRequestAsync(BigInteger amount0, BigInteger amount1)
        {
            var collectProtocolFeesFunction = new CollectProtocolFeesFunction();
                collectProtocolFeesFunction.Amount0 = amount0;
                collectProtocolFeesFunction.Amount1 = amount1;
            
             return ContractHandler.SendRequestAsync(collectProtocolFeesFunction);
        }

        public Task<TransactionReceipt> CollectProtocolFeesRequestAndWaitForReceiptAsync(BigInteger amount0, BigInteger amount1, CancellationTokenSource cancellationToken = null)
        {
            var collectProtocolFeesFunction = new CollectProtocolFeesFunction();
                collectProtocolFeesFunction.Amount0 = amount0;
                collectProtocolFeesFunction.Amount1 = amount1;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(collectProtocolFeesFunction, cancellationToken);
        }

        public Task<byte> DecimalsQueryAsync(DecimalsFunction decimalsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DecimalsFunction, byte>(decimalsFunction, blockParameter);
        }

        
        public Task<byte> DecimalsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DecimalsFunction, byte>(null, blockParameter);
        }

        public Task<string> DecreaseAllowanceRequestAsync(DecreaseAllowanceFunction decreaseAllowanceFunction)
        {
             return ContractHandler.SendRequestAsync(decreaseAllowanceFunction);
        }

        public Task<TransactionReceipt> DecreaseAllowanceRequestAndWaitForReceiptAsync(DecreaseAllowanceFunction decreaseAllowanceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(decreaseAllowanceFunction, cancellationToken);
        }

        public Task<string> DecreaseAllowanceRequestAsync(string spender, BigInteger subtractedValue)
        {
            var decreaseAllowanceFunction = new DecreaseAllowanceFunction();
                decreaseAllowanceFunction.Spender = spender;
                decreaseAllowanceFunction.SubtractedValue = subtractedValue;
            
             return ContractHandler.SendRequestAsync(decreaseAllowanceFunction);
        }

        public Task<TransactionReceipt> DecreaseAllowanceRequestAndWaitForReceiptAsync(string spender, BigInteger subtractedValue, CancellationTokenSource cancellationToken = null)
        {
            var decreaseAllowanceFunction = new DecreaseAllowanceFunction();
                decreaseAllowanceFunction.Spender = spender;
                decreaseAllowanceFunction.SubtractedValue = subtractedValue;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(decreaseAllowanceFunction, cancellationToken);
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

        public Task<bool> FinalizedQueryAsync(FinalizedFunction finalizedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FinalizedFunction, bool>(finalizedFunction, blockParameter);
        }

        
        public Task<bool> FinalizedQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FinalizedFunction, bool>(null, blockParameter);
        }

        public Task<string> GovernanceQueryAsync(GovernanceFunction governanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GovernanceFunction, string>(governanceFunction, blockParameter);
        }

        
        public Task<string> GovernanceQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GovernanceFunction, string>(null, blockParameter);
        }

        public Task<string> IncreaseAllowanceRequestAsync(IncreaseAllowanceFunction increaseAllowanceFunction)
        {
             return ContractHandler.SendRequestAsync(increaseAllowanceFunction);
        }

        public Task<TransactionReceipt> IncreaseAllowanceRequestAndWaitForReceiptAsync(IncreaseAllowanceFunction increaseAllowanceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(increaseAllowanceFunction, cancellationToken);
        }

        public Task<string> IncreaseAllowanceRequestAsync(string spender, BigInteger addedValue)
        {
            var increaseAllowanceFunction = new IncreaseAllowanceFunction();
                increaseAllowanceFunction.Spender = spender;
                increaseAllowanceFunction.AddedValue = addedValue;
            
             return ContractHandler.SendRequestAsync(increaseAllowanceFunction);
        }

        public Task<TransactionReceipt> IncreaseAllowanceRequestAndWaitForReceiptAsync(string spender, BigInteger addedValue, CancellationTokenSource cancellationToken = null)
        {
            var increaseAllowanceFunction = new IncreaseAllowanceFunction();
                increaseAllowanceFunction.Spender = spender;
                increaseAllowanceFunction.AddedValue = addedValue;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(increaseAllowanceFunction, cancellationToken);
        }

        public Task<string> InitRequestAsync(InitFunction initFunction)
        {
             return ContractHandler.SendRequestAsync(initFunction);
        }

        public Task<string> InitRequestAsync()
        {
             return ContractHandler.SendRequestAsync<InitFunction>();
        }

        public Task<TransactionReceipt> InitRequestAndWaitForReceiptAsync(InitFunction initFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initFunction, cancellationToken);
        }

        public Task<TransactionReceipt> InitRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<InitFunction>(null, cancellationToken);
        }

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> NoncesQueryAsync(NoncesFunction noncesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NoncesFunction, BigInteger>(noncesFunction, blockParameter);
        }

        
        public Task<BigInteger> NoncesQueryAsync(string owner, BlockParameter blockParameter = null)
        {
            var noncesFunction = new NoncesFunction();
                noncesFunction.Owner = owner;
            
            return ContractHandler.QueryAsync<NoncesFunction, BigInteger>(noncesFunction, blockParameter);
        }

        public Task<string> PendingGovernanceQueryAsync(PendingGovernanceFunction pendingGovernanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PendingGovernanceFunction, string>(pendingGovernanceFunction, blockParameter);
        }

        
        public Task<string> PendingGovernanceQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PendingGovernanceFunction, string>(null, blockParameter);
        }

        public Task<string> PermitRequestAsync(PermitFunction permitFunction)
        {
             return ContractHandler.SendRequestAsync(permitFunction);
        }

        public Task<TransactionReceipt> PermitRequestAndWaitForReceiptAsync(PermitFunction permitFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(permitFunction, cancellationToken);
        }

        public Task<string> PermitRequestAsync(string owner, string spender, BigInteger value, BigInteger deadline, byte v, byte[] r, byte[] s)
        {
            var permitFunction = new PermitFunction();
                permitFunction.Owner = owner;
                permitFunction.Spender = spender;
                permitFunction.Value = value;
                permitFunction.Deadline = deadline;
                permitFunction.V = v;
                permitFunction.R = r;
                permitFunction.S = s;
            
             return ContractHandler.SendRequestAsync(permitFunction);
        }

        public Task<TransactionReceipt> PermitRequestAndWaitForReceiptAsync(string owner, string spender, BigInteger value, BigInteger deadline, byte v, byte[] r, byte[] s, CancellationTokenSource cancellationToken = null)
        {
            var permitFunction = new PermitFunction();
                permitFunction.Owner = owner;
                permitFunction.Spender = spender;
                permitFunction.Value = value;
                permitFunction.Deadline = deadline;
                permitFunction.V = v;
                permitFunction.R = r;
                permitFunction.S = s;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(permitFunction, cancellationToken);
        }

        public Task<string> PoolQueryAsync(PoolFunction poolFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PoolFunction, string>(poolFunction, blockParameter);
        }

        
        public Task<string> PoolQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PoolFunction, string>(null, blockParameter);
        }

        public Task<PositionOutputDTO> PositionQueryAsync(PositionFunction positionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<PositionFunction, PositionOutputDTO>(positionFunction, blockParameter);
        }

        public Task<PositionOutputDTO> PositionQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<PositionFunction, PositionOutputDTO>(null, blockParameter);
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

        public Task<string> SetGovernanceRequestAsync(SetGovernanceFunction setGovernanceFunction)
        {
             return ContractHandler.SendRequestAsync(setGovernanceFunction);
        }

        public Task<TransactionReceipt> SetGovernanceRequestAndWaitForReceiptAsync(SetGovernanceFunction setGovernanceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setGovernanceFunction, cancellationToken);
        }

        public Task<string> SetGovernanceRequestAsync(string governance)
        {
            var setGovernanceFunction = new SetGovernanceFunction();
                setGovernanceFunction.Governance = governance;
            
             return ContractHandler.SendRequestAsync(setGovernanceFunction);
        }

        public Task<TransactionReceipt> SetGovernanceRequestAndWaitForReceiptAsync(string governance, CancellationTokenSource cancellationToken = null)
        {
            var setGovernanceFunction = new SetGovernanceFunction();
                setGovernanceFunction.Governance = governance;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setGovernanceFunction, cancellationToken);
        }

        public Task<string> SetStrategyRequestAsync(SetStrategyFunction setStrategyFunction)
        {
             return ContractHandler.SendRequestAsync(setStrategyFunction);
        }

        public Task<TransactionReceipt> SetStrategyRequestAndWaitForReceiptAsync(SetStrategyFunction setStrategyFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setStrategyFunction, cancellationToken);
        }

        public Task<string> SetStrategyRequestAsync(string strategy)
        {
            var setStrategyFunction = new SetStrategyFunction();
                setStrategyFunction.Strategy = strategy;
            
             return ContractHandler.SendRequestAsync(setStrategyFunction);
        }

        public Task<TransactionReceipt> SetStrategyRequestAndWaitForReceiptAsync(string strategy, CancellationTokenSource cancellationToken = null)
        {
            var setStrategyFunction = new SetStrategyFunction();
                setStrategyFunction.Strategy = strategy;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setStrategyFunction, cancellationToken);
        }

        public Task<string> StrategyQueryAsync(StrategyFunction strategyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StrategyFunction, string>(strategyFunction, blockParameter);
        }

        
        public Task<string> StrategyQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StrategyFunction, string>(null, blockParameter);
        }

        public Task<string> SymbolQueryAsync(SymbolFunction symbolFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(symbolFunction, blockParameter);
        }

        
        public Task<string> SymbolQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(null, blockParameter);
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

        public Task<BigInteger> Token0PerShareStoredQueryAsync(Token0PerShareStoredFunction token0PerShareStoredFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Token0PerShareStoredFunction, BigInteger>(token0PerShareStoredFunction, blockParameter);
        }

        
        public Task<BigInteger> Token0PerShareStoredQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Token0PerShareStoredFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> Token1QueryAsync(Token1Function token1Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Token1Function, string>(token1Function, blockParameter);
        }

        
        public Task<string> Token1QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Token1Function, string>(null, blockParameter);
        }

        public Task<BigInteger> Token1PerShareStoredQueryAsync(Token1PerShareStoredFunction token1PerShareStoredFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Token1PerShareStoredFunction, BigInteger>(token1PerShareStoredFunction, blockParameter);
        }

        
        public Task<BigInteger> Token1PerShareStoredQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Token1PerShareStoredFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> TotalSupplyQueryAsync(TotalSupplyFunction totalSupplyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(totalSupplyFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalSupplyQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> TransferRequestAsync(TransferFunction transferFunction)
        {
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(TransferFunction transferFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> TransferRequestAsync(string recipient, BigInteger amount)
        {
            var transferFunction = new TransferFunction();
                transferFunction.Recipient = recipient;
                transferFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(string recipient, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var transferFunction = new TransferFunction();
                transferFunction.Recipient = recipient;
                transferFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(TransferFromFunction transferFromFunction)
        {
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFromFunction transferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(string sender, string recipient, BigInteger amount)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.Sender = sender;
                transferFromFunction.Recipient = recipient;
                transferFromFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string sender, string recipient, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.Sender = sender;
                transferFromFunction.Recipient = recipient;
                transferFromFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> UniswapV3MintCallbackRequestAsync(UniswapV3MintCallbackFunction uniswapV3MintCallbackFunction)
        {
             return ContractHandler.SendRequestAsync(uniswapV3MintCallbackFunction);
        }

        public Task<TransactionReceipt> UniswapV3MintCallbackRequestAndWaitForReceiptAsync(UniswapV3MintCallbackFunction uniswapV3MintCallbackFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(uniswapV3MintCallbackFunction, cancellationToken);
        }

        public Task<string> UniswapV3MintCallbackRequestAsync(BigInteger amount0, BigInteger amount1, byte[] data)
        {
            var uniswapV3MintCallbackFunction = new UniswapV3MintCallbackFunction();
                uniswapV3MintCallbackFunction.Amount0 = amount0;
                uniswapV3MintCallbackFunction.Amount1 = amount1;
                uniswapV3MintCallbackFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(uniswapV3MintCallbackFunction);
        }

        public Task<TransactionReceipt> UniswapV3MintCallbackRequestAndWaitForReceiptAsync(BigInteger amount0, BigInteger amount1, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var uniswapV3MintCallbackFunction = new UniswapV3MintCallbackFunction();
                uniswapV3MintCallbackFunction.Amount0 = amount0;
                uniswapV3MintCallbackFunction.Amount1 = amount1;
                uniswapV3MintCallbackFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(uniswapV3MintCallbackFunction, cancellationToken);
        }

        public Task<string> UniswapV3SwapCallbackRequestAsync(UniswapV3SwapCallbackFunction uniswapV3SwapCallbackFunction)
        {
             return ContractHandler.SendRequestAsync(uniswapV3SwapCallbackFunction);
        }

        public Task<TransactionReceipt> UniswapV3SwapCallbackRequestAndWaitForReceiptAsync(UniswapV3SwapCallbackFunction uniswapV3SwapCallbackFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(uniswapV3SwapCallbackFunction, cancellationToken);
        }

        public Task<string> UniswapV3SwapCallbackRequestAsync(BigInteger amount0, BigInteger amount1, byte[] data)
        {
            var uniswapV3SwapCallbackFunction = new UniswapV3SwapCallbackFunction();
                uniswapV3SwapCallbackFunction.Amount0 = amount0;
                uniswapV3SwapCallbackFunction.Amount1 = amount1;
                uniswapV3SwapCallbackFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(uniswapV3SwapCallbackFunction);
        }

        public Task<TransactionReceipt> UniswapV3SwapCallbackRequestAndWaitForReceiptAsync(BigInteger amount0, BigInteger amount1, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var uniswapV3SwapCallbackFunction = new UniswapV3SwapCallbackFunction();
                uniswapV3SwapCallbackFunction.Amount0 = amount0;
                uniswapV3SwapCallbackFunction.Amount1 = amount1;
                uniswapV3SwapCallbackFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(uniswapV3SwapCallbackFunction, cancellationToken);
        }

        public Task<UserInfoOutputDTO> UserInfoQueryAsync(UserInfoFunction userInfoFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<UserInfoFunction, UserInfoOutputDTO>(userInfoFunction, blockParameter);
        }

        public Task<UserInfoOutputDTO> UserInfoQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var userInfoFunction = new UserInfoFunction();
                userInfoFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<UserInfoFunction, UserInfoOutputDTO>(userInfoFunction, blockParameter);
        }

        public Task<BigInteger> UsersFees0QueryAsync(UsersFees0Function usersFees0Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<UsersFees0Function, BigInteger>(usersFees0Function, blockParameter);
        }

        
        public Task<BigInteger> UsersFees0QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<UsersFees0Function, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> UsersFees1QueryAsync(UsersFees1Function usersFees1Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<UsersFees1Function, BigInteger>(usersFees1Function, blockParameter);
        }

        
        public Task<BigInteger> UsersFees1QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<UsersFees1Function, BigInteger>(null, blockParameter);
        }

        public Task<string> WethQueryAsync(WethFunction wethFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WethFunction, string>(wethFunction, blockParameter);
        }

        
        public Task<string> WethQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WethFunction, string>(null, blockParameter);
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
