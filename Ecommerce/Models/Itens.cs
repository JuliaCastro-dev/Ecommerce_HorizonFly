using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Itens
    {
        //CREATE TABLE Itens_escolhidos (
        //cd_itensEscolhidos INTEGER not null primary key auto_increment,
        //cd_reserva INTEGER not null,
        //cd_pacote INTEGER not null,
        //FOREIGN KEY (cd_reserva) REFERENCES Reserva (cd_reserva),/*Referencia */
        //FOREIGN KEY (cd_pacote) REFERENCES Pacote (cd_pacote) /*Referencia */


        [Key]
        [Required]
        [Display(Name = "Código dos Itens Escolhidos")]
        public string cd_itensEscolhidos { get; set; }


        [Required]
        [Display(Name = "Código da Reserva")]
        public string cd_reserva { get; set; }


        [Required]
        [Display(Name = "Pacote")]
        public string cd_pacote { get; set; }

    }
}