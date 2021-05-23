using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Estado
    {
        //create table Estado(
        //cd_estado int primary key auto_increment,
        //nm_estado varchar(50),
        //uf varchar(5) default null);

        [Required]
        [Key]
        [Display(Name = "Código Estado")]
        public string cd_estado { get; set; }


        [StringLength(50, ErrorMessage = "O limite é de 50 caracteres.")]
        [Display(Name = "Estado: ")]
        public string estado { get; set; }

        [Display(Name = "UF")]
        public string uf { get; set; }








    }
}