using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int ClientId { get; set; }
        public string ClientFullname { get; set; }
        public string ClientPhone { get; set; }
        public virtual Sender Senders { get; set; }
        public virtual Receiver Receivers { get; set; }
    }
}
