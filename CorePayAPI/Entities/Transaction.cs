using CorePayAPI.Enums;

namespace CorePayAPI.Entities

{
    public class Transaction
    {

        public int Id { get; set; }

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        public decimal Amount { get; set; }

        public TransferStatus Status { get; set; }

        public DateTime Date { get; set; }

        public User Name { get; set; }

        public User Balance { get; set; }
    }
}
