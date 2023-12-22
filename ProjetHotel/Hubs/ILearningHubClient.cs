namespace ProjetHotel.Hubs
{
    public interface ILearningHubClient
    {
        Task ReceiveMessage(string message);
        Task UpdateUsersList(IEnumerable<string> users);
    }
}
