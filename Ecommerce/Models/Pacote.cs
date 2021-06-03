using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Pacote
    {
        //CREATE TABLE Pacote(
        //cd_pacote INTEGER PRIMARY KEY auto_increment,
        //voo_ida INTEGER,
        //voo_volta INTEGER,
        //cd_hotel INTEGER,
        //vl_total DECIMAL(10,2),
        //img_pacote VARCHAR(300),
        //foreign key(voo_ida) references Voo(cd_voo),
        // foreign key(voo_volta) references Voo(cd_voo),
        //  foreign key(cd_hotel) references Hotel(cd_hotel)
        //);

        [Display(Name = "Código")]
        public string cd_pacote { get; set; }

        [Required]
        [Display(Name = "Transporte")]
        public string cd_transporte { get; set; }

        [Required]
        [Display(Name = "Transporte")]
        public string cd_viagem { get; set; }

        [Required]
        [Display(Name = "Hotel")]
        public string cd_hotel { get; set; }


        [Required]
        [Display(Name = "Origem")]
        public string cd_cidOrigem { get; set; }

        [Required]
        [Display(Name = "Destino")]
        public string cd_cidDestino { get; set; }


        [Required]
        [Display(Name = "Pacote")]
        public string nome_pacote { get; set; }

        [Required]
        [Display(Name = "Valor")]
        public Decimal vl_pacote { get; set; }


        [Required]
        [Display(Name = "Tipo de transporte")]
        public string tipo_transporte { get; set; }

        [Required]
        [Display(Name = "Descrição do Pacote")]
        public string descricao_pacote { get; set; }

        [Required(ErrorMessage = "Preencha a Data de Entrada no hotel")]
        [Display(Name = "Data Chekin Hotel")]
        public string dt_chekinHotel { get; set; }
        [Required(ErrorMessage = "Preencha a Data de Saida no hotel")]
        [Display(Name = "Data Chekout Hotel")]
        public string dt_chekoutHotel { get; set; }

        [Required]
        [Display(Name = "Foto")]
        public string img_pacote { get; set; }

    }
}