
    function GetSelectedText() {
        var value = document.getElementById("cidade");
       
        var result = value.options[value.selectedIndex].Text;
        alert(result);

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

