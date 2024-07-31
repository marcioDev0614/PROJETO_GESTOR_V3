using Microsoft.EntityFrameworkCore;
using PROJECT_GESTOR_V3.Data;
using PROJECT_GESTOR_V3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PROJECT_GESTOR_V3.Repositorio
{
    public class DespesaRepositorio : IDespesaRepositorio
    {
        private readonly BancoContext _bancoContext;

        public DespesaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public DespesaModel Adicionar(DespesaModel despesaModel)
        {
            _bancoContext.Despesas.Add(despesaModel);
            _bancoContext.SaveChanges();

            return despesaModel;
        }

        public bool Apagar(int id)
        {
            var despesaDB = BuscarPorId(id);

            if (despesaDB == null) throw new SystemException("Ops! Erro na deleção da despesa");

            _bancoContext.Despesas.Remove(despesaDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public DespesaModel Atualizar(DespesaModel despesaModel)
        {
            var despesaDB = BuscarPorId(despesaModel.Id);

            if (despesaModel == null) throw new SystemException("Ops! Erro ao atualizar a sua despesa");

            despesaDB.Titulo = despesaModel.Titulo;
            despesaDB.Valor = despesaModel.Valor;
            despesaDB.DataVencimento = despesaModel.DataVencimento;
            despesaDB.DataCadastro = DateTime.Now;
            despesaDB.Situacao = despesaModel.Situacao;


            _bancoContext.Despesas.Update(despesaDB);
            _bancoContext.SaveChanges();

            return despesaDB;
        }

        public DespesaModel BuscarPorId(int id)
        {
            return _bancoContext.Despesas.FirstOrDefault(x => x.Id == id);
        }

        public List<DespesaModel> BuscarTodos()
        {
            return _bancoContext.Despesas.ToList();
        }

        public decimal CalcularTotalDespesasApagar()
        {
            return _bancoContext.Despesas
                .Where(c =>c.Situacao == Enums.SituacaoTipo.A_Pagar)
                .Sum(c => c.Valor);
        }

        public decimal CalcularTotalDespesasPago()
        {
            return _bancoContext.Despesas
                .Where(c => c.Situacao == Enums.SituacaoTipo.Pendente)
                .Sum(c => c.Valor);
        }
    }
}
