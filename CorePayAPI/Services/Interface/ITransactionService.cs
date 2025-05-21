using CorePayAPI.DTOs.Requests;
using CorePayAPI.DTOs.Responses;

namespace CorePayAPI.Services.Interface
{
    public interface ITransactionService
    {
        Task<Response> TransferMoneyAsync(TransferRequest request);
    }
}
