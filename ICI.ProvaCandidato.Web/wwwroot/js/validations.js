function verificarCamposVaziosTag() {
    var descricao = document.getElementById("descricao").value.trim();

    if (descricao === "") {
        alert("Por favor, preencha o campo da descrição.");
        return false;
    } else {
        return true;
    }
}

function verificarCamposVaziosUsuario() {
    var nome = document.getElementById("nome").value.trim();
    var password = document.getElementById("password").value.trim();
    var email = document.getElementById("email").value.trim();

    if (nome === "" || password === "" || email === "") {
        alert("Por favor, preencha todos os campos.");
        return false;
    } else {
        return true;
    }
}

function verificarCamposVaziosNoticia() {
    var titulo = document.getElementById("titulo").value.trim();
    var texto = document.getElementById("texto").value.trim();

    if (titulo === "" || texto === "") {
        alert("Por favor, preencha todos os campos.");
        return false;
    } else {
        return true;
    }
}