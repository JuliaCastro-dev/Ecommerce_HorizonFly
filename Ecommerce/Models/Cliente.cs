using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Cliente
    {

        //create table tbl_Cliente(
        //cd_cliente int primary key auto_increment,
        //nm_cliente varchar(50),
        //cd_cartao int,
        //CPF varchar(11),
        //RG varchar(20),
        //tel_cliente varchar(11),
        //E_mail varchar(20),
        //Idade int,
        //foreign key(cd_cartao) references tbl_Cartões(cd_cartoes)

        [Display(Name = "Código")]
        [Required]
        [Key]
        public string cd_cliente { get; set; }


        [StringLength(50, ErrorMessage = "O limite é de 50 caracteres.")]
        [Display(Name = "Nome")]
        public string nm_cliente { get; set; }


        [CreditCard]
        [Required]
        [Display(Name = "Código do cartão")]
        public string cd_cartao { get; set; }


        [StringLength(11, ErrorMessage = "O limite é de 11 caracteres.")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }


        [StringLength(12, ErrorMessage = "O limite é de 12 caracteres.")]
        [Display(Name = "Registro geral")]
        public string RG { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string tel_cliente { get; set; }


        [EmailAddress]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        [Display(Name = "E-mail")]
        public string E_mail { get; set; }


        [Required]
        [Display(Name = "Idade")]
        public string Idade { get; set; }
    }
}