using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Teste2.Models
{
    [Table("Tb_Estado")]
    public class Estado
    {
        [Key]
        [Column("EstadoID")]
        public int EstadoID { get; set; }
        [Column("Designacao")]
        public String Designacao { get; set; }
        public virtual ICollection<Filme> Filmes { get; set; }

    }
}