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
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2}")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Informe o valor da despesa")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataCadastro { get; set; }
        public SituacaoTipo Situacao { get; set; }

        public DespesaTipoModel Despesas { get; set; }



    }
}
