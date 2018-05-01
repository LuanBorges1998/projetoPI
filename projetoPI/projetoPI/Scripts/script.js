$(document).ready(function () {
    $("#listaUsuario").click(function (evento) {
        $("#multiCollapseExample2").addClass('collapse')
            .removeClass('in');
    });
    $("#criarUsuario").click(function (evento) {
        $("#multiCollapseExample1").addClass('collapse')
            .removeClass('in');
    });
}); 