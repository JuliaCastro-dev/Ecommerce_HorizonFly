using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Hotel
    {
        //CREATE TABLE Hotel (
        //cd_hotel INTEGER not null primary key auto_increment,
        //cd_cidade INTEGER not null,
        //nome_hotel VARCHAR(100) not null,
        //decricao_hotel VARCHAR(400) not null,
        //telefone_hotel VARCHAR(17) not null,
        //endereco_hotel VARCHAR(100) not null,
        //diaria_hotel DECIMAL(10,2) not null,
        //img_hotel VARCHAR(500) not null,
        //FOREIGN KEY (cd_cidade) REFERENCES Cidade (cd_cidade) /*Referencia */


        [Required]
        [Key]
        [Display(Name = "Código")]
        public string cd_hotel { get; set; }

        [Required]
        [Display(Name = "Código")]
        public string cd_cidade { get; set; }


        [StringLength(100, ErrorMessage = "O limite é de 100 caracteres.")]
        [Display(Name = "Hotel")]
        public string nome_hotel { get; set; }


        [Display(Name = "Diaria")]
        public Decimal diaria_hotel { get; set; }


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

    }
}