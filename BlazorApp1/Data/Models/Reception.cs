namespace BlazorApp1.Data.Models
{
    public class Reception
    {
        public int ReceptionId { get; set; }
        public string? ReceptionName { get; set; }
        public string? ReceptionAddress { get; set; }
        public string? ReceptionWeekdayStartTime { get; set; }
        public string? ReceptionWeekdayEndTime { get; set; }
        public string? ReceptionWeekendStartTime { get; set; }
        public string? ReceptionWeekendEndTime { get; set; }
        public IEnumerable<Parcel>? Parcels { get; set; }
    }
}
