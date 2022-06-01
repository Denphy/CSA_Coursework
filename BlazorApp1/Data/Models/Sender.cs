namespace BlazorApp1.Data.Models
{
    public class Sender
    {
        public int SenderId { get; set; }
        public int ClientId { get; set; }
        public virtual Client? Clients { get; set; }
        public IEnumerable<Parcel>? Parcels { get; set; }
    }
}
