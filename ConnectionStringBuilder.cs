using Microsoft.Extensions.Configuration;

namespace PriceCounter
{
    public static class ConnectionStringBuilder
    {
        private static string ConnectionString { get; set; }
        public static string Build()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();

            ConnectionString = config.GetConnectionString("DefaultConnection");

            return ConnectionString;
        }
    }
}
