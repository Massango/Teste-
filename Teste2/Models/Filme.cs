using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Teste2.Models
{
    [Table("tb_Filmes")]
    public class Filme
    {
        [Key]
        [Column("FilmeID")]
        public int FilmeID { get; set; }
        [Column("Titulo")]
        public String Titulo { get; set; }
        [Column("Sinopse")]
        public String Sinopse { get; set; }
        [Column("AutorID")]
        public int AutorID { get; set; }
        public virtual Autor Autores { get; set; }
        [Column("ActorID")]
        public int ActorID { get; set; }
        public virtual Actor Actores { get; set; }
        [Column("Categoria")]
        public int CategoriaID { get; set; }
        public virtual Categoria categoria { get; set; }
        
    }
}