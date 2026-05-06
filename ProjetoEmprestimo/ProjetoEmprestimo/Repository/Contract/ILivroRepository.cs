using ProjetoEmprestimo.Controllers;
using ProjetoEmprestimo.Models;

namespace ProjetoEmprestimo.Repository.Contract
{
    public interface ILivroRepository
    {
        IEnumerable<Livro> ObterTodosLivros();
        void Cadastrar(Livro Livro);

        void Atualizar(Livro Livro);

        Livro ObterLivros(int id);

        void Excluir(int Id);

    }
}
