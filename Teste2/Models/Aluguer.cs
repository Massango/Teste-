using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Teste2.Models
{
    [Table("Aluguer")]
    public class Aluguer
    {
        [Key]
        [Column("AluguerID")]
        public int AluguerID { get; set; }
        [Column("FilmeID")]
        public int FilmeID { get; set; }
        public virtual Filme Filmes { get; set; }
        [Column("UtenteID")]
        public int UtenteID { get; set; }
        public virtual Utente Utentes { get; set; }
        [Column("DataAluguer")]
        public DateTime DataAluguer { get; set; }
        [Column("DataDEvolucao")]
        public DateTime DataDEvolucao { get; set; }
        [Column("Alugado")]
        [DefaultValue(false)]
        public bool Devolvido { get; set; }
    }
}