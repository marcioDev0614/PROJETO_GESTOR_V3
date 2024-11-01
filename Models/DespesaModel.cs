using PROJECT_GESTOR_V3.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJECT_GESTOR_V3.Models
{
    [Table("Despesas")]
    public class DespesaModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O titulo da despesas deve ser informado")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Informe o valor da despesa")]
        [Display(Name = "Preço")]
        //[Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Valor { get; set; }
        [DisplayFormat(DataFormatString = "0:dd/MM/yyyy")]
        public DateTime DataVencimento { get; set; }
        public DateTime? DataCadastro { get; set; }
        public SituacaoTipo Situacao { get; set; }

    }
}
