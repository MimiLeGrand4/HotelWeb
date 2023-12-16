using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetHotel.Models
{
    public class Paiement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le prix est obligatoire.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix doit être supérieur à zéro.")]
        [DataType(DataType.Currency)]
        public decimal Prix { get; set; }

        [Required(ErrorMessage = "La date de paiement est obligatoire.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date de paiement")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DatePaiment { get; set; }

        [Required(ErrorMessage = "La méthode de paiement est obligatoire.")]
        [DataType(DataType.Text)]
        [Column(TypeName = "VARCHAR")]
        public string Méthode { get; set; }

        [Required(ErrorMessage = "Le statut est obligatoire.")]
        [DataType(DataType.Text)]
        [Column(TypeName = "VARCHAR")]
        public string Satut { get; set; }

        public int RéservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
