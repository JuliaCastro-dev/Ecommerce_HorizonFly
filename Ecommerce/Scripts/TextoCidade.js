
    function GetSelectedText() {
        var value = document.getElementById("cidade");
        var drop = $("[id*='cidade'] :selected")

        var resultado = drop.options[drop.selectedIndex].Text;
        var result = value.options[value.selectedIndex].Text;
        alert(resultado);

        //$.ajax({
        //    url: '@Url.Action("CadastroHoteis", "Sistema")',
        //    data: JSON.stringify({ "nmcidade": result }),
        //    type: 'POST',
        //    success: function (nmcidade) {

        //        // return values 
        //        console.log(data.nmcidade); 

        //    }
        //});


    }

