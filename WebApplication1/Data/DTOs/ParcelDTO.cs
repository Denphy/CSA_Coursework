namespace WebApplication1.Data.DTOs
{
    public class ParcelDTO
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int ReceptionId { get; set; }
        public string ParcelRate { get; set; }
        public string ParcelSize { get; set; }
        public int ParcelWeight { get; set; }
        public string ParcelAddress { get; set; }
        public int ParcelStatus { get; set; }
    }
}
