using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao;
using Repositorio.EF.DatabaseFirst;
using Repositorio.SQLServer;
//using Produto = Dominio.Produto;
using Produto = Repositorio.EF.DatabaseFirst.Produto;

namespace UI.Dos
{
    class Program
    {
        static void Main(string[] args)
        {

            //var produtoAplicacao = new ProdutoAplicacaoSQL();
            var produtoAplicacao = new ProdutoAplicacaoEFDatatabaseFirst();
            
            var produtoAlterar = new Produto()
                              {
                                  ProdutoId = 1,
                                  Categoria = "Ferro Fundido",
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

            produtoAplicacao.ExcluirProuto(6);

            var produtos = produtoAplicacao.ListarProdutoPorNome("CAR");

            foreach (var produto in produtos)
            {
                Console.WriteLine("{0} - {1} - {2} - R$ {3} - {4}", produto.ProdutoId, produto.Nome, produto.Categoria, produto.ValorUnitario, produto.Saldo);
            }
        }
    }
}
