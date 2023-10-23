using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetHotel.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prénom { get; set; }

        public string Courriel { get; set; }

        public string MotDePasse { get; set; }

        public bool ConfirmationCourriel { get; set; }
    }
}
