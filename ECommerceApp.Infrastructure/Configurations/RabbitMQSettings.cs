namespace ECommerceApp.Infrastructure.Configurations
{
    public class RabbitMQSettings
    {
        public required string Host { get; set; }
        public required string VirtualHost { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Endpoint { get; set; }
    }
}