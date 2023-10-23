using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetHotel.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Contenu { get; set; }

        public DateTime DateEnvoi { get; set; }

        public int UtilisateurId { get; set; }
        public virtual Client Client { get; set; }
    }
}
