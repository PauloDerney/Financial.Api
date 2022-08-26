namespace CrossCutting.Configuration
{
    public class ClientSettings
    {
        public Client Notification { get; set; }
    }

    public class Client
    {
        public string Url { get; set; }
        public IDictionary<string, string> CustomValues { get; set; }
    }
}