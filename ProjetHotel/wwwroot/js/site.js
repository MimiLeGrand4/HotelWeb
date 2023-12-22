// Crée une nouvelle connexion SignalR en utilisant la configuration spécifiée
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/learningHub") // Configure l'URL du hub
    .configureLogging(signalR.LogLevel.Information) // Configure le niveau de journalisation
    .build();

// Définit une méthode pour traiter les messages reçus du hub
connection.on("ReceiveMessage", (message) => {
    $('#signalr-message-panel').prepend($('<div />').text(message));
});

$('#btn-broadcast').click(function () {
    var message = $('#broadcast').val().trim();
    if (message) {
        connection.invoke("BroadcastMessage", message)
            .then(() => alert("Message diffusé avec succès!"))
            .catch(err => console.error(err.toString()));
    } else {
        alert("Veuillez entrer un message avant de diffuser.");
    }
});

// Associe une fonction de rappel au clic du bouton avec l'ID 'btn-others-message'
//$('#btn-others-message').click(function () {
//    if (message) {
//        var message = $('#others-message').val();
//        // Invoque la méthode côté serveur 'SendToOthers' avec le message spécifié
//        connection.invoke("SendToOthers", message)
//            .then(() => alert("Message envoyé avec succès!"))
//            .catch(err => console.error(err.toString()));
//    } else {
//        alert("Veuillez entrer un message avant d'envoyer.");
//    }
//});

// Associe une fonction de rappel au clic du bouton avec l'ID 'btn-self-message'
$('#btn-self-message').click(function () {
    if (message) {
        var message = $('#self-message').val();
        // Invoque la méthode côté serveur 'SendToCaller' avec le message spécifié
        connection.invoke("SendToCaller", message)
            .then(() => alert("Message envoyé avec succès!"))
            .catch(err => console.error(err.toString()));
    } else {
        alert("Veuillez entrer un message avant d'envoyer.");
    }
});

// Associe une fonction de rappel au clic du bouton avec l'ID 'btn-group-message'
$('#btn-group-message').click(function () {
    if (message) {
        var message = $('#group-message').val();
        var group = $('#group-for-message').val();
        // Invoque la méthode côté serveur 'SendToGroup' avec le groupe et le message spécifiés
        connection.invoke("SendToGroup", group, message)
            .then(() => alert("Message envoyé avec succès!"))
            .catch(err => console.error(err.toString()));
    }
    else {
        alert("Veuillez entrer un message avant d'envoyer.");
    }
    
});

// Associe une fonction de rappel au clic du bouton avec l'ID 'btn-group-add'
$('#btn-group-add').click(function () {
    var group = $('#group-to-add').val();
    if (!$('#group-to-add').val()) return alert("Veuillez entrer un nom de groupe avant d'ajouter.")
    // Invoque la méthode côté serveur 'AddUserToGroup' avec le groupe spécifié
    connection.invoke("AddUserToGroup", group)
        .then(() => alert("Groupe ajouté avec succès!"))
        .catch(err => console.error(err.toString()));
});

// Associe une fonction de rappel au clic du bouton avec l'ID 'btn-group-remove'
$('#btn-group-remove').click(function () {
    var group = $('#group-to-remove').val();
    if (!$('#group-to-remove').val()) return alert("Veuillez entrer un nom de groupe avant de supprimer.")
    // Invoque la méthode côté serveur 'RemoveUserFromGroup' avec le groupe spécifié
    connection.invoke("RemoveUserFromGroup", group)
        .then(() => alert("Groupe supprimé avec succès!"))
        .catch(err => console.error(err.toString()));
});
$('#btn-message-to-username').click(function () {
    var selectedUser = $('#user-select').val(); // Récupère l'utilisateur sélectionné
    var message = $('#message-to-username').val(); // Récupère le message
    if (selectedUser && message) {
        // Invoque la méthode du hub pour envoyer le message à l'utilisateur sélectionné
        connection.invoke("SendToUserByUsername", selectedUser, message)
            .then(() => alert("Message envoyé avec succès!"))
            .catch(err => console.error(err.toString()));
    }
    else {
        alert("Veuillez sélectionner un utilisateur et entrer un message avant d'envoyer.");
    }
});

$('#btn-clear-messages').click(function () {
    $('#signalr-message-panel').empty(); // Vide le contenu du panneau d'affichage
});


// Fonction asynchrone pour démarrer la connexion SignalR
async function start() {
    try {
        await connection.start(); // Tente de démarrer la connexion
        console.log('connected');
    } catch (err) {
        console.log(err);
        setTimeout(() => start(), 5000); // En cas d'échec, réessaie après 5 secondes
    }
}

// Gère l'événement de fermeture de la connexion en redémarrant la connexion
connection.onclose(async () => {
    await start();
});
connection.on("UpdateUsersList", function (users) {
    updateUsersList(users);
});
function updateUsersList(users) {
    const usersSelect = $('#user-select');
    usersSelect.empty();
    users.forEach(user => {
        usersSelect.append($('<option></option>').val(user).text(user));
    });
}


// Démarre la connexion lors du chargement de la page
start();
