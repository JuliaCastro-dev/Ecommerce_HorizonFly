using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class IndexViewModel
    {


        [Required]
        [StringLength(150, ErrorMessage = "O limite é de 150 caracteres.")]
        [Display(Name = "Nome")]
        public string nome_cliente { get; set; }


        [Required]
        [Key]
        [StringLength(12, ErrorMessage = "O limite é de 12 caracteres.")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }


        [Required]
        [StringLength(12, ErrorMessage = "O limite é de 12 caracteres.")]
        [Display(Name = "Registro geral")]
        public string rg_cliente { get; set; }


        [Required]
        [StringLength(200, ErrorMessage = "O limite é de 200 caracteres.")]
        [Display(Name = "Endereço")]
        public string endereco_cliente { get; set; }


        [Required]
        [StringLength(10, ErrorMessage = "O limite é de 10 caracteres.")]
        [Display(Name = "Senha")]
        public string senha { get; set; }



        [Display(Name = "Tipo")]
        public string tipo { get; set; }



        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string telefone_cliente { get; set; }


    }
}