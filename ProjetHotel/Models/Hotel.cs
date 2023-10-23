using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace ProjetHotel.Models
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Adresse { get; set; }

        public string Téléphone { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public string UrlImage { get; set; }
    }
}
