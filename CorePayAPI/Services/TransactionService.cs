using CorePayAPI.DTOs.Requests;
using CorePayAPI.DTOs.Responses;
using CorePayAPI.Repository.Interface;
using CorePayAPI.Services.Interface;

namespace CorePayAPI.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransferRepository _transferRepository;

        public TransactionService(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public async Task<Response> TransferMoneyAsync(TransferRequest request)
        {
            var sender = await _transferRepository.GetUserByIdAsync(request.SenderId);
            var receiver = await _transferRepository.GetUserByIdAsync(request.ReceiverId);

            if (sender == null || receiver == null)
                return new Response
                {
                    Success = false,
                    ErrorMessage = "User not found."
                };

            if (sender.Balance < request.Amount)
                return new Response
                {
                    Success = false,
                    ErrorMessage = "Insufficient balance."
                };

            sender.Balance -= request.Amount;
            receiver.Balance += request.Amount;

            await _transferRepository.SaveChangesAsync();

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
    }

}
