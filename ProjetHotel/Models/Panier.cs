using System.ComponentModel.DataAnnotations;

namespace ProjetHotel.Models
{
    public class Panier
    {
        public Chambre Chambre { get; set; }

        [Required(ErrorMessage = "La quantité est obligatoire.")]
        public int Quantite { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
