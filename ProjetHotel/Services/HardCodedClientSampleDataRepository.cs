using Bogus;
using ProjetHotel.Models;

namespace ProjetHotel.Services
{
    public class HardCodedClientSampleDataRepository
    {
        static List<Client> clientsList = new List<Client>();

        public List<Client> getAllClients()
        {
            if (clientsList.Count == 0)
            {
                for (int i = 0; i < 15; i++)
                {
                    clientsList.Add(new Faker<Client>()
                        .RuleFor(c => c.Id, i)
                        .RuleFor(c => c.Nom , f => f.Person.LastName)
                        .RuleFor(c => c.Prénom, f => f.Person.FirstName)
                        .RuleFor(c => c.Courriel, (f, c) => f.Internet.Email(c.Nom, c.Prénom))
                        .RuleFor(c => c.MotDePasse, f => f.Internet.Password())
                        .RuleFor(c => c.ConfirmationCourriel, false)
                        );
                }
            }
            return clientsList;
        }
    }
}
