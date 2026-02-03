namespace AccountWebService.Server.Models
{
    public class Account
    {
        public Guid Id { get; private set; }

        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }

        public Account()
        {
            Id = Guid.NewGuid();
        }
    }
}