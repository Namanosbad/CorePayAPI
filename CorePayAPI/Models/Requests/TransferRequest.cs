namespace CorePayAPI.DTOs.Requests
{
    public class TransferRequest
    {
        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        public decimal Amount { get; set; }
    }
}
