using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Usuario
    {
        [Required]
        [Key]
        [Display(Name = "CPF")]
        [StringLength(14, MinimumLength = 12, ErrorMessage = "CPF Inválido")]
        public string cpf { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "O Mínimo é de 10 caracteres.")]
        [Display(Name = "Senha")]
        public string senha { get; set; }

        [Display(Name = "Tipo")]
        public string tipo { get; set; }


        [Display(Name = "Foto de Perfil")]
        public string img { get; set; }


        [Required]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "O limite é de 150 caracteres.")]
        [Display(Name = "Nome")]
        public string nome { get; set; }


        [Required]
        [Display(Name = "Registro geral")]
        [StringLength(14, MinimumLength = 9, ErrorMessage = "RG Inválido")]
        public string rg{ get; set; }


        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string email{ get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string telefone { get; set; }


        [StringLength(50, ErrorMessage = "O limite é de 50 caracteres.")]
        [Display(Name = "Cargo")]
        public string cargo_func { get; set; }
    }
}