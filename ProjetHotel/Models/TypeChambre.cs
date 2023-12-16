using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetHotel.Models
{
    public class TypeChambre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeChambreId { get; set; }

        [Required(ErrorMessage = "Le type d'une chambre est obligatoire.")]
        public string Type { get; set; }

        public virtual ICollection<Chambre> chambres { get; set; }
    }
}
