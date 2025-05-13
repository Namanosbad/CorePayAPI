using CorePayAPI.Repository.Interface;
using System.Text.RegularExpressions;

namespace CorePayAPI.Entities.CorePayDB
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
