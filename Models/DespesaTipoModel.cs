using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJECT_GESTOR_V3.Models
{
    [Table("DespesaTipos")]
    public class DespesaTipoModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100, ErrorMessage = "O tamanho máximo são de 100 caracteres")]
        [Required(ErrorMessage = "Informe o tipo da despesa.")]
        [Display(Name = "Nome da Despesa")]
        public string DespesaNome { get; set; }
        [StringLength(200, ErrorMessage = "O tamanho máximo são de 200 caracteres")]
        [Required(ErrorMessage = "Informe a descrição da despesa.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public List<DespesaModel> Despesas { get; set; }
    }
}
