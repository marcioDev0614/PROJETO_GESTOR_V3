using System.Collections;
using System.Collections.Generic;

namespace PROJECT_GESTOR_V3.Models
{
    public class FabricaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<GameModel> Games { get; set; } = new List<GameModel>();

        public FabricaModel() { }

        public FabricaModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
