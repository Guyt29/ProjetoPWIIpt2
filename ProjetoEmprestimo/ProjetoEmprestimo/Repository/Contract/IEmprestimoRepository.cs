using ProjetoEmprestimo.Models;

namespace ProjetoEmprestimo.Repository.Contract
{
    public interface IEmprestimoRepository
    {
        IEnumerable<Livro> ObterTodosEmprestimos();
        void Cadastrar(Emprestimo emprestimo);
        void Atualizar(Emprestimo emprestimo);

        Emprestimo ObterEmprestimos(int id);
        void buscaIdEmp(int id);
        void Excluir(int id);
    }
}
