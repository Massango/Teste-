using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Teste2.Models
{
    [Table("Copias")]
    public class Copia
    {
        [Key]
        [Column("CopiaID")]
        public int CopiaID { get; set; }
        //[Column("DataAluguer")]
        //public DateTime DataAluguer { get; set; }
        [Column("FilmeID")]
        public int FilmeID { get; set; }
        public virtual Filme filme { get; set; }
        [Column("EstadoID")]
        public int EstadoID { get; set; }
        public virtual Estado estado { get; set; }
        [Column("Disponibilidade")]
        public bool Disponibilidade { get; set; }
            }
}