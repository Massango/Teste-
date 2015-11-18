using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Teste2.Models
{
    [Table("Actor")]
    public class Actor
    {
        [Key]
        [Column("ActorID")]
        public int ActorID { get; set; }
        [Column("Actor")]
        public String NomeActor{ get; set; }
    }
}