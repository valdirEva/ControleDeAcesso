using ControleDeAcesso.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeAcesso.Models
{
    public class Pessoa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Apartamento")]
        public Guid? ApartamentoId { get; set; }
        public Apartamento Apartamento { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataNascimento { get; set; }

        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefone inválido.")]
        public string Telefone { get; set; }
        [Display(Name = "Inativo")]
        public InativoEnum Inativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }


    }
}
