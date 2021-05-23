using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Windows.Input;

namespace Ecommerce.Models
{
    public class Reserva
    {
        //CREATE TABLE Reserva (
        //cd_reserva INTEGER not null primary key auto_increment,
        //cpf_cliente VARCHAR(12) not null,
        //cd_cartao INTEGER not null,
        //cd_itensEscolhidos INTEGER not null,
        //vl_total DECIMAL(10,2) not null,
        //Status_Reserva BIT,
        //FOREIGN KEY (cpf_cliente) REFERENCES Cliente (cpf_cliente), /*Referencia */
        //FOREIGN KEY (cd_cartao) REFERENCES Cartao (cd_cartao), /*Referencia */
        //FOREIGN KEY (cd_itensEscolhidos) REFERENCES Itens_escolhidos (cd_itensEscolhidos) /*Referencia */




        [Required]
        [Key]
        [Display(Name = "Código da reserva")]
        public string cd_reserva { get; set; }


        [Required]
        [Key]
        [Display(Name = "CPF")]
        [StringLength(14, MinimumLength = 12, ErrorMessage = "CPF Inválido")]
        public string cpf_cliente { get; set; }


        [Required]
        [Display(Name = "Itens Escolhidos")]
        public string cd_itensEscolhidos { get; set; }


        [CreditCard]
        [Required]
        [Display(Name = "Código do cartão")]
        public string cd_cartao { get; set; }



        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [Display(Name = "Valor Total")]
        public Decimal vl_total { get; set; }


        [Display(Name = "Status")]
        public string Status_Reserva { get; set; }

    }
}