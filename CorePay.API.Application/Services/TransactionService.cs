using CorePay.API.Application.Interfaces;
using CorePayAPI.DTOs.Requests;
using CorePayAPI.DTOs.Responses;
using CorePayAPI.Repository.Interface;

namespace CorePay.API.Application.Services
{
    public class TransactionService(ITransferRepository transferRepository) : ITransactionService
    {
        private readonly ITransferRepository _transferRepository = transferRepository;

        public async Task<Response> TransferMoneyAsync(TransferRequest request)
        {
            await _transferRepository.BeginTransactionAsync();

            try
            {
                if (request.Amount <= 0)
                    throw new Exception("Invalid transfer value.");

                var sender = await _transferRepository.GetUserByIdAsync(request.SenderId);
                var receiver = await _transferRepository.GetUserByIdAsync(request.ReceiverId);


                if (sender == null || receiver == null)
                    throw new Exception("user not found.");
           
                if (sender.Balance < request.Amount)
                    throw new Exception("Insufficient balance.");


                sender.Balance -= request.Amount;
                receiver.Balance += request.Amount;

                await _transferRepository.SaveChangesAsync();

                await _transferRepository.CommitTransactionAsync();

                var transfer = new TransferResponse
                {
                    SenderId = sender.Id,
                    SenderName = sender.Name,
                    SenderBalance = sender.Balance,
                    ReceiverId = receiver.Id,
                    ReceiverName = receiver.Name,
                    ReceiverBalance = receiver.Balance
                };

                return new Response
                {
                    Success = true,
                    Data = transfer
                };
            }
            catch (Exception ex)
            {
                await _transferRepository.RollbackTransactionAsync();

                return new Response
                {
                    Success = false,
                    ErrorMessage = $"Transaction failed: {ex.Message}"
                };
            }
        }
    }
}