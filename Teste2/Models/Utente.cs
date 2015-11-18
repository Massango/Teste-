using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Teste2.Models
{
    [Table("Utente")]
    public class Utente
    {
        [Key]
        [Column("UtenteID")]
        public int UtenteID { get; set; }
        [Column("Nome")]
        public String Nome { get; set; }
        [Column("Idade")]
        public int idade { get; set; }
        [Column("Sexo")]
        public String Sexo { get; set; }
        [Column("Distrito")]
        public String Distrito { get; set; }
        [Column("BINR")]
        public String BiNr { get; set; }
        [Column("Aluguer")]
       // public int AluguerID { get; set; }
        public virtual ICollection<Aluguer> Alugar { get; set; }

    }
}