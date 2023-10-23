using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetHotel.Models
{
    public class Paiement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public decimal Prix { get; set; }

        public DateTime DatePaiment { get; set; }

        public string Méthode { get; set; }

        public string Satut { get; set; }

        public int RéservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
