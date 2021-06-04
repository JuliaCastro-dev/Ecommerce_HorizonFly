using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Itens
    {
     //   cd_itensreserva INTEGER not null primary key,
     //cd_pacote INTEGER not null,
     //cd_reserva INTEGER not null,
     //vl_unit DECIMAL(14,0) not null,
     //        vl_parcial DECIMAL(14,0) not null,
     //        qt_itens INTEGER  not null,
     //        status_itens bit null,
     //        CPF VARCHAR(20) not null,

        [Key]
        [Required]
        [Display(Name = "Código dos Itens Escolhidos")]
        public Guid cd_itens{ get; set; }

        [Required]
        
        [Display(Name = "CPF")]
        [StringLength(14, MinimumLength = 12, ErrorMessage = "CPF Inválido")]
        public string CPF { get; set; }



        [Required]
        [Display(Name = "Código da Reserva")]
        public string cd_reserva { get; set; }


        [Required]
        [Display(Name = "Pacote")]
        public string cd_pacote { get; set; }



        [Required]
        [Display(Name = "Valor Unitário")]
        public string vl_unit { get; set; }


        [Required]
        [Display(Name = "Valor Parcial")]
        public string vl_parcial{ get; set; }


        [Display(Name = "Quantidade")]
        public string qt { get; set; }

        [Display(Name = "Status")]
        public string status { get; set; }
    }
}