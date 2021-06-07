using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class IndexViewModel
    {
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


    }
}