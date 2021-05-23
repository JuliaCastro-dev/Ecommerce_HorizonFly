using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Cidade
    {
        //        CREATE TABLE Cidade(
        //    cd_cidade INTEGER PRIMARY KEY auto_increment,
        //    cd_estado INTEGER,
        //    nm_cidade VARCHAR(50),
        //    foreign key(cd_estado) references Estado(cd_estado)
        //);



        [Required]
        [Key]
        [Display(Name = "Código Cidade")]
        public string cd_cidade { get; set; }

        [Display(Name = "Estado")]
        public string cd_estado { get; set; }

        [Display(Name = " Cidade")]
        public string cidade { get; set; }

        





    }
}