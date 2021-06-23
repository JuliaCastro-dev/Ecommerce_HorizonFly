using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models.ViewsModels
{
    public class RRViewModel
    {



        public List<Itens> ItensPedido = new List<Itens>();

        [Required]
        [Key]
        [Display(Name = "Código da reserva")]
        public string cd_reserva { get; set; }


        [Required]
        [Key]
        [Display(Name = "CPF")]
        [StringLength(14, MinimumLength = 12, ErrorMessage = "CPF Inválido")]
        public string cpf_cliente { get; set; }



        [CreditCard]
        [Required]
        [Display(Name = "Código do cartão")]
        public string cd_cartao { get; set; }




        [Required]
        [Display(Name = "Valor Total")]
        public string vl_total { get; set; }


        [Required]
        [Display(Name = "Data e Hora da Compra")]
        public string dt_reserva { get; set; }


        [Required]
        [Display(Name = "Valor Unitário")]
        public string vl_unit { get; set; }


        [Required]
        [Display(Name = "Valor Parcial")]
        public string vl_parcial { get; set; }


        [Display(Name = "Quantidade")]
        public int qt { get; set; }


        [Display(Name = "Cliente")]
        public string nome_cliente { get; set; }


        [Display(Name = "Cartao")]
        public string nome_cartao { get; set; }

        [Display(Name = "Pacote")]
        public string nome_pacote { get; set; }


        [Display(Name = "Imagem")]
        public string img { get; set; }

    }
}