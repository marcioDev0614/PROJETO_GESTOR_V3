using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PROJECT_GESTOR_V3.Models
{
    public class FabricanteModel
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public ICollection<JogoModel> Jogos { get; set; } = new List<JogoModel>();

        public FabricanteModel()
        {

        }

        public FabricanteModel(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
