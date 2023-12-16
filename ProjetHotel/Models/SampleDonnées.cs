namespace ProjetHotel.Models
{
    public class SampleDonnées
    {
        // Champ privé pour stocker les chambres
        private static List<Chambre> listeChambres = new();

        public static List<Chambre> Chambres => listeChambres;

        public static TypeChambre?[] getTypeChambres()
        {
            DateTime dateTime = new DateTime();
            TypeChambre t1 = new TypeChambre { Type = "Queen" };
            TypeChambre t2 = new TypeChambre { Type = "King" };
            TypeChambre t3 = new TypeChambre { Type = "Standard" };
            TypeChambre t4 = new TypeChambre { Type = "Deluxe" };
            TypeChambre t5 = new TypeChambre { Type = "Suite" };


            t1.chambres = new List<Chambre>();
            t2.chambres = new List<Chambre>();
            t3.chambres = new List<Chambre>();
            t4.chambres = new List<Chambre>();
            t5.chambres = new List<Chambre>();

            Chambre c1 = new Chambre
            { 
                Description = "Standard", 
                NuméroPorte = 101, 
                NombreLit = 1, 
                Prix = 120.00m, 
                Disponible = true, 
                UrlImage = "img/ImgChambre/chambre_standard.jpg",
                TypeChambre = t3
            };
            t3.chambres.Add(c1);
            listeChambres.Add(c1);

            Chambre c2 = new Chambre
            {
                Description = "Standard",
                NuméroPorte = 102,
                NombreLit = 1,
                Prix = 120.00m,
                Disponible = true,
                UrlImage = "img/ImgChambre/chambre_standard.jpg",
                TypeChambre = t3
            };
            t3.chambres.Add(c2);
            listeChambres.Add(c2);

            Chambre c3 = new Chambre
            {
                Description = "Deluxe",
                NuméroPorte = 201,
                NombreLit = 1,
                Prix = 350.00m,
                Disponible = true,
                UrlImage = "img/ImgChambre/chambre_deluxe.jpg",
                TypeChambre = t4
            };
            t4.chambres.Add(c3);
            listeChambres.Add(c3);

            Chambre c4 = new Chambre
            {
                Description = "Single King",
                NuméroPorte = 103,
                NombreLit = 1,
                Prix = 250.50m,
                Disponible = true,
                UrlImage = "img/ImgChambre/chambre_single_king.jpg",
                TypeChambre = t2
            };
            t2.chambres.Add(c4);
            listeChambres.Add(c4);

            Chambre c5 = new Chambre
            {
                Description = "Double Queen",
                NuméroPorte = 202,
                NombreLit = 2,
                Prix = 320.00m,
                Disponible = true,
                UrlImage = "img/ImgChambre/chambre_double_queen.jpg",
                TypeChambre = t1
            };
            t1.chambres.Add(c5);
            listeChambres.Add(c5);

            Chambre c6 = new Chambre
            {
                Description = "Suite",
                NuméroPorte = 301,
                NombreLit = 3,
                Prix = 750.00m,
                Disponible = true,
                UrlImage = "img/ImgChambre/chambre_suite.jpg",
                TypeChambre = t5
            };
            t5.chambres.Add(c6);
            listeChambres.Add(c6);

            Chambre c7 = new Chambre
            {
                Description = "Single Queen",
                NuméroPorte = 104,
                NombreLit = 1,
                Prix = 220.00m,
                Disponible = true,
                UrlImage = "img/ImgChambre/chambre_single_queen.jpg",
                TypeChambre = t1
            };
            t1.chambres.Add(c7);
            listeChambres.Add(c7);

            Chambre c8 = new Chambre
            {
                Description = "Double King",
                NuméroPorte = 203,
                NombreLit = 2,
                Prix = 360.00m,
                Disponible = true,
                UrlImage = "img/ImgChambre/chambre_double_king.jpg",
                TypeChambre = t2
            };
            t2.chambres.Add(c8);
            listeChambres.Add(c1);



            return new TypeChambre?[] { t1, t2, t3, t4, t5};
        }
    }
}
