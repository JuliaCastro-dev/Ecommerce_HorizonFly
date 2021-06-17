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
        [Display(Name = "Viagem")]
        public string cd_viagem { get; set; }

        [Required]
        [Display(Name = "Hotel")]
        public string cd_hotel { get; set; } 


        [Required]
        [Display(Name = "Categoria")]
        public string cd_categoria { get; set; }


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
        public string vl_pacote { get; set; }


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

        // ADICIONAIS

        [Display(Name = "Origem")]
        public string Origem { get; set; }

        [Display(Name = "Destino")]
        public string Destino { get; set; }


        [Display(Name = "Destino")]
        public string Transportedestino { get; set; }

        [StringLength(100, ErrorMessage = "O limite é de 100 caracteres.")]
        [Display(Name = "Viagem")]
        public string nome_viagem { get; set; }




        [Required]
        [Display(Name = "Data de Ida")]
        public string dt_ida { get; set; }


        [Required]
        [Display(Name = "Data de Chegada")]
        public string dt_chegada { get; set; }


        [Required]
        [StringLength(400, ErrorMessage = "O limite é de 400 caracteres.")]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }


        [Required]
        [Display(Name = "Código")]
        public string cd_cidade { get; set; }


        [StringLength(100, ErrorMessage = "O limite é de 100 caracteres.")]
        [Display(Name = "Hotel")]
        public string nome_hotel { get; set; }


        [Display(Name = "Diaria")]


        public string diaria_hotel { get; set; }


        [StringLength(400, ErrorMessage = "O limite é de 400 caracteres.")]
        [Display(Name = "Descrição")]
        public string descricao_hotel { get; set; }


        [Display(Name = "Cidade")]
        public string cidade_hotel { get; set; }


        [StringLength(100, ErrorMessage = "O limite é de 100 caracteres.")]
        [Display(Name = "Endereço")]
        public string endereco_hotel { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string telefone_hotel { get; set; }


        [Required]
        [Display(Name = "Foto")]
        public string img_hotel { get; set; }


        [StringLength(1, ErrorMessage = "Valor Obrgatório")]
        [Display(Name = "Valor Total")]
        public string vl_total { get; set; }



        [Required]
        [StringLength(1000, ErrorMessage = "O limite é de 1000 caracteres.")]
        [Display(Name = "Foto")]
        public string img_viagem { get; set; }

    }
}