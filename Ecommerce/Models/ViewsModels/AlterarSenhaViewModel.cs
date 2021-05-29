using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models.ViewsModels
{
    public class AlterarSenhaViewModel
    {

        [Required]
        [Key]
        [Display(Name = "CPF")]
        [StringLength(14, MinimumLength = 12, ErrorMessage = "CPF Inválido")]
        public string cpf { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Deve ter pelo menos 5 caracteres de comprimento.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("senha", ErrorMessage = "Senha e confirmação não são as mesmas.")]
        public string Confirmsenha { get; set; }
    }
}