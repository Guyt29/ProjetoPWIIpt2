using ProjetoEmprestimo.Models;

namespace ProjetoEmprestimo.Repository.Contract
{
    public interface IEmprestimoRepository
    {
        IEnumerable<Livro> ObterEmprestimos();
        void Cadastrar(Emprestimo emprestimo);
        void Atualizar(Emprestimo emprestimo);
        void buscaIdEmp(int id);
        Emprestimo ObterEmprestimos(int id);
        void Excluir(int id);
    }
}
