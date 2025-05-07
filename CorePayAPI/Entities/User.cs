using System.Text.RegularExpressions;

namespace CorePayAPI.Entities
{
    public class User : Entity
    {
        public string? Name { get; set; }
        public decimal Balance { get; set; }
        public User()
        {
        }

        public User(int userId, string name,decimal balance)
        {
            Id = userId;
            Name = name;
            Balance = balance;
        }

    }
}
