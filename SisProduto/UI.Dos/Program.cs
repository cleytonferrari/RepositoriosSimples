using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio.SQLServer;

namespace UI.Dos
{
    class Program
    {
        static void Main(string[] args)
        {
            var produtoRepositorio = new ProdutoRepositorio();
            

            var produtoAlterar = new Produto()
                              {
                                  ProdutoId = 1,
                                  Categoria = "Ferro",
                                  Nome = "Arruela",
                                  Saldo = 233,
                                  ValorUnitario =  10
                              };
            produtoRepositorio.Alterar(produtoAlterar);
            
            

            var produtoInserir = new Produto()
            {
                ProdutoId = 1,
                Categoria = "ARROZ",
                Nome = "COMIDA",
                Saldo = 4,
                ValorUnitario = 10
            };

            produtoRepositorio.Inserir(produtoInserir);

            var produtos = produtoRepositorio.ListarTodos();
            foreach (var produto in produtos)
            {
                Console.WriteLine("{0} - {1} - {2} - R$ {3} - {4}", produto.ProdutoId, produto.Nome, produto.Categoria, produto.ValorUnitario, produto.Saldo);
            }
        }
    }
}
