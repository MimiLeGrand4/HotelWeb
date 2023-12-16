using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetHotel.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "La date de début est obligatoire.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date de début")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateDébut { get; set; }


        [Required(ErrorMessage = "La date de fin est obligatoire.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date de fin")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateFin { get; set; }


        [Required(ErrorMessage = "Le prix de la réservation est obligatoire.")]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix doit être supérieur à zéro.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Prix{ get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }



        public int ChambreId { get; set; }
        public virtual Chambre Chambre { get; set; }

        /*
            public int AuteurId { get; set; }
        public virtual Auteur? Auteur { get; set; }
         */

    }
}
