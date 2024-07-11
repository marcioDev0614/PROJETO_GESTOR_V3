using PROJECT_GESTOR_V3.Models;
using PROJECT_GESTOR_V3.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using PROJECT_GESTOR_V3.Repositorio;

namespace PROJECT_GESTOR_V3.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel Adicionar(UsuarioModel usuarioModel)
        {
            usuarioModel.DataCadastro = DateTime.Now;
            _bancoContext.Usuarios.Add(usuarioModel);
            _bancoContext.SaveChanges();
            return usuarioModel;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new SystemException("Ops! Erro na deleção do usuário");

            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public UsuarioModel Atualizar(UsuarioModel usuarioModel)
        {
            var usuarioDB = ListarPorId(usuarioModel.Id);

            if (usuarioModel == null) throw new SystemException("Ops! Erro ao atualizar o cadastro do usuário.");

            usuarioDB.Nome = usuarioModel.Nome;
            usuarioDB.Email = usuarioModel.Email;
            usuarioDB.Login = usuarioModel.Login;
            usuarioDB.Perfil = usuarioModel.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;
            

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;

        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }
    }
}
