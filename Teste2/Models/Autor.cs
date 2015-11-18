using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Teste2.Models
{
    [Table("Autor")]
    public class Autor
    {
        [Key]
        [Column("AutorID")]
        public int AutorID {get;set;}
        [Column("NomeAutor")]
        public string Nome{ get; set; }
              
    }
}