using PROJECT_GESTOR_V3.Models;
using System.Collections.Generic;

namespace PROJECT_GESTOR_V3.ViewModel
{
    public class JogoFormViewModel
    {
        public JogoModel Jogo { get; set; }
        public IEnumerable<FabricanteModel> Fabricantes { get; set; }
    }
}
