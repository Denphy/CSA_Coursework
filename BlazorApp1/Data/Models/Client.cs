namespace BlazorApp1.Data.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string? ClientFullname { get; set; }
        public string? ClientPhone { get; set; }
        public virtual Sender? Senders { get; set; }
        public virtual Receiver? Receivers { get; set; }
    }
}
