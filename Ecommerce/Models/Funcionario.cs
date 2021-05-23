using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Funcionario
    {
        //CREATE TABLE Funcionario (
        //cd_func INTEGER,
        //nome_func VARCHAR(100),
        //senha_func VARCHAR(10),
        //CPF_func VARCHAR(11) not null unique,
        //cargo_func VARCHAR(50) not null,
        //tipo ENUM ('1','2','3') not null


        [Required]
        [Key]
        [Display(Name = "Código")]
        public string cd_func { get; set; }


        [StringLength(100, ErrorMessage = "O limite é de 100 caracteres.")]
        [Display(Name = "Nome")]
        public string nome { get; set; }


        [StringLength(50, ErrorMessage = "O limite é de 50 caracteres.")]
        [Display(Name = "Cargo")]
        public string cargo_func { get; set; }

        [Display(Name = "CPF")]
        [StringLength(14, MinimumLength = 12, ErrorMessage = "CPF Inválido")]
        
        public string CPF { get; set; }



        [Required]
        [Display(Name = "Registro geral")]
        [StringLength(14, MinimumLength = 9, ErrorMessage = "RG Inválido")]
        public string rg { get; set; }


        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string telefone { get; set; }


        [Display(Name = "Senha")]
        public string senha { get; set; }


        [Display(Name = "Tipo")]
        public string tipo { get; set; }


        [Display(Name = "Foto")]
        public string img { get; set; }


    }
}