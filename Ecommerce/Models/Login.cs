using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Login
    {
        //create table tbl_Login(
        //cd_usuario int primary key auto_increment,
        //usuario varchar (50),
        //senha varchar(10),
        //tipo varchar(50)


        [Required]
        [Key]
        [Display(Name = "Código")]
        public string cd_usuario { get; set; }


        [StringLength(50, ErrorMessage = "O limite é de 50 caracteres.")]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }


        [StringLength(10, ErrorMessage = "O limite é de 10 caracteres.")]
        [Display(Name = "Senha")]
        public string senha { get; set; }



        [StringLength(50, ErrorMessage = "O limite é de 50 caracteres.")]
        [Display(Name = "Tipo")]
        public string tipo { get; set; }
    }
}