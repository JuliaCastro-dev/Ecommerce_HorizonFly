using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Pacote
    {
        //create table Pacote(
        //cd_pacote int primary key auto_increment,
        //voo_ida varchar(50),
        //hotel varchar(50),
        //vl_total decimal (10.2),
        //voo_volta varchar(50)

        [Display(Name = "Código")]
        public string cd_pacote { get; set; }


        [Display(Name = "Ida")]
        public string voo_ida { get; set; }


        [Display(Name = "Hotel")]
        public string hotel { get; set; }


        [Display(Name = "Valor")]
        public Decimal vl_total { get; set; }


        [Display(Name = "Volta")]
        public string voo_volta { get; set; }

    }
}