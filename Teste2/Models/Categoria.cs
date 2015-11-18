using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Teste2.Models
{
    [Table("Tb_Categoria")]
    public class Categoria
    {
        [Key]
        [Column("CategoriaID")]
        public int CategoriaID { get; set; }
        [Column("Designacao")]
        public String Designacao { get; set; }
        public virtual ICollection<Filme> Filmes { get; set; }
    }
}