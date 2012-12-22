using System.Collections.Generic;
using System.Linq;
using Dominio;
using Repositorio.SQLServer;

namespace Aplicacao
{
    public class ProdutoAplicacao
    {
        private readonly ProdutoRepositorio produtoRepositorio;

        public ProdutoAplicacao()
        {
            produtoRepositorio = new ProdutoRepositorio();
        }

        public List<Produto> ListarProdutoPorNome(string nome)
        {
            return produtoRepositorio.ListarTodos().Where(x => x.Nome.ToLower().Contains(nome.ToLower())).ToList();
        }

        public List<Produto> ListarProdutoPorCategoria(string categoria)
        {
            return produtoRepositorio.ListarTodos().Where(x => x.Categoria.ToLower().Contains(categoria.ToLower())).ToList();
        }

        public bool InserirProduto(Produto produto)
        {
            //fazer a validação do produto aqui
            return produtoRepositorio.Inserir(produto);
        }

        public bool AlterarProduto(Produto produto)
        {
            //fazer a validação do produto aqui
            return produtoRepositorio.Alterar(produto);
        }

        public bool ExcluirProuto(int id)
        {
            //validar se existe antes de excluir
            return produtoRepositorio.Excluir(id);
        }
    }
}
