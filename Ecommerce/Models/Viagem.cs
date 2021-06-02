using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Viagem
    {
        //CREATE TABLE Viagem (
        //cd_viagem INTEGER not null primary key auto_increment,
        //tipo_transporte VARCHAR(50) not null,
        //origem INTEGER not null,
        //destino INTEGER not null,
        //dt_ida DATETIME not null,
        //dt_chegada DATETIME not null,
        //duracao TIME not null,
        //descricao VARCHAR(400) not null,
        //vl_total DECIMAL(10,2) not null,
        //img_viagem VARCHAR(1000) not null


        [Required]
        [Key]
        [Display(Name = "Código")]
        public string cd_viagem { get; set; }

        [StringLength(100, ErrorMessage = "O limite é de 100 caracteres.")]
        [Display(Name = "Viagem")]
        public string nome_viagem { get; set; }


        [StringLength(50, ErrorMessage = "O limite é de 50 caracteres.")]
        [Display(Name = "Tipo de transporte")]
        public string tipo_transporte { get; set; }


        [Required]
        [Display(Name = "Origem")]
        public string origem { get; set; }



        [Required]
        [Display(Name = "Destino")]
        public string destino { get; set; }


        [Required]
        [Display(Name = "Data de Ida")]
        public string dt_ida { get; set; }


        [Required]
        [Display(Name = "Data de Chegada")]
        public string dt_chegada { get; set; }


        [Required]
        [Display(Name = "Duração")]
        public string duracao { get; set; }



        [Required]
        [StringLength(400, ErrorMessage = "O limite é de 400 caracteres.")]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }



        [Required]
        [Display(Name = "Valor Total")]
        public string vl_total { get; set; }



        [Required]
        [StringLength(1000, ErrorMessage = "O limite é de 1000 caracteres.")]
        [Display(Name = "Foto")]
        public string img_viagem { get; set; }

    }
}