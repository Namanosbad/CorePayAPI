using System.Text.Json.Serialization;

namespace CorePayAPI.DTOs.Responses
{
    public class TransferResponse
    {
        public int SenderId { get; set; }
        public string? SenderName { get; set; }
        public decimal SenderBalance { get; set; }
        public int ReceiverId { get; set; }
        public string? ReceiverName { get; set; }
        public decimal ReceiverBalance { get; set; }
    }

    public class Response
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public object? Data { get; set; }
    }
}
