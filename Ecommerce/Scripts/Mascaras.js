﻿

/*MASCARA TELEFONE*/

function mascara(o, f) {
    v_obj = o
    v_fun = f
    setTimeout("execmascara() ", 1)
}
function execmascara() {
    v_obj.value = v_fun(v_obj.value)
}
function mtel(v) {
    v = v.replace(/\D/g, ""); //Remove tudo o que não é dígito
    v = v.replace(/^(\d{2})(\d)/g, "($1) $2"); //Coloca parênteses em volta dos dois primeiros dígitos
    v = v.replace(/(\d)(\d{4})$/, "$1 - $2"); //Coloca hífen entre o quarto e o quinto dígitos
    return v;
}
function id(el) {
    return document.getElementById(el);
}
window.onload = function () {
    id('telefone').onkeyup = function () {
        mascara(this, mtel);
    }
}


function validacaoEmail(field) {
    usuario = field.value.substring(0, field.value.indexOf("@"));
    dominio = field.value.substring(field.value.indexOf("@") + 1, field.value.length);

    if ((usuario.length >= 1) &&
        (dominio.length >= 3) &&
        (usuario.search("@") == -1) &&
        (dominio.search("@") == -1) &&
        (usuario.search(" ") == -1) &&
        (dominio.search(" ") == -1) &&
        (dominio.search(".") != -1) &&
        (dominio.indexOf(".") >= 1) &&
        (dominio.lastIndexOf(".") < dominio.length - 1)) {
        document.getElementById("msgemail").innerHTML = "E-mail válido";
        alert("E-mail valido");
    }
    else {
        document.getElementById("msgemail").innerHTML = "<font color='red'>E-mail inválido </font>";
        alert("E-mail invalido");
    }
}



function ValidaCPF() {
    var RegraValida = document.getElementById("RegraValida").value;
    var cpfValido = /^(([0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2})|([0-9]{11}))$/;
    if (cpfValido.test(RegraValida) == true) {
        console.log("CPF Válido");
    } else {
        console.log("CPF Inválido");
    }
}
function fMasc(objeto, mascara) {
    obj = objeto
    masc = mascara
    setTimeout("fMascEx()", 1)
}

function fMascEx() {
    obj.value = masc(obj.value)
}

function mCPF(cpf) {
    cpf = cpf.replace(/\D/g, "")
    cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2")
    cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2")
    cpf = cpf.replace(/(\d{3})(\d{1,2})$/, "$1-$2")
    return cpf
}

//DROPDOWN COM PESQUISA
$(function () {

    $("#cidade").chosen();

});
$(function () {

    $("#cidadeOrigem").chosen();


});
$(function () {

    $("#tipo").chosen();

});
$(function () {

    $("#pacote").chosen();

});
$(function () {

    $("#categoria").chosen();

});
$(function () {

    $("#transportes").chosen();

});
$(function () {

    $("#transportesOrigem").chosen();
 

});
$(function () {

    $("#hotel").chosen();


});
$(function () {

    $("#viagem").chosen();


});
$(function () {

    $("#cidadeEscolhida").chosen();


});


$(document).ready(function () {
    
    $("#preco").inputmask('currency', {
        "autoUnmask": true,
        radixPoint: ",",
        groupSeparator: ".",
        allowMinus: false,
        prefix: 'R$ ',
        digits: 2,
        digitsOptional: false,
        rightAlign: false,
        unmaskAsNumber: true
    });
    $("#valor").inputmask('currency', {
        "autoUnmask": true,
        radixPoint: ",",
        groupSeparator: ".",
        allowMinus: false,
        prefix: 'R$ ',
        digits: 2,
        digitsOptional: false,
        rightAlign: false,
        unmaskAsNumber: true
    });
    $("#ip").inputmask("mask", { "mask": "999.999.999.999" });
});




//// mascara para moeda
//var currencyInput = document.getElementById("currency")
//var currency = 'BRL' //

//// format inital value
//onBlur({ target: currencyInput })

//// bind event listeners
//currencyInput.addEventListener('focus', onFocus)
//currencyInput.addEventListener('blur', onBlur)


//function localStringToNumber(s) {
//    return Number(String(s).replace(/[^0-9.-]+/g, ""))
//}

//function onFocus(e) {
//    var value = e.target.value;
//    e.target.value = value ? localStringToNumber(value) : ''
//}

//function onBlur(e) {
//    var value = e.target.value

//    var options = {
//        maximumFractionDigits: 2,
//        currency: currency,
//        style: "currency",
        
//    }

//    e.target.value = (value || value === 0)
//        ? localStringToNumber(value).toLocaleString("pt-br", options)
//        : ''
//}