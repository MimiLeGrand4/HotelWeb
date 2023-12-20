using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProjetHotel.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<TypeChambre> TypeChambres { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Chambre> Chambres { get; set; }
      
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<Message> Messages { get; set; }

        public void SeedData()
        {
            var SampleType = SampleDonnées.getTypeChambres();

            var existingType = new HashSet<string>(TypeChambres.Select(t => t.Type));
            foreach (var type in SampleType)
            {
                if (!existingType.Contains(type.Type))
                {
                    TypeChambres.Add(type);
                }
            }

            SaveChanges();
        }
    }
}
