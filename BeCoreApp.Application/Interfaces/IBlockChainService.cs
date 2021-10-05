using BeCoreApp.Application.ViewModels.BlockChain;
using BeCoreApp.Utilities.Dtos;
using System.Threading.Tasks;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3.Accounts;

namespace BeCoreApp.Application.Interfaces
{
    public interface IBlockChainService
    {
        Account CreateERC20AndBEP20Account();

        CoinMarKetCapInfoViewModel GetListingLatest(int startIndex, int limitItem, string unitConvertTo);

        Task<Transaction> GetTransactionByTransactionID(string transactionID, string urlRPC);
        Task<TransactionReceipt> GetTransactionReceiptByTransactionID(string transactionID, string urlRPC);
        Task<decimal> GetERC20Balance(string owner, string smartContractAddress, int decimalPlaces, string urlRPC);

        Task<decimal> GetEtherBalance(string publishKey, string urlRPC);

        Task<string> SendERC20Async(string privateKeyERC20VT, string receiverAddress,
            string contractAddress, decimal tokenAmount, int decimalPlaces, string urlRPC);

        Task<TransactionReceipt> SendEthAsync(string privateKey, string receiverAddress, decimal tokenAmount, string urlRPC);

        decimal GetCurrentPrice(string unit, string unitConverto);
    }
}
