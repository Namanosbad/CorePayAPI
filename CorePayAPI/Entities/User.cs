using System.Text.RegularExpressions;

namespace CorePayAPI.Entities
{
    public class User
    {

        public int UserId { get; set; }
        public string? Name { get; set; }
        public Decimal Balance { get; set; }
        public User()
        {
        }

        public User(int userId, string name,decimal balance)
        {
            UserId = userId;
            Name = name;
            Balance = balance;
        }

    }
}
