using PROJECT_GESTOR_V3.Models;
using System.Collections.Generic;

namespace PROJECT_GESTOR_V3.ViewModel
{
    public class GameFormViewModel
    {
        public GameModel Game { get; set; }

        public ICollection<FabricaModel> Fabricas { get; set; }
    }
}
