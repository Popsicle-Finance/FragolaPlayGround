using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace SorbettoFragola.Contracts.ERC20.ContractDefinition
{


    public partial class ERC20Deployment : ERC20DeploymentBase
    {
        public ERC20Deployment() : base(BYTECODE) { }
        public ERC20Deployment(string byteCode) : base(byteCode) { }
    }

    public class ERC20DeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60806040523480156200001157600080fd5b5060405162000aa038038062000aa08339810160408190526200003491620001bc565b81516200004990600390602085019062000075565b5080516200005f90600490602084019062000075565b50506005805460ff191660121790555062000223565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282620000ad5760008555620000f8565b82601f10620000c857805160ff1916838001178555620000f8565b82800160010185558215620000f8579182015b82811115620000f8578251825591602001919060010190620000db565b50620001069291506200010a565b5090565b5b808211156200010657600081556001016200010b565b600082601f83011262000132578081fd5b81516001600160401b03808211156200014757fe5b6040516020601f8401601f19168201810183811183821017156200016757fe5b60405283825285840181018710156200017e578485fd5b8492505b83831015620001a1578583018101518284018201529182019162000182565b83831115620001b257848185840101525b5095945050505050565b60008060408385031215620001cf578182fd5b82516001600160401b0380821115620001e6578384fd5b620001f48683870162000121565b935060208501519150808211156200020a578283fd5b50620002198582860162000121565b9150509250929050565b61086d80620002336000396000f3fe608060405234801561001057600080fd5b50600436106100a95760003560e01c80633950935111610071578063395093511461012957806370a082311461013c57806395d89b411461014f578063a457c2d714610157578063a9059cbb1461016a578063dd62ed3e1461017d576100a9565b806306fdde03146100ae578063095ea7b3146100cc57806318160ddd146100ec57806323b872dd14610101578063313ce56714610114575b600080fd5b6100b6610190565b6040516100c39190610757565b60405180910390f35b6100df6100da366004610723565b610226565b6040516100c3919061074c565b6100f4610244565b6040516100c39190610820565b6100df61010f3660046106e8565b61024a565b61011c6102e2565b6040516100c39190610829565b6100df610137366004610723565b6102eb565b6100f461014a366004610695565b610339565b6100b6610358565b6100df610165366004610723565b6103b9565b6100df610178366004610723565b610424565b6100f461018b3660046106b6565b610438565b60038054604080516020601f600260001961010060018816150201909516949094049384018190048102820181019092528281526060939092909183018282801561021c5780601f106101f15761010080835404028352916020019161021c565b820191906000526020600020905b8154815290600101906020018083116101ff57829003601f168201915b5050505050905090565b600061023a610233610463565b8484610467565b5060015b92915050565b60025490565b6000610257848484610524565b6102d884610263610463565b6102d3856040518060400160405280600381526020016254454160e81b815250600160008b6001600160a01b03166001600160a01b0316815260200190815260200160002060006102b2610463565b6001600160a01b03168152602081019190915260400160002054919061063c565b610467565b5060019392505050565b60055460ff1690565b600061023a6102f8610463565b846102d38560016000610309610463565b6001600160a01b03908116825260208083019390935260409182016000908120918c168152925290205490610669565b6001600160a01b0381166000908152602081905260409020545b919050565b60048054604080516020601f600260001961010060018816150201909516949094049384018190048102820181019092528281526060939092909183018282801561021c5780601f106101f15761010080835404028352916020019161021c565b600061023a6103c6610463565b846102d385604051806040016040528060038152602001622222a160e91b815250600160006103f3610463565b6001600160a01b03908116825260208083019390935260409182016000908120918d1681529252902054919061063c565b600061023a610431610463565b8484610524565b6001600160a01b03918216600090815260016020908152604080832093909416825291909152205490565b3390565b6001600160a01b0383166104965760405162461bcd60e51b815260040161048d906107aa565b60405180910390fd5b6001600160a01b0382166104bc5760405162461bcd60e51b815260040161048d90610802565b6001600160a01b0380841660008181526001602090815260408083209487168084529490915290819020849055517f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b92590610517908590610820565b60405180910390a3505050565b6001600160a01b03831661054a5760405162461bcd60e51b815260040161048d906107e5565b6001600160a01b0382166105705760405162461bcd60e51b815260040161048d906107c8565b61057b838383610679565b60408051808201825260038152622a22a160e91b6020808301919091526001600160a01b03861660009081529081905291909120546105bb91839061063c565b6001600160a01b0380851660009081526020819052604080822093909355908416815220546105ea9082610669565b6001600160a01b0380841660008181526020819052604090819020939093559151908516907fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef90610517908590610820565b81830381848211156106615760405162461bcd60e51b815260040161048d9190610757565b509392505050565b8082018281101561023e57600080fd5b505050565b80356001600160a01b038116811461035357600080fd5b6000602082840312156106a6578081fd5b6106af8261067e565b9392505050565b600080604083850312156106c8578081fd5b6106d18361067e565b91506106df6020840161067e565b90509250929050565b6000806000606084860312156106fc578081fd5b6107058461067e565b92506107136020850161067e565b9150604084013590509250925092565b60008060408385031215610735578182fd5b61073e8361067e565b946020939093013593505050565b901515815260200190565b6000602080835283518082850152825b8181101561078357858101830151858201604001528201610767565b818111156107945783604083870101525b50601f01601f1916929092016040019392505050565b60208082526004908201526341465a4160e01b604082015260600190565b602080825260039082015262545a4160e81b604082015260600190565b602080825260039082015262465a4160e81b604082015260600190565b60208082526004908201526341545a4160e01b604082015260600190565b90815260200190565b60ff9190911681526020019056fea264697066735822122025450eff1644e76e9a1a9f31e0fa752511533f6c4ab3dec140844ba6c3cde40a64736f6c63430007060033";
        public ERC20DeploymentBase() : base(BYTECODE) { }
        public ERC20DeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("string", "name_", 1)]
        public virtual string Name_ { get; set; }
        [Parameter("string", "symbol_", 2)]
        public virtual string Symbol_ { get; set; }
    }

    public partial class AllowanceFunction : AllowanceFunctionBase { }

    [Function("allowance", "uint256")]
    public class AllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "spender", 2)]
        public virtual string Spender { get; set; }
    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve", "bool")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class DecimalsFunction : DecimalsFunctionBase { }

    [Function("decimals", "uint8")]
    public class DecimalsFunctionBase : FunctionMessage
    {

    }

    public partial class DecreaseAllowanceFunction : DecreaseAllowanceFunctionBase { }

    [Function("decreaseAllowance", "bool")]
    public class DecreaseAllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "subtractedValue", 2)]
        public virtual BigInteger SubtractedValue { get; set; }
    }

    public partial class IncreaseAllowanceFunction : IncreaseAllowanceFunctionBase { }

    [Function("increaseAllowance", "bool")]
    public class IncreaseAllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "addedValue", 2)]
        public virtual BigInteger AddedValue { get; set; }
    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    {

    }

    public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

    [Function("totalSupply", "uint256")]
    public class TotalSupplyFunctionBase : FunctionMessage
    {

    }

    public partial class TransferFunction : TransferFunctionBase { }

    [Function("transfer", "bool")]
    public class TransferFunctionBase : FunctionMessage
    {
        [Parameter("address", "recipient", 1)]
        public virtual string Recipient { get; set; }
        [Parameter("uint256", "amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom", "bool")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "sender", 1)]
        public virtual string Sender { get; set; }
        [Parameter("address", "recipient", 2)]
        public virtual string Recipient { get; set; }
        [Parameter("uint256", "amount", 3)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "spender", 2, true )]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class AllowanceOutputDTO : AllowanceOutputDTOBase { }

    [FunctionOutput]
    public class AllowanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class DecimalsOutputDTO : DecimalsOutputDTOBase { }

    [FunctionOutput]
    public class DecimalsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }





    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase { }

    [FunctionOutput]
    public class TotalSupplyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }




}
