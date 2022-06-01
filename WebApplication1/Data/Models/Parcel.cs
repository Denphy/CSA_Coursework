using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models
{
    public class Parcel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int ParcelId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int ReceptionId { get; set; }
        public string ParcelRate { get; set; }
        public string ParcelSize { get; set; }
        public int ParcelWeight { get; set; }
        public string ParcelAddress { get; set; }
        public int ParcelStatus { get; set; }
        public virtual Sender Senders { get; set; }
        public virtual Receiver Receivers { get; set; }
        public virtual Reception Receptions { get; set; }
    }
}
