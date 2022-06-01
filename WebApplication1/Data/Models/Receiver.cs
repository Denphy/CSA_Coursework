using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models
{

    public class Receiver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int ReceiverId { get; set; }
        public int ClientId { get; set; }
        public virtual  Client Clients { get; set; }
        public IEnumerable<Parcel> Parcels { get; set; }
    }
}
