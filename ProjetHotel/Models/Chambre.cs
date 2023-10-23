using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace ProjetHotel.Models
{
    public class Chambre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }

        public int NuméroPorte { get; set; }

        public int NombreLit { get; set; }

        [DataType(DataType.Currency)]
        public int Prix { get; set; }

        public bool Disponible { get; set; }

        public string UrlImage { get; set; }
    }
}
