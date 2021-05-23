using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Transporte
    {
        //CREATE TABLE Transporte (
        //cd_transporte INTEGER not null primary key auto_increment,
        //cidade_trasnporte INTEGER not null,
        //nome_trasnporte VARCHAR(100) not null,
        //tipo_transporte ENUM ('Rodoviária','Aeroporto'),
        //img_trasnporte VARCHAR(1000) not null

        [Required]
        [Key]
        [Display(Name = "Código")]
        public string cd_transporte { get; set; }



        [Display(Name = "Cidade")]
        public string cidade_transporte { get; set; }



        [StringLength(100, ErrorMessage = "O limite é de 100 caracteres.")]
        [Display(Name = "Nome do Transporte")]
        public string nome_transporte { get; set; }



        [Display(Name = "Transporte")]
        public string tipo_transporte { get; set; }


        [Display(Name = "Foto")]
        public string img_transporte { get; set; }

    }
}