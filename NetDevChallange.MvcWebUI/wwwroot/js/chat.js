var chanId;

$(document).ready(function () {
    $(".list-group-item").on("click", function () {
        $('.active').removeClass('active');
        $(this).addClass('active');
        chanId = $(this).attr("data-id");
    })
});

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    $.ajax({
        url: '/Chat/Index',
        type: 'post',
        data: { message: message, username: user, channelId: chanId },
        success: function () {
            toastr.success("Mesaj başarılı bir şekilde eklendi.")
            var li = document.getElementById("messages");
            document.getElementById("messagesList").appendChild(li);
            li.textContent = `${user} : ${message}`;
        },
        error: function () {
            toastr.error("Bir hata oluştu");
        }
    })
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});