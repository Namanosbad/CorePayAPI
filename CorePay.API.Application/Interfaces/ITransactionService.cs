using CorePayAPI.DTOs.Requests;
using CorePayAPI.DTOs.Responses;

namespace CorePay.API.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<Response> TransferMoneyAsync(TransferRequest request);
    }
}
