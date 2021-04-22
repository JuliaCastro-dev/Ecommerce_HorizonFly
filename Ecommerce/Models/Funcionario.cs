using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Funcionario
    {
        //create table tbl_Funcionario(
        //cd_func int primary key auto_increment,
        //nm_func varchar(50),
        //cargo_func varchar(50)


        [Required]
        [Key]
        [Display(Name = "Código")]
        public string cd_func { get; set; }


        [StringLength(50, ErrorMessage = "O limite é de 50 caracteres.")]
        [Display(Name = "Nome")]
        public string nm_func { get; set; }


        [StringLength(50, ErrorMessage = "O limite é de 50 caracteres.")]
        [Display(Name = "Cargo")]
        public string cargo_func { get; set; }

    }
}