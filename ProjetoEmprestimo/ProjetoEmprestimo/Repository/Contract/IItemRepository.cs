using ProjetoEmprestimo.Models;

namespace ProjetoEmprestimo.Repository.Contract
{
    public interface IItemRepository
    {

        IEnumerable<Livro> ObterTodosLivros();
        void Cadastrar(Livro livro);
        void Atualizar(Livro livro);
        Livro ObterLivros(int id);
        void Excluir(int id);
    }
}
