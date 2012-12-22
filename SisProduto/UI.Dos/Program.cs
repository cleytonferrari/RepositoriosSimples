using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao;
using Dominio;
using Repositorio.SQLServer;

namespace UI.Dos
{
    class Program
    {
        static void Main(string[] args)
        {
            var produtoAplicacao = new ProdutoAplicacao();


            var produtoAlterar = new Produto()
                              {
                                  ProdutoId = 1,
                                  Categoria = "Ferro",
                                  Nome = "Arruela",
                                  Saldo = 233,
                                  ValorUnitario = 10
                              };
            produtoAplicacao.AlterarProduto(produtoAlterar);



            var produtoInserir = new Produto()
            {
                ProdutoId = 1,
                Categoria = "CARNE",
                Nome = "CARNE MOIDA",
                Saldo = 4,
                ValorUnitario = 10
            };

            produtoAplicacao.InserirProduto(produtoInserir);

            var produtos = produtoAplicacao.ListarProdutoPorNome("CAR");
            foreach (var produto in produtos)
            {
                Console.WriteLine("{0} - {1} - {2} - R$ {3} - {4}", produto.ProdutoId, produto.Nome, produto.Categoria, produto.ValorUnitario, produto.Saldo);
            }
        }
    }
}
