namespace Catalog.Settings
{
    public class MongoDbSettings
    {
        public string? Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string ConnectionString 
        { 
            get
            {
                return $"mongodb://{User}:{Password}@{Host}:{Port}";
            }
        }
    }
}
