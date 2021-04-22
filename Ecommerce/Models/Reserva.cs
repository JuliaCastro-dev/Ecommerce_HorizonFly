using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Reserva
    {
        //cd_reserva int primary key auto_increment,
        //nm_passagens varchar(50),
        //voo_ida varchar(50),
        //vl_total decimal (10.2),
        //voo_volta varchar(50),
        //nm_hotel varchar(50),
        //assento varchar(10),
        //dt_saidaH date,
        //dt_entradaH date,
        //cd_cliente int,
        //cd_cartao int
        //);


        [Required]
        [Key]
        [Display(Name = "Código da reserva")]
        public string cd_reserva { get; set; }


        [StringLength(50, ErrorMessage = "O limite é de 50 caracteres.")]
        [Display(Name = "Nome")]
        public string nm_passagens { get; set; }


        [StringLength(50, ErrorMessage = "O limite é de 50 caracteres.")]
        [Display(Name = "Voo de ida")]
        public string voo_ida { get; set; }



        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [Display(Name = "Valor Total")]
        public Decimal vl_total { get; set; }


        [StringLength(50, ErrorMessage = "O limite é de 50 caracteres.")]
        [Display(Name = "Voo de volta")]
        public string voo_volta { get; set; }


        [StringLength(50, ErrorMessage = "O limite é de 50 caracteres.")]
        [Display(Name = "Hotel")]
        public string nm_hotel { get; set; }


        [StringLength(10, ErrorMessage = "O limite é de 10 caracteres.")]
        [Display(Name = "Assento")]
        public string assento { get; set; }



        [Required]
        [Display(Name = "Data de saida")]
        public string dt_saidaH { get; set; }


        [Required]
        [Display(Name = "Data de entrada")]
        public string dt_entradaH { get; set; }



        [Required]
        [Display(Name = "Código do cliente")]
        public string cd_cliente { get; set; }


        [CreditCard]
        [Required]
        [Display(Name = "Código do cartão")]
        public string cd_cartao { get; set; }
    }
}