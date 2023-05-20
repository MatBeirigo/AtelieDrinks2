document.addEventListener("DOMContentLoaded", function () {
    // Seleciona o botão para abrir o Modal-card
    var btn = document.getElementById("myBtn");

    // Seleciona o Modal-card
    var modalCard = document.getElementById("background-black");

    // Seleciona o botão para fechar o Modal-card
    var span = document.getElementsByClassName("fechar-Modal-card")[0];

    // Função para abrir o Modal-card
    function abrirmodalCard() {
        modalCard.style.display = "block";
    }

    // Função para fechar o Modal-card
    function fecharmodalCard() {
        modalCard.style.display = "none";
    }

    // Abre o Modal-card quando o botão for clicado
    btn.addEventListener("click", abrirmodalCard);

    // Fecha o Modal-card quando o botão de fechar for clicado
    span.addEventListener("click", fecharmodalCard);

    // Fecha o Modal-card quando o usuário clicar fora do Modal-card
    window.addEventListener("click", function (event) {
        if (event.target == modalCard) {
            fecharmodalCard();
        }
    });
});
