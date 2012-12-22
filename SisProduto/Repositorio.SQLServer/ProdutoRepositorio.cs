using System;
using System.Collections.Generic;
using Dominio;

namespace Repositorio.SQLServer
{
    public class ProdutoRepositorio
    {
        private readonly Contexto contexto;

        public ProdutoRepositorio()
        {
            contexto = new Contexto();
        }

        public bool Inserir(Produto produto)
        {

            var strQuery = " ";
            strQuery += " INSERT INTO PRODUTO (Nome, ValorUnitario, Categoria, Saldo) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}','{3}') ", produto.Nome, produto.ValorUnitario, produto.Categoria, produto.Saldo);

            return contexto.ExecutaComando(strQuery);
        }

        public bool Alterar(Produto produto)
        {
            var strQuery = " ";
            strQuery += " UPDATE PRODUTO SET ";
            strQuery += string.Format(" Nome = '{0}',", produto.Nome);
            strQuery += string.Format(" ValorUnitario = '{0}',", produto.ValorUnitario);
            strQuery += string.Format(" Categoria = '{0}',", produto.Categoria);
            strQuery += string.Format(" Saldo = {0}", produto.Saldo);
            strQuery += " WHERE ";
            strQuery += string.Format(" ProdutoId = {0}", produto.ProdutoId);

            return contexto.ExecutaComando(strQuery);
        }

        public bool Excluir(int produtoId)
        {
            var strQuery = " ";
            strQuery += " DELETE FROM PRODUTO ";
            strQuery += " WHERE ";
            strQuery += string.Format(" ProdutoId = '{0}'", produtoId);
            return contexto.ExecutaComando(strQuery);
        }

        public IEnumerable<Produto> ListarTodos()
        {
            var strQuery = " ";
            strQuery += " SELECT * FROM PRODUTO ";
            var meuReader = contexto.ExecutaComandoComRetorno(strQuery);

            var produtos = new List<Produto>();

            while (meuReader.Read())
            {
                var tempProduto = new Produto
                                      {
                                          ProdutoId = Convert.ToInt32(meuReader["ProdutoId"].ToString()),
                                          Nome = meuReader["Nome"].ToString(),
                                          ValorUnitario = Convert.ToDecimal(meuReader["ValorUnitario"].ToString()),
                                          Categoria = meuReader["Categoria"].ToString(),
                                          Saldo = Convert.ToInt32(meuReader["Saldo"].ToString())
                                      };

                produtos.Add(tempProduto);
            }

            meuReader.Close();
            return produtos;
        }
    }
}
