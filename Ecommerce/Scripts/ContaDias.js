
  
$(document).ready(function CalculaValores() {
    //pega valor das datas
    var dataUm = new Date(document.getElementById("dataUm").value);
    var dataDois = new Date(document.getElementById("dataDois").value);

    // calcula quantidade de dias
    var diffDays = parseInt((dataUm - dataDois) / (24 * 3600 * 1000));
    // pega valor do hotel
    var vlHotel = $("#valor").val();
    // pega valor da Viagem 
    var vlViagem = $("#valorViagem").val();
    // calcular valor do hotel * quantidade de dias
    var vlTotalHotel = parseInt(diffDays.value * vlHotel.value);
    // calcula valor total do pacote
    var vlTotalPacote = parseInt(vlTotalHotel + vlViagem);
    // atribui valor total do pacote ao input 
    document.getElementById("preco").value = vlTotalPacote;
});
