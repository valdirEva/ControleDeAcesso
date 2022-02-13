using ControleDeAcesso.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeAcesso.Models
{
    public class Apartamento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public ApartamentoBloco Bloco { get; set; }
    }
}
