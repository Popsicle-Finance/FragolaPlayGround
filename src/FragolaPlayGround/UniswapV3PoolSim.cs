using System.Numerics;
using System.Threading.Tasks;
using FragolaPlayGround.Models;
using FragolaPlayGround.SolidityLibs;
using Nethereum.ABI;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Uniswap.Contracts.UniswapV3Pool;
using Nethereum.Uniswap.Contracts.UniswapV3Pool.ContractDefinition;

namespace FragolaPlayGround
{
    class UniswapV3PoolSim
    {
        private readonly UniswapV3PoolService _pool;
        //private PositionsOutputDTOBase _position;
        //private ObservationsOutputDTO _observation;
        private Slot0OutputDTO _slot0;
        private BigInteger _liquidity;
        private TicksOutputDTO _currentTickInfo;
        public PositionsOutputDTO CurrentPosition;
        public UniswapV3PoolSim(UniswapV3PoolService pool)
        {
            _pool = pool;
        }
        public async Task<(BigInteger amount0, BigInteger amount1)> Burn(int tickLower, int tickUpper, BigInteger amount, string positionOwner, uint time)
        {
            var parameters = new ModifyPositionParams
            {
                Owner = positionOwner,
                TickLower = tickLower,
                TickUpper = tickUpper,
                LiquidityDelta = -amount
            };
            var (position, amount0Int, amount1Int) = await ModifyPosition(parameters, time);
            var amount0 = -amount0Int;
            var amount1 = -amount1Int;

            if (amount0 > 0 || amount1 > 0)
            {
                position.TokensOwed0 += amount0;
                position.TokensOwed1 += amount1;
            }

            CurrentPosition = position;
            return (amount0, amount1);
        }

        

        private async Task<(PositionsOutputDTO position, BigInteger amount0, BigInteger amount1)> ModifyPosition(
            ModifyPositionParams parameters, uint time)
        {
            TicksValidation.CheckTicks(parameters.TickLower, parameters.TickUpper);
            //Slot0OutputDTO
            _slot0 = await _pool.Slot0QueryAsync();
            BigInteger amount0 = 0;
            BigInteger amount1 = 0;
            var position = await UpdatePosition(
                parameters.Owner,
                parameters.TickLower,
                parameters.TickUpper,
                parameters.LiquidityDelta,
                _slot0.Tick,
                time
                );
            if (parameters.LiquidityDelta != 0)
            {
                if (_slot0.Tick < parameters.TickLower)
                {
                    amount0 = SqrtPriceMath.GetAmount0Delta(
                        TickMath.GetSqrtRatioAtTick(parameters.TickLower),
                        TickMath.GetSqrtRatioAtTick(parameters.TickUpper),
                        parameters.LiquidityDelta);
                } else if (_slot0.Tick < parameters.TickUpper)
                {
                    var liquidityBefore = _liquidity;
                    amount0 = SqrtPriceMath.GetAmount0Delta(
                        _slot0.SqrtPriceX96,
                        TickMath.GetSqrtRatioAtTick(parameters.TickUpper),
                        parameters.LiquidityDelta
                        );
                    amount1 = SqrtPriceMath.GetAmount1Delta(
                    TickMath.GetSqrtRatioAtTick(parameters.TickLower),
                    _slot0.SqrtPriceX96,
                        parameters.LiquidityDelta
                        );
                    _liquidity = LiquidityMath.AddDelta(liquidityBefore, parameters.LiquidityDelta);
                }
                else
                {
                    amount1 = SqrtPriceMath.GetAmount1Delta(
                        TickMath.GetSqrtRatioAtTick(parameters.TickLower),
                        TickMath.GetSqrtRatioAtTick(parameters.TickUpper),
                        parameters.LiquidityDelta
                    );
                }
            }
            return (position, amount0, amount1);
        }

        private async Task<PositionsOutputDTO> UpdatePosition(string owner, int tickLower, int tickUpper, BigInteger liquidityDelta, int tick, uint time)
        {
            var positionKey = PositionKey.Compute(owner, tickLower, tickUpper);
            var position = await _pool.PositionsQueryAsync(positionKey);
            var feeGrowthGlobal0X128 = await _pool.FeeGrowthGlobal0X128QueryAsync();
            var feeGrowthGlobal1X128 = await _pool.FeeGrowthGlobal1X128QueryAsync();

            var maxLiquidityPerTick = await _pool.MaxLiquidityPerTickQueryAsync();
            _liquidity = await _pool.LiquidityQueryAsync();
            
            if (liquidityDelta != 0)
            {
                var (tickCumulative, secondsPerLiquidityCumulativeX128) = await ObserveSinge(time, _slot0.Tick,
                    _slot0.ObservationIndex, _liquidity);
                _currentTickInfo = await _pool.TicksQueryAsync(tick);
                _currentTickInfo = Tick.Update(_currentTickInfo, tickLower, tick, liquidityDelta, feeGrowthGlobal0X128,
                    feeGrowthGlobal1X128, secondsPerLiquidityCumulativeX128, tickCumulative, time, false,
                    maxLiquidityPerTick);

                _currentTickInfo = Tick.Update(_currentTickInfo, tickUpper, tick, liquidityDelta,
                    feeGrowthGlobal0X128,
                    feeGrowthGlobal1X128, secondsPerLiquidityCumulativeX128, tickCumulative, time, true,
                    maxLiquidityPerTick);
            }
            var lowerTickInfo = await _pool.TicksQueryAsync(tickLower);
            var upperTickInfo = await _pool.TicksQueryAsync(tickUpper);

            var (feeGrowthInside0X128, feeGrowthInside1X128) = Tick.GetFeeGrowthInside(lowerTickInfo, upperTickInfo, tickLower, tickUpper,
                tick, feeGrowthGlobal0X128, feeGrowthGlobal1X128);
            var encoder = new ABIEncode();
            if (feeGrowthInside0X128 < 0)
            {
                feeGrowthInside0X128 = encoder.GetABIEncoded(new ABIValue("int256", feeGrowthInside0X128)).ToHex()
                    .HexToBigInteger(false);
            }

            if (feeGrowthInside1X128 < 0)
            {
                feeGrowthInside1X128 = encoder.GetABIEncoded(new ABIValue("int256", feeGrowthInside1X128)).ToHex()
                    .HexToBigInteger(false);
            }
            
            position = Position.Update(position, liquidityDelta, feeGrowthInside0X128, feeGrowthInside1X128);
            return position;
        }

        private async Task<(long tickCumulative, BigInteger secondsPerLiquidityCumulativeX128)> ObserveSinge(uint time, int tick, ushort index, BigInteger liquidity)
        {
            var observation = await _pool.ObservationsQueryAsync(index);
            if (observation.BlockTimestamp != time)
                observation = Transform(observation, time, tick, liquidity);

            return (observation.TickCumulative, observation.SecondsPerLiquidityCumulativeX128);
        }

        private ObservationsOutputDTO Transform(ObservationsOutputDTO last, uint blockTimestamp, int tick, BigInteger liquidity)
        {
            var delta = blockTimestamp - last.BlockTimestamp;
            return new ObservationsOutputDTO
            {
                BlockTimestamp = blockTimestamp,
                TickCumulative = last.TickCumulative + tick * delta,
                SecondsPerLiquidityCumulativeX128 = last.SecondsPerLiquidityCumulativeX128 +
                                                    (new BigInteger(delta) << 128) / (liquidity > 0 ? liquidity : 1),
                Initialized = true
            };
        }
    }
}
