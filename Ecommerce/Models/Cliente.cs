using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Cliente
    {

        //CREATE TABLE Cliente (
        //nome_cliente VARCHAR(150) not null,
        //telefone_cliente VARCHAR(11) not null,
        //endereco_cliente VARCHAR(200) not null,
        //cpf_cliente VARCHAR(12) not null unique primary key auto_increment,
        //rg_cliente VARCHAR(9) not null unique,
        //senha VARCHAR(10) not null unique,
        //tipo ENUM ('1','2','3') not null



        [Required]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "O limite é de 150 caracteres.")]
        [Display(Name = "Nome")]
        public string nome { get; set; }


        [Required]
        [Key]
        [Display(Name = "CPF")]
        [StringLength(14, MinimumLength = 12, ErrorMessage = "CPF Inválido")]
        public string CPF { get; set; }


        [Required]
        [Display(Name = "Registro geral")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "RG Inválido")]
        public string rg { get; set; }


        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string email{ get; set; }


        [Required]
        [StringLength(10, ErrorMessage = "O limite é de 10 caracteres.")]
        [Display(Name = "Senha")]
        public string senha { get; set; }



        [Display(Name = "Tipo")]
        public string tipo { get; set; }

        [Display(Name = "Foto de perfil")]
        public string img { get; set; }



        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string telefone { get; set; }

    }
}