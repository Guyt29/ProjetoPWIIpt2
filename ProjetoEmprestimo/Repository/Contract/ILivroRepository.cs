using ProjetoEmprestimo.Controllers;
using ProjetoEmprestimo.Models;

namespace ProjetoEmprestimo.Repository.Contract
{
    public interface ILivroRepository
    {
        void Cadastrar(Livro Livro);

        void Atualizar(Livro Livro);

        Livro ObterLivros(Livro Livro);

        void Excluir(int id);
        void Cadastrar(LivroController livro);
    }
}
