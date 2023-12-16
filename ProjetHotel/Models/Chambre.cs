using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Web.Mvc;

namespace ProjetHotel.Models
{
    public class Chambre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [DataType(DataType.Text)]
        [AllowHtml]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(6000, ErrorMessage = "La description ne doit pas dépasser 6000 caractères.")]
        public string Description { get; set; }

        [Display(Name = "No de chambre")]
        public int NuméroPorte { get; set; }

        [Required(ErrorMessage = "Le nombre de lits est obligatoire.")]
        [Range(1, int.MaxValue, ErrorMessage = "Le nombre de lits doit être supérieur à zéro.")]
        [Display(Name = "Nombre de lit")]
        public int NombreLit { get; set; }

        [Required(ErrorMessage = "Le prix de la chambre est obligatoire.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix doit être supérieur à zéro.")]
        public decimal? Prix { get; set; }

        [Required(ErrorMessage = "La disponibilité la chambre est obligatoire.")]
        public bool Disponible { get; set; }

        [Display(Name = "Photo")]
        public string UrlImage { get; set; }

        public int TypeChambreId { get; set; }
        public virtual TypeChambre? TypeChambre { get; set; }
    }
}
