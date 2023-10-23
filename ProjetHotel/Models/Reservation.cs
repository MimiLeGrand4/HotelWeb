using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetHotel.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateDébut { get; set; }
        public DateTime DateFin { get; set; }

        [DataType(DataType.Currency)]
        public int PrixCenne{ get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }


        public int HotelId{ get; set; }
        public virtual Hotel Hotel { get; set; }

        public int ChambreId { get; set; }
        public virtual Chambre Chambre { get; set; }

        /*
            public int AuteurId { get; set; }
        public virtual Auteur? Auteur { get; set; }
         */

    }
}
