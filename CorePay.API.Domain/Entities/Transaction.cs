using CorePayAPI.Entities;
using CorePayAPI.Enums;
using CorePayAPI.Repository.Interface;

namespace CorePay.API.Domain.Entities

{
    public class Transaction : Entity
    {

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        public decimal Amount { get; set; }

        public TransferStatus Status { get; set; }

        public DateTime Date { get; set; }

    }
}
