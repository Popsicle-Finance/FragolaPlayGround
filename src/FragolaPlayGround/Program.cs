using System;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;
using Nethereum.Uniswap.Contracts.UniswapV3Pool;
using Nethereum.Web3;
using SorbettoFragola.Contracts.SorbettoFragola;

namespace FragolaPlayGround
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string sorbettoFragola = "0xd63b340F6e9CCcF0c997c83C8d036fa53B113546"; // USDC/ETH (0.3%) pool

            var client = new RpcClient(new Uri("")); // paste you rpc link here
            var web3 = new Web3(client);

            var fragolaService = new SorbettoFragolaService(web3, sorbettoFragola);
            var poolAddress = await fragolaService.PoolQueryAsync();
            var pool = new UniswapV3PoolService(web3, poolAddress);
            var tickLower = await fragolaService.TickLowerQueryAsync();
            var tickUpper = await fragolaService.TickUpperQueryAsync();
            var sim = new UniswapV3PoolSim(pool);

            var position = await fragolaService.PositionQueryAsync();

            //uncomment if you want to get user's token amounts in position

            //var userAddress = "";
            //var userShare = await fragolaService.BalanceOfQueryAsync(userAddress);
            //var totalShares = await fragolaService.TotalSupplyQueryAsync();
            //var userLiquidity = position.Liquidity * userShare / totalShares;
            //var (token0Amount, token1Amount) = await sim.Burn(tickLower, tickUpper, userLiquidity, sorbettoFragola, DateTime.UtcNow.ToTimespamp());
            //Console.WriteLine(token0Amount);
            //Console.WriteLine(token1Amount);


            //if you want to get pending fees - paste 0 amount
            _ = await sim.Burn(tickLower, tickUpper, position.Liquidity, sorbettoFragola, DateTime.UtcNow.ToTimespamp());
            
            var token0Owed = sim.CurrentPosition.TokensOwed0;
            var token1Owed = sim.CurrentPosition.TokensOwed1;
            Console.WriteLine(token0Owed);
            Console.WriteLine(token1Owed);
        }
    }
}
