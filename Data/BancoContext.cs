using PROJECT_GESTOR_V3.Models;
using Microsoft.EntityFrameworkCore;

namespace PROJECT_GESTOR_V3.Data
{
    public class BancoContext : DbContext
    {
       public BancoContext(DbContextOptions<BancoContext> options) : base(options) 
        { 
        
        }

        // Modulo de Livros
        public DbSet<LivroModel> Livros { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        // Modulo de Despesas
        public DbSet<DespesaModel> Despesas { get; set; }

        // Modulo de Jogo

        public DbSet<Fabricante> Fabricantes { get; set; }





    }
}
