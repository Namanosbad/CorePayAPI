using CorePayAPI.Entities;
using CorePayAPI.Repository.Interface;
using System.Text.RegularExpressions;

namespace CorePay.API.Domain.Entities
{
    public class User : Entity
    {
        public string? Name { get; set; }
        public decimal Balance { get; set; }
        public User()
        {
        }

        public User(int userId, string name, decimal balance)
        {
            Id = userId;
            Name = name;
            Balance = balance;
        }

    }
}
