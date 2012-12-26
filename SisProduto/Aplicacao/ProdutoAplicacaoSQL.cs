using System.Collections.Generic;
using System.Linq;
using Repositorio.SQLServer;
using Produto = Dominio.Produto;

namespace Aplicacao
{
    public class ProdutoAplicacaoSQL
    {
        private readonly ProdutoRepositorio produtoRepositorioSQL;

        public ProdutoAplicacaoSQL()
        {
            produtoRepositorioSQL = new ProdutoRepositorio();
        }

        public List<Produto> ListarProdutoPorNome(string nome)
        {
            return produtoRepositorioSQL.ListarTodos().Where(x => x.Nome.ToLower().Contains(nome.ToLower())).ToList();
        }

        public List<Produto> ListarProdutoPorCategoria(string categoria)
        {
            return produtoRepositorioSQL.ListarTodos().Where(x => x.Categoria.ToLower().Contains(categoria.ToLower())).ToList();
        }

        public bool InserirProduto(Produto produto)
        {
            //fazer a validação do produto aqui
            return produtoRepositorioSQL.Inserir(produto);
        }

        public bool AlterarProduto(Produto produto)
        {
            //fazer a validação do produto aqui
            return produtoRepositorioSQL.Alterar(produto);
        }

        public bool ExcluirProuto(int id)
        {
            //validar se existe antes de excluir
            return produtoRepositorioSQL.Excluir(id);
        }
    }
}
