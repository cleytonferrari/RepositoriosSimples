using System.Collections.Generic;
using System.Linq;
using Repositorio.EF.DatabaseFirst;
using Produto = Repositorio.EF.DatabaseFirst.Produto;

namespace Aplicacao
{
    public class ProdutoAplicacaoEFDatatabaseFirst
    {
        private readonly SisProdutoEntities produtoRepositorio;

        public ProdutoAplicacaoEFDatatabaseFirst()
        {
            produtoRepositorio = new SisProdutoEntities();
        }

        public List<Produto> ListarProdutoPorNome(string nome)
        {
            return produtoRepositorio.Produto.Where(x => x.Nome.ToLower().Contains(nome.ToLower())).ToList();
        }

        public List<Produto> ListarProdutoPorCategoria(string categoria)
        {
            return produtoRepositorio.Produto.Where(x => x.Categoria.ToLower().Contains(categoria.ToLower())).ToList();
        }

        public bool InserirProduto(Produto produto)
        {
            //fazer a validação do produto aqui

            produtoRepositorio.Produto.Add(produto);
            produtoRepositorio.SaveChanges();
            return true;
        }

        public bool AlterarProduto(Produto produto)
        {
            //fazer a validação do produto aqui
            var produtoAlterar = produtoRepositorio.Produto.Find(produto.ProdutoId);
            if (produtoAlterar == null)
                return false;

            produtoAlterar.Nome = produto.Nome;
            produtoAlterar.Categoria = produto.Categoria;
            produtoAlterar.Saldo = produto.Saldo;
            produtoAlterar.ValorUnitario = produto.ValorUnitario;

            produtoRepositorio.SaveChanges();
            return true;
        }

        public bool ExcluirProuto(int id)
        {
            //validar se existe antes de excluir
            var produto = produtoRepositorio.Produto.Find(id);
            if (produto == null)
                return false;
            produtoRepositorio.Produto.Remove(produto);
            produtoRepositorio.SaveChanges();
            return true;

        }
    }
}
