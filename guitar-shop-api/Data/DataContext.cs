namespace guitar_shop_api.Data
{
    public class DataContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
