using AccountWebService.Server.Enums;

namespace AccountWebService.Server.Models
{
    public class Account
    {
        public Guid Id { get; private set; }

        public string Labels { get; set; }

        public AccountType Type { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public Account()
        {
            Id = Guid.NewGuid();
        }
    }
}