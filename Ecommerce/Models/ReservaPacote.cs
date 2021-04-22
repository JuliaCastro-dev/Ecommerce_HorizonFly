using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class ReservaPacote
    {
        [Display(Name = "Código Reserva")]
        public string cd_reserva { get; set; }

        [Display(Name = "Código Pacote")]
        public string cd_pacote { get; set; }

        [Display(Name = "Código Cliente")]
        public string cd_cliente { get; set; }


        [Display(Name = "Código Cartão")]
        public string cd_cartão{ get; set; }


        [Display(Name = "Total")]
        public Decimal vl_total { get; set; }



    }
}