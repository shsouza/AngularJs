using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ListaTelefonicaApi.Models
{
    [Table("Contato")]
    public class ContatoModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        [StringLength(11)]
        public string Telefone { get; set; }
        
        [ForeignKey("Operadora")]
        public int IdOperadora { get; set; }

        public virtual OperadoraModel Operadora { get; set; }
    }
}