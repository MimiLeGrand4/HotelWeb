namespace ProjetHotel.Hubs
{
    public interface ILearningHubClient
    {
        Task ReceiveMessage(string message);
    }
}
