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
     //   cd_reserva INTEGER not null primary key auto_increment,
     //   CPF VARCHAR(20) not null,
     //   cd_cartao INTEGER not null,
     //   vl_total Decimal(14,0) not null,
	    //status_reserva bit null,




        [Required]
        [Key]
        [Display(Name = "Código da reserva")]
        public string cd_reserva { get; set; }


        [Required]
        [Key]
        [Display(Name = "CPF")]
        [StringLength(14, MinimumLength = 12, ErrorMessage = "CPF Inválido")]
        public string cpf_cliente { get; set; }



        [CreditCard]
        [Required]
        [Display(Name = "Código do cartão")]
        public string cd_cartao { get; set; }



       
        [Required]
        [Display(Name = "Valor Total")]
        public double vl_total { get; set; }


        [Display(Name = "Status")]
        public string Status_Reserva { get; set; }

        public List<Itens> ItensPedido = new List<Itens>();

    }
}