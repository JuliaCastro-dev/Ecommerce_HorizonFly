using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Cidade
    {
        //create table Cidade(
        //cd_cidade int primary key auto_increment,
        //cd_estado int,
        //nm_cidade varchar(50),
        //foreign key(cd_estado) references Estado(cd_estado));


        [Required]
        [Key]
        [Display(Name = "Código Cidade")]
        public string cd_cidade { get; set; }

        public string cd_estado { get; set; }

        public string cidade { get; set; }

        





    }
}