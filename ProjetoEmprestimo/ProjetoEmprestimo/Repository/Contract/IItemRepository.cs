using ProjetoEmprestimo.Models;

namespace ProjetoEmprestimo.Repository.Contract
{
    public interface IItemRepository
    {

        IEnumerable<Item> ObterTodosLivros();
        void Cadastrar(Item item);
        void Atualizar(Item item);
        Livro ObterLivros(int id);
        void Excluir(int id);
    }
}
