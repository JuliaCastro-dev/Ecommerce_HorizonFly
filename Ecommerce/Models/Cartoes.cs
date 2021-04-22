using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Cartoes
    {
        //create table Cartões(
        //cd_cartoes int primary key auto_increment,
        //cd_cartao1 int,
        //cd_cartao2 int,
        //cd_cartao3 int
        //);

        [Required]
        [Key]
        [CreditCard]
        [Display(Name = "Código dos cartões")]
        public string cd_cartoes { get; set; }


        [CreditCard]
        [Required]
        [Display(Name = "Código do cartão1")]
        public string cd_cartao1 { get; set; }



        [CreditCard]
        [Required]
        [Display(Name = "Código do cartão2")]
        public string cd_cartao2 { get; set; }



        [CreditCard]
        [Required]
        [Display(Name = "Código do cartão3")]
        public string cd_cartao3 { get; set; }
    }
}