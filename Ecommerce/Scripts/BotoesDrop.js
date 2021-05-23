var $botao = $("#btn-dpw");
$botao.click(function () {
    if ($botao.hasClass("branco"))
        $botao.addClass("azul").removeClass("branco");
    else
        $botao.addClass("branco").removeClass("azul");
});