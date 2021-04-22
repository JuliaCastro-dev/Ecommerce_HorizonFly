using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Cartao
    {
        //        create table tbl_Cartão(
        //        cd_cartao int primary key auto_increment,
        //        nm_impresso varchar(50),
        //        nm_cartao varchar(50),
        //        ano_cartao date,
        //        cvv_cartao int,
        //        mes_cartao varchar(50),
        //        num_cartao int
        //        );


        [Required]
        [Key]
        [CreditCard]
        [Display(Name = "Código do cartão")]
        public string cd_cartao { get; set; }


        [StringLength(50, ErrorMessage = "O limite é de 10 caracteres.")]
        [Display(Name = "Nome impresso")]
        public string nm_impresso { get; set; }



        [StringLength(50, ErrorMessage = "O limite é de 10 caracteres.")]
        [Display(Name = "Nome do cartão")]
        public string nm_cartao { get; set; }




        [Required]
        [Display(Name = "Ano do cartão")]
        public string ano_cartao { get; set; }


     

        [Required]
        [Display(Name = "CVV do cartão")]
        public string cvv_cartao { get; set; }


        [StringLength(50, ErrorMessage = "O limite é de 50 caracteres.")]
        [Display(Name = "Mes do cartão")]
        public string mes_cartao { get; set; }


        [Required]
        [Display(Name = "Número do cartão")]
        public string numn_cartao { get; set; }
    }
}