namespace BlazorApp1.Data.Models
{
    public class Receiver
    {
        public int ReceiverId { get; set; }
        public int ClientId { get; set; }
        public virtual Client? Clients { get; set; }
        public IEnumerable<Parcel>? Parcels { get; set; }
    }
}
