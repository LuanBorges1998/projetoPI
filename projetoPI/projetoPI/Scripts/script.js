$(document).ready(function () {
    $("#listaUsuario").click(function (evento) {
        $("#multiCollapseExample2").addClass('collapse')
            .removeClass('in');
    });
    $("#criarUsuario").click(function (evento) {
        $("#multiCollapseExample1").addClass('collapse')
            .removeClass('in');
    });

    $("#valor_pago").keypress(function (e) {
        if (e.which === 8 || e.which === 0) {
            
        } else {
            e.preventDefault();
            str = $(this).val();
            if (e.which === 46) {
                $("#valor_pago").val(str + ",");
            } else {
                $("#valor_pago").val(str + String.fromCharCode(e.which));
            }
        }
    });
}); 