using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace ProjetHotel.Hubs
{
    // Définit la classe LearningHub en tant que hub SignalR avec ILearningHubClient comme interface cliente
    public class LearningHub : Hub<ILearningHubClient>
    {
        private static readonly Dictionary<string, string> _connections = new Dictionary<string, string>();
        private readonly UserManager<IdentityUser> _userManager;
        public LearningHub(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        // Méthode pour diffuser un message à tous les clients connectés
        public async Task BroadcastMessage(string message)
        {
            await Clients.All.ReceiveMessage(GetMessageToSend(message));
        }

        // Méthode pour envoyer un message à tous les autres clients, sauf le destinataire actuel
        public async Task SendToOthers(string message)
        {
            await Clients.Others.ReceiveMessage(GetMessageToSend(message));
        }

        // Méthode pour envoyer un message au client appelant (celui qui a initié l'appel)
        public async Task SendToCaller(string message)
        {
            await Clients.Caller.ReceiveMessage(GetMessageToSend(message));
        }

        // Méthode pour envoyer un message à un client individuel en utilisant son ID de connexion
        //public async Task SendToIndividual(string connectionId, string message)
        //{
        //    await Clients.Client(connectionId).ReceiveMessage(GetMessageToSend(message));
        //}

        // Méthode pour envoyer un message à tous les clients d'un groupe spécifique
        public async Task SendToGroup(string groupName, string message)
        {
            await Clients.Group(groupName).ReceiveMessage(GetMessageToSend(message));
        }

        // Méthode pour ajouter un utilisateur à un groupe spécifique
        public async Task AddUserToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Caller.ReceiveMessage($"L'utilisateur actuel a été ajouté au groupe {groupName}");
            await Clients.Others.ReceiveMessage($"L'utilisateur {Context.ConnectionId} a été ajouté au groupe {groupName}");
        }

        // Méthode pour retirer un utilisateur d'un groupe spécifique
        public async Task RemoveUserFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Caller.ReceiveMessage($"L'utilisateur actuel a été retiré du groupe {groupName}");
            await Clients.Others.ReceiveMessage($"L'utilisateur {Context.ConnectionId} a été retiré du groupe {groupName}");
        }

        // Méthode appelée lorsqu'un client se connecte
        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            var user = await _userManager.FindByIdAsync(userId);
            var username = user?.UserName; // récupérer le username
            if (!string.IsNullOrEmpty(username))
            {
                _connections[Context.ConnectionId] = username;
            }
            System.Diagnostics.Debug.WriteLine($"L'utilisateur {username} s'est connecté avec l'ID de connexion {Context.ConnectionId}");
            await base.OnConnectedAsync();
            await Clients.All.UpdateUsersList(GetConnectedUsers());
        }

        // Méthode appelée lorsqu'un client se déconnecte
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (_connections.ContainsKey(Context.ConnectionId))
            {
                _connections.Remove(Context.ConnectionId);
            }
            await base.OnDisconnectedAsync(exception);
            await Clients.All.UpdateUsersList(GetConnectedUsers());
        }

        // Méthode utilitaire pour formater un message avec l'ID de connexion du client
        private string GetMessageToSend(string originalMessage)
        {

            // Récupérer le username associé à l'ID de connexion actuel
            _connections.TryGetValue(Context.ConnectionId, out var username);

            // Si le username n'est pas trouvé, vous pouvez choisir de retourner un message différent
            // ou simplement utiliser une valeur par défaut comme "Inconnu"
            username ??= "Inconnu";

            // Formatage et renvoi du message avec le username
            return $"ID de connexion de l'utilisateur : {Context.ConnectionId}. Utilisateur : {username}. Message : {originalMessage}";
        }
        private string GetConnectionIdByUsername(string username)
        {
            var connectionId = _connections.FirstOrDefault(x => x.Value == username).Key;
            return connectionId ?? string.Empty; // Retourne une chaîne vide si le username n'est pas trouvé
        }
        public IEnumerable<string> GetConnectedUsers()
        {
            return _connections.Values.Distinct();
        }

        public async Task SendToUserByUsername(string username, string message)
        {
            var connectionId = GetConnectionIdByUsername(username);
            if (!string.IsNullOrEmpty(connectionId))
            {
                await Clients.Client(connectionId).ReceiveMessage(GetMessageToSend(message));
            }
            else
            {
                await Clients.Caller.ReceiveMessage($"L'utilisateur {username} n'est pas connecté.");
            }
        }




    }

}
