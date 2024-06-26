using PROJECT_GESTOR_V3.Models;
using PROJECT_GESTOR_V3.Data;
using System;
using System.Linq;
using System.Collections.Generic;

namespace PROJECT_GESTOR_V3.Repositorio
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly BancoContext _bancoContext;

        public LivroRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public LivroModel Adicionar(LivroModel livroModel)
        {
            _bancoContext.Livros.Add(livroModel);
            _bancoContext.SaveChanges();

            return livroModel;
        }

        public bool Apagar(int id)
        {
            var livroDB = ListarPorId(id);

            if (livroDB == null) throw new SystemException("Ops! Erro na deleção do livro");

            _bancoContext.Livros.Remove(livroDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public LivroModel Atualizar(LivroModel livroModel)
        {
            var livroDB = ListarPorId(livroModel.Id);

            if (livroModel == null) throw new SystemException("Ops! Erro ao atualizar o cadastro do livro.");

            livroDB.Titulo = livroModel.Titulo;
            livroDB.Autor = livroModel.Autor;
            livroDB.Genero = livroModel.Genero;
            livroDB.Data_de_Cadastro = livroModel.Data_de_Cadastro;

            _bancoContext.Livros.Update(livroDB);
            _bancoContext.SaveChanges();

            return livroDB;

        }

        public List<LivroModel> BuscarTodos()
        {
            return _bancoContext.Livros.ToList();
        }

        public LivroModel ListarPorId(int id)
        {
            return _bancoContext.Livros.FirstOrDefault(x => x.Id == id);
        }
    }
}
