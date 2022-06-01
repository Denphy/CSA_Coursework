using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models
{
    public class Reception
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int ReceptionId { get; set; }
        public string ReceptionName { get; set; }
        public string ReceptionAddress { get; set; }
        public string ReceptionWeekdayStartTime { get; set; }
        public string ReceptionWeekdayEndTime { get; set; }
        public string ReceptionWeekendStartTime { get; set; }
        public string ReceptionWeekendEndTime { get; set; }
        public IEnumerable<Parcel> Parcels { get; set; }
    }
}
