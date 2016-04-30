using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ListaTelefonicaApi.Models
{
    [Table("Operadora")]
    public class OperadoraModel
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(128)]
        public string Nome { get; set; }
    }
}