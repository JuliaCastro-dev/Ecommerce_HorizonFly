using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Hotel
    {
        //create table Hotel(
        //cd_hotel int primary key auto_increment,
        //nm_hotel varchar(50),
        //diaria_hotel decimal (10.2),
        //vl_hotel decimal (10.2),
        //est_hotel varchar(50),
        //cid_estado varchar(50),
        //end_hotel varchar(50),
        //tel_hotel  varchar(11),
        //total_quartos int


        [Required]
        [Key]
        [Display(Name = "Código")]
        public string cd_hotel { get; set; }


        [Display(Name = "Nome")]
        public string nm_hotel { get; set; }


        [Display(Name = "Diaria")]
        public Decimal diaria_hotel { get; set; }


        [Display(Name = "Valor")]
        public Decimal vl_hotel { get; set; }


        [Display(Name = "Estado")]
        public string est_hotel { get; set; }


        [Display(Name = "Cidade")]
        public string cid_estado { get; set; }


        [Display(Name = "Endereço")]
        public string end_hotel { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string tel_hotel { get; set; }


        [Required]
        [Display(Name = "Quartos")]
        public string total_quartos { get; set; }
    }
}