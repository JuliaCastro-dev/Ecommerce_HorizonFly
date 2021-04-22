using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Aeroporto
    {

        //create table tbl_aeroporto(
        //cd_aeroporto int primary key auto_increment,
        //nm_aeroporto varchar (25),
        //cidade_aeroproto varchar(25)
        //);

        [Required]
        [Key]
        [Display(Name = "Código")]
        public string cd_aeroporto { get; set; }


        [StringLength(25, ErrorMessage = "O limite é de 25 caracteres.")]
        [Display(Name = "Nome")]
        public string nm_aeroporto { get; set; }


        [StringLength(25, ErrorMessage = "O limite é de 25 caracteres.")]
        [Display(Name = "Cidade")]
        public string cidade_aeroporto { get; set; }
    }
}