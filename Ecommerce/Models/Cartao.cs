using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Cartao
    {
            //        CREATE TABLE Cartao(
            //      cd_cartao INTEGER PRIMARY KEY auto_increment,
            //      nm_cartao VARCHAR(50),
            //    nm_impresso VARCHAR(100),
            //    cvv_cartao VARCHAR(3),
            //    validade_cartao VARCHAR(7),
            //    num_cartao VARCHAR(16) UNIQUE
            //);


        [Required]
        [Key]
        [Display(Name = "Código do cartão")]
        public string cd_cartao { get; set; }

        [Display(Name = "CPF")]
        [StringLength(14, MinimumLength = 12, ErrorMessage = "CPF Inválido")]
        public string cpf { get; set; }

        [StringLength(50, ErrorMessage = "O limite é de 10 caracteres.")]
        [Display(Name = "Nome impresso")]
        public string nm_impresso { get; set; }



        [StringLength(50, ErrorMessage = "O limite é de 10 caracteres.")]
        [Display(Name = "Nome do cartão")]
        public string nm_cartao { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "O limite é de 7 caracteres.")]
        [Display(Name = "Validade cartão")]
        public string validade { get; set; }


        [Required]
        [Display(Name = "CVV do cartão")]
        public string cvv_cartao { get; set; }


        [Required]
        [CreditCard]
        [Display(Name = "Número do cartão")]
        public string num_cartao { get; set; }

        /* ADICIONAIS */
      
        [Display(Name = "Registro geral")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "RG Inválido")]
        public string rg { get; set; }
    }
}